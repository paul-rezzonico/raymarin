using System;
using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace ClementPaulSpotifyApp.Service
{
    public class SpotifyService
    {
        private SpotifyClient _spotifyClient;
        #region Instance

        public static SpotifyService Instance { get; } = new SpotifyService();

        #endregion

        public async Task<bool> ConnectSpotify()
        {
            try
            {
               var config = SpotifyClientConfig
                    .CreateDefault()
                    .WithAuthenticator(new ClientCredentialsAuthenticator("ebdf1f5d484c4fcfb28a417b5a476c6f", "bf7e92610bf5439285c09b7c6330a08c"));
                _spotifyClient = new SpotifyClient(config);
                return await Task.FromResult(true);
            }
            catch (Exception exception)
            {
                return await Task.FromResult(false);
            }
        }

        public SpotifyClient GetSpotifyClient()
        {
            return _spotifyClient;
        }

    }
}