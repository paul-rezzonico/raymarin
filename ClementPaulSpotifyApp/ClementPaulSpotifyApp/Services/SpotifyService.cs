using System;
using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace ClementPaulSpotifyApp.Service
{
    public class SpotifyService
    {
        const string TokenSpotify = "MON_TOKEN";
        private SpotifyClient _spotifyClient;
        #region Instance
        public static SpotifyService Instance { get; } = new SpotifyService();
        #endregion

        public async Task<bool> ConnectSpotify()
        {
            try
            {
                _spotifyClient = new SpotifyClient(TokenSpotify);
                return await Task.FromResult(true);
            }
            catch (Exception)
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