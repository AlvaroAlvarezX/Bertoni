using Bertoni.Api.Albumes.Models;
using Bertoni.Api.Albumes.Querys;
using Bertoni.Api.Fotos.Querys;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bertoni.Api.Controllers
{

    public class AlbumController : ApiController
    {
        public async Task<IEnumerable<Album>> Index()
        {
            return await Mediator.Send(new Q_GetAlbumes());
        }

        public async Task<IEnumerable<Photo>> Photos(int albumId)
        {
            return await Mediator.Send(new Q_GetFotos() { AlbumID = albumId });
        }

        public async Task<IEnumerable<Comments>> Comments(int postId)
        {
            return await Mediator.Send(new Q_GetComentarios() { PostId = postId });
        }
    }
}
