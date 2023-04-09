using ClementPaulSpotifyApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClementPaulSpotifyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page4 : ContentPage
    {
        public Page4()
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


            }
            else
            {
                // Connexion échouée, afficher un message d'erreur
            }

            loadingIndicator.IsVisible = false;
            loadingIndicator.IsRunning = false;

        }
    }
}