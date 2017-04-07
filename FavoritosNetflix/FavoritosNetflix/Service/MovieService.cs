using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using FavoritosNetflix.Models;

namespace FavoritosNetflix.Service
{
    public class MovieService
    {
        private HttpClient _client = new HttpClient();
        private List<Movie> _movies;

        public async Task<List<Movie>> LocalizaFilmesPorAtor(string ator)
        {
            if (string.IsNullOrWhiteSpace(ator))
            {
                return null;
            }
            else
            {
                string url = string.Format("http://netflixroulette.net/api/api.php?actor={0}", ator);
                var response = await _client.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    _movies = new List<Movie>();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var movies = JsonConvert.DeserializeObject<List<Movie>>(content);
                    _movies = new List<Movie>(movies);
                }
                return _movies;
            }
        }
    }
}
