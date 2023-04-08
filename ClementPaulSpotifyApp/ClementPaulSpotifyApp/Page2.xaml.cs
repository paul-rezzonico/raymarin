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
            loadingIndicator.IsVisible = true;
            loadingIndicator.IsRunning = true;

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

                foreach (var genre in artist.Genres)
                {
                    var genreLabel = new Label
                    {
                        Text = genre,
                        FontSize = 16,
                        TextColor = Color.Black,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    };

                    // Ajouter le label au layout approprié
                    genres.Children.Add(genreLabel);
                }

                var followers = artist.Followers.Total;
                if (followers != null)
                {
                    nbFollower.Text = followers.ToString();
                }

                var popularity = artist.Popularity;
                if (popularity != null)
                {
                    popularityLabel.Text = $"Popularité : {artist.Popularity}/100";
                }

                loadingIndicator.IsVisible = false;
                loadingIndicator.IsRunning = false;

            }
            else
            {
                // Connexion échouée, afficher un message d'erreur
            }

        }
    }
}