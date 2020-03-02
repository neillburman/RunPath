using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbum.Api.Model
{
    public class AlbumApi
    {
        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title
        {
            get; set;
        }
    }
}
