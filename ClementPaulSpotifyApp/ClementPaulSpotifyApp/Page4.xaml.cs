using ClementPaulSpotifyApp;
using ClementPaulSpotifyApp.Service;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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

            var spotifyService = SpotifyService.Instance;
            bool isConnected = await spotifyService.ConnectSpotify();
            if (isConnected)
            {
                var client = spotifyService.GetSpotifyClient();

                // Utiliser le client Spotify pour effectuer des opérations
                var spotify = Service.SpotifyService.Instance.GetSpotifyClient();

                // Afficher les artistes le plus populaires du moment :
                // Obtenir les artistes les plus populaires
                List<FullArtist> artists = await GetPopularArtists();

                // Afficher les artistes dans une liste
                listViewArtists.ItemsSource = artists;

            }
            else
            {
                // Connexion échouée, afficher un message d'erreur
            }

            loadingIndicator.IsVisible = false;
            loadingIndicator.IsRunning = false;
        }
        private async void Recherche(object sender, EventArgs e)
        {
            var spotifyService = SpotifyService.Instance;
            bool isConnected = await spotifyService.ConnectSpotify();
            if (isConnected)
            {
                var client = spotifyService.GetSpotifyClient();

                // Utiliser le client Spotify pour effectuer des opérations
                var spotify = Service.SpotifyService.Instance.GetSpotifyClient();
                var search = await spotify.Search.Item(new SearchRequest(SearchRequest.Types.Artist, txtArtiste.Text));
                var artist = search.Artists.Items.FirstOrDefault();
                
                //Afficher les infos de l'artiste si il existe
                if (artist != null)
                {
                    lblNom.Text = artist.Name;
                    lblGenre.Text = artist.Genres.FirstOrDefault();
                    lblPopularite.Text = artist.Popularity.ToString();
                    lblFollowers.Text = artist.Followers.Total.ToString();
                    btnUrl.Text = artist.ExternalUrls.FirstOrDefault().Value;
                    imgArtiste.Source = artist.Images.FirstOrDefault().Url;
                }
                else
                {
                    lblNom.Text = "Artiste non trouvé";
                    lblGenre.Text = "";
                    lblPopularite.Text = "";
                    lblFollowers.Text = "";
                    btnUrl.Text = "";
                    imgArtiste.Source = "";
                }

            }
            else
            {
                // Connexion échouée, afficher un message d'erreur
            }
        }

        [Obsolete]
        private void OpenUrl(object sender, EventArgs e)
        {
            var url = btnUrl.Text;
            if (!string.IsNullOrEmpty(url))
            {
                Xamarin.Forms.Device.OpenUri(new Uri(url));
            }
        }
        private async Task<List<FullArtist>> GetPopularArtists()
        {
            // Initialisation de l'API SpotifyAPI.Web
            var spotifyService = SpotifyService.Instance;
            var spotify = spotifyService.GetSpotifyClient();

            // Recherche des artistes de K-Pop (girl groups)
            var search = await spotify.Search.Item(new SearchRequest(SearchRequest.Types.Artist, "K-Pop girl group"));

            if (search != null && search.Artists != null && search.Artists.Items != null)
            {
                // Récupération des artistes
                List<FullArtist> artists = search.Artists.Items;
                return artists;
            }
            else
            {
                return null;
            }
    }
    }
    
}

