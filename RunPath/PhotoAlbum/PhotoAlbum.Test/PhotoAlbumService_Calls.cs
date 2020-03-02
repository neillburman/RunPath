using Moq;
using NUnit.Framework;
using PhotoAlbum.Api.Model;
using System;
using System.Collections.Generic;

namespace PhotoAlbum.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetPhotos_ShouldReturnCorrectNumber()
        {

            //Arrange
            var jsonStringPhotos = "[\n {\n  \"albumId\": 1,\n    \"id\": 1,\n    \"title\": \"accusamus beatae ad facilis cum similique qui sunt\",\n    \"url\": \"https://via.placeholder.com/600/92c952\",\n    \"thumbnailUrl\": \"https://via.placeholder.com/150/92c952\"\n  } \n]";
            var jsonStringAlbums = "[\n {\n  \"userId\": 1,\n    \"id\": 1,\n    \"title\": \"quidem molestiae enim\"\n  } \n]";

            var mockPhotoService = new PhotoAlbumService(jsonStringPhotos, jsonStringAlbums);

            //Act
            var result = mockPhotoService.GetPhotos();

            //Assert
            Assert.AreEqual(result.Count, 1, "One row is returned");
          }
        [Test]
        public void GetAlbums_ShouldReturnCorrectNumber()
        {

            ////Arrange
            var jsonStringPhotos = "[\n {\n  \"albumId\": 1,\n    \"id\": 1,\n    \"title\": \"accusamus beatae ad facilis cum similique qui sunt\",\n    \"url\": \"https://via.placeholder.com/600/92c952\",\n    \"thumbnailUrl\": \"https://via.placeholder.com/150/92c952\"\n  } \n]";
            var jsonStringAlbums = "[\n {\n  \"userId\": 1,\n    \"id\": 1,\n    \"title\": \"quidem molestiae enim\"\n  } \n]";

            //Act
            var mockPhotoService = new PhotoAlbumService(jsonStringPhotos, jsonStringAlbums);

            var result = mockPhotoService.GetAlbums();

            //Assert
            Assert.AreEqual(result.Count, 1, "One row is returned");
        }

        [Test]
        public void GetAlbums_ShouldGetUserPhotoAlbums()
        {

            ////Arrange
            var jsonStringPhotos = "[\n {\n  \"albumId\": 1,\n    \"id\": 1,\n    \"title\": \"accusamus beatae ad facilis cum similique qui sunt\",\n    \"url\": \"https://via.placeholder.com/600/92c952\",\n    \"thumbnailUrl\": \"https://via.placeholder.com/150/92c952\"\n  } \n]";
            var jsonStringAlbums = "[\n {\n  \"userId\": 1,\n    \"id\": 1,\n    \"title\": \"quidem molestiae enim\"\n  } \n]";

            //Act
            var mockPhotoService = new PhotoAlbumService(jsonStringPhotos, jsonStringAlbums);

            var result = mockPhotoService.GetUserPhotoAlbums(1);

            int i = 0;
            foreach (var item in result)
            {
                i++;
            }

            //Assert
            Assert.AreEqual(i, 1, "One row is returned");
       

            
           
        }

        //string jsonStringPhotos = "[{ "albumId":1,"id":1,"title":"accusamus beatae ad facilis cum similique qui sunt","url":"https://via.placeholder.com/600/92c952","thumbnailUrl":"https://via.placeholder.com/150/92c952"}]";
        // var controller = new SimpleProductController(testProducts);

        //var result = controller.GetAllProducts() as List<Product>;
        //Assert.AreEqual(testProducts.Count, result.Count);
        //List<AlbumApi> photos = new List<AlbumApi>
        //{
        //        new AlbumApi  {UserId   = 1, Id  = 10, Title  = "Title 1" },
        //        new AlbumApi  {UserId   = 2, Id  = 20, Title  = "Title 2" }
        //};

        ////var mockPhotoAlbumService = new Mock<IPhotoAlbumService>();
        ////mockPhotoAlbumService.Setup(x => x.GetAlbums()).Returns(() => photos);
        //var sut = new PhotoAlbumService();

        ////Act
        //var testphotos = new mockPhotoAlbumService();.Object.GetPhotos();

        ////Assert

        //Assert.AreEqual(2, testphotos.Count, "Numbers Match");


 
    }
}