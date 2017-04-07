using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FavoritosNetflix.Models
{
    public class Movie
    {
        [JsonProperty("show_title")]
        public string Title { get; set; }
        [JsonProperty("release_year")]
        public int ReleaseYear { get; set; }
        [JsonProperty("poster")]
        public string ImageUrl { get; set; }
        [JsonProperty("summary")]
        public string Summary { get; set; }
    }
}
