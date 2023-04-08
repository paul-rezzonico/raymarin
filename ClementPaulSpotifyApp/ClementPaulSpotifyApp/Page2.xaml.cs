using ClementPaulSpotifyApp.Service;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClementPaulSpotifyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {

            const string ARTIST_ID = "4gOc8TsQed9eqnqJct2c5v";
            var spotifyService = SpotifyService.Instance;
            bool isConnected = await spotifyService.ConnectSpotify();
            if (isConnected)
            {
                var client = spotifyService.GetSpotifyClient();

                // Utiliser le client Spotify pour effectuer des opérations
                var spotify = Service.SpotifyService.Instance.GetSpotifyClient();
                var artist = await spotify.Artists.Get(ARTIST_ID);
                
                var name = artist.Name;
                if (name != null)
                {
                   artistName.Text = name;
                }

                var imageUrl = artist.Images.FirstOrDefault()?.Url;
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    var image = new Image
                    {
                        Source = ImageSource.FromUri(new Uri(imageUrl))
                    };
                    artistImage.Source = image.Source;
                }



            }
            else
            {
                // Connexion échouée, afficher un message d'erreur
            }

        }
    }
}