using System;
using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace ClementPaulSpotifyApp.Service
{
    public class SpotifyService
    {
        const string TokenSpotify = "BQBJS7RtNXE1afLF4rfYlH8Y0MfOPaTzYY1qc4nfHVBBBsI6N_LAubl1T58HpU3l3jh_SeXnMyxbRrrFfAgm1GagrXv8bHW5XoOdGVUpgt5XXcYdvraX";
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