using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoAlbum.Api.Model;

namespace PhotoAlbum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoAlbumController : ControllerBase
    {
        private IPhotoAlbumService _photoAlbumService;
        public PhotoAlbumController(IPhotoAlbumService photoAlbumService)
        {
            //_photoAlbumService = new PhotoAlbumService();
            _photoAlbumService = photoAlbumService;
        }
        [HttpGet]
        [Route("Photo")]
        public IEnumerable<PhotoApi> GetPhotos()
        {
            var photos = _photoAlbumService.GetPhotos();

            return photos.ToArray();

        }

        [HttpGet]
        [Route("Album")]
        public IEnumerable<AlbumApi> GetAlbums()
        {
            var albums = _photoAlbumService.GetAlbums();

            return albums.ToArray();
        }

        [HttpGet("{Id}")]
        public IEnumerable<PhotoAlbumResponse> PhotoAlbum(int Id)
        {
            var photoAlbumResponse = _photoAlbumService.GetUserPhotoAlbums(Id);
            return photoAlbumResponse.ToArray();
        }
    }
}