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
    public class Q_GetComentarios : IRequest<IEnumerable<Comments>>
    {
        public int PostId { get; set; }
    }

    public class C_GetFotos : IRequestHandler<Q_GetComentarios, IEnumerable<Comments>>
    {
        IConfiguration _config;
        public C_GetFotos(IConfiguration config)
        {
            _config = config;
        }
        public async Task<IEnumerable<Comments>> Handle(Q_GetComentarios request, CancellationToken cancellationToken)
        {
            var url = _config["CommentsURL"];

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var newValue = response.Content.ReadAsAsync<List<Comments>>().Result;

            return newValue;
        }


    }
}
