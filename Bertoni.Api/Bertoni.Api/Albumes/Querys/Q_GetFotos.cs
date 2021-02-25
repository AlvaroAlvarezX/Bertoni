
using Bertoni.Core.Models;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
namespace Bertoni.Api.Fotos.Querys
{
    public class Q_GetFotos  : IRequest<IEnumerable<Photo>>
    {
        public int AlbumID { get; set; }
    }

    public class C_GetFotos : IRequestHandler<Q_GetFotos, IEnumerable<Photo> >
    {
        IConfiguration _config;
        public C_GetFotos(IConfiguration config)
        {
            _config = config;
        }
        public async Task<IEnumerable<Photo>> Handle(Q_GetFotos request, CancellationToken cancellationToken)
        {
            var url = _config["FotosURL"];

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var newValue = await response.Content.ReadAsAsync<List<Photo>>();

            return newValue.Where(x => x.AlbumID == request.AlbumID).ToList(); ;
        }
    }
}
