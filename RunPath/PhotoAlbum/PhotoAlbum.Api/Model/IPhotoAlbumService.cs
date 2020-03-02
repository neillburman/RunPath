using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbum.Api.Model
{
    public interface IPhotoAlbumService
    {
        List<PhotoApi> GetPhotos();
        List<AlbumApi> GetAlbums();
        IEnumerable<PhotoAlbumResponse> GetUserPhotoAlbums(int Id);
    }
}
