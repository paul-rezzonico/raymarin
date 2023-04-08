using System;
using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace ClementPaulSpotifyApp.Service
{
    public class SpotifyService
    {
        const string TokenSpotify = "BQDiCPgTi7WpqVpuVW0DoD5u2-9Q8UTw0Mqu9wuILO3EisjfHm9UZZjqc2gFzMWTE-EjgS7-9aK6yvSgkfAsQ8nJeehOeX6YISVgNC-jSgyUZAfvpm9E";
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