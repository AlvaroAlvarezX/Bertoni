using Bertoni.Api.Albumes.Models;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bertoni.Api.Albumes.Querys
{
    public class Q_GetAlbumes : IRequest<IEnumerable<Models.Album>>
    {

    }

    public class C_GetAlbumes : IRequestHandler<Q_GetAlbumes, IEnumerable<Models.Album>>
    {
        IConfiguration _config;
        public C_GetAlbumes(IConfiguration config)
        {
            _config = config;
        }
        public async Task<IEnumerable<Album>> Handle(Q_GetAlbumes request, CancellationToken cancellationToken)
        {
            var url = _config["AlbumesURL"];

            HttpClient client = new HttpClient();         
            HttpResponseMessage response =  await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var newValue = response.Content.ReadAsAsync<List<Models.Album>>().Result;

            return newValue;
        }
    }
}
