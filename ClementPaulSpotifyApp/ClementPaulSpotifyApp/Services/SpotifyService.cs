using System;
using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace ClementPaulSpotifyApp.Service
{
    public class SpotifyService
    {
        const string TokenSpotify = "BQCyvYqip3k0kOsUrvKuafXAvGwW7QmGY4kDBNuDAhxhtPxjX0JhyT_SSgt4vo1JtyAI_hFphAp5gprfQyZnRdECK41Z_MNSgeQKOh8KH0Oo1s1YCPPc";
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