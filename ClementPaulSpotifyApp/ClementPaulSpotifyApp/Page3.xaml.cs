using ClementPaulSpotifyApp.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClementPaulSpotifyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            loadingIndicator.IsVisible = true;
            loadingIndicator.IsRunning = true;

            const string ALBUM_ID = "26IdRjba8f8DNa7c0FwfQb";
            var spotifyService = SpotifyService.Instance;
            bool isConnected = await spotifyService.ConnectSpotify();
            if (isConnected)
            {
                var client = spotifyService.GetSpotifyClient();

                // Utiliser le client Spotify pour effectuer des opérations
                var spotify = Service.SpotifyService.Instance.GetSpotifyClient();
                var album = await spotify.Albums.Get(ALBUM_ID);

                var name = album.Name;
                if (name != null)
                {
                    albumName.Text = name;
                }

                var imageUrl = album.Images.FirstOrDefault()?.Url;
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    var image = new Image
                    {
                        Source = ImageSource.FromUri(new Uri(imageUrl))
                    };
                    albumImage.Source = image.Source;
                }

                var artName = album.Artists;
                foreach (var artist in album.Artists)
                {
                    var artisteName = new Label
                    {
                        Text = artist.Name,
                        FontSize = 16,
                        TextColor = Xamarin.Forms.Color.Black,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    };

                    artistes.Children.Add(artisteName);
                }

                var realease = album.ReleaseDate;
                if (realease != null)
                {
                    // Ecrire la date sous le format JJ/MM/AAAA
                    var date = realease.Split('-');
                    var dateFormated = date[2] + "/" + date[1] + "/" + date[0];
                    releaseDate.Text = "Date de réalisation : " + dateFormated;
                }

                var tracks = album.Tracks.Items;
                trackListView.ItemsSource = tracks;


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