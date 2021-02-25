using Bertoni.Core.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bertoni.Web.DataSource.API
{
    //This class will be resolved by the framework. Previously injected in the startup class.  
    public class BertoniApiDataSource : IAlbumDataSource
    {
        private readonly string _bertoniApiURL;
        public BertoniApiDataSource(IConfiguration config)
        {
            _bertoniApiURL = config["BertoniApiURL"];
        }
        public async Task<IEnumerable<Album>> GetAlbums()
        {
         

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_bertoniApiURL); 
            HttpResponseMessage response = await client.GetAsync("GetAlbumes");
            response.EnsureSuccessStatusCode();
            var newValue = await response.Content.ReadAsAsync<IEnumerable<Album>>();
            return newValue;
        }

        public async  Task<IEnumerable<Comments>> GetComments(int postId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_bertoniApiURL);
            HttpResponseMessage response = await client.GetAsync($"GetComments?postId={postId}" );
            response.EnsureSuccessStatusCode();
            var newValue = await response.Content.ReadAsAsync<IEnumerable<Comments>>();
            return newValue;
        }

        public async Task<IEnumerable<Photo>> GetPhotos(int albumId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_bertoniApiURL);
            HttpResponseMessage response = await client.GetAsync($"GetPhotos?albumId={albumId}");
            response.EnsureSuccessStatusCode();
            var newValue = await response.Content.ReadAsAsync<IEnumerable<Photo>>();
            return newValue;
        }

       
    }
}
