using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PhotoAlbum.Api.Model
{
    public class PhotoAlbumService : IPhotoAlbumService
    {
        private readonly string jsonStringPhotos;

        public readonly string jsonStringAlbums;


        public PhotoAlbumService()
        {
            using (var webClient = new WebClient())
            {
                this.jsonStringPhotos = webClient.DownloadString("http://jsonplaceholder.typicode.com/photos");
                this.jsonStringAlbums = webClient.DownloadString("http://jsonplaceholder.typicode.com/albums");

            }
        }

        public PhotoAlbumService(string testJsonStringPhotos, string testJsonStringAlbums)
        {
            this.jsonStringPhotos = testJsonStringPhotos;
            this.jsonStringAlbums = testJsonStringAlbums;

        }

        public List<PhotoApi> GetPhotos()
        {

            var photos = JsonConvert.DeserializeObject<List<PhotoApi>>(this.jsonStringPhotos);

            return photos;

        }

        public List<AlbumApi> GetAlbums()
        {
            var albums = JsonConvert.DeserializeObject<List<AlbumApi>>(this.jsonStringAlbums);

            return albums;
        }


        public IEnumerable<PhotoAlbumResponse> GetUserPhotoAlbums(int Id)
        {
            var photos = JsonConvert.DeserializeObject<List<PhotoApi>>(jsonStringPhotos);

            var albums = JsonConvert.DeserializeObject<List<AlbumApi>>(jsonStringAlbums);

            var query = from photo in photos
                        join album in albums on photo.AlbumId equals album.Id
                        where album.Id == Id
                        select new PhotoAlbumResponse { PhotoTitle = photo.Title, AlbumUserId = album.UserId.ToString() };
            return query;
        }
    }
}
