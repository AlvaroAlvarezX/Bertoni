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

    public class AlbumesController : ApiController
    {
        [HttpGet]
        [Route("GetAlbumes")]
        public async Task<IEnumerable<Album>> GetAlbumes()
        {
            return await Mediator.Send(new Q_GetAlbumes());
        }

        [HttpGet]
        [Route("GetPhotos")]
        public async Task<IEnumerable<Photo>> GetPhotos(int albumId)
        {
            return await Mediator.Send(new Q_GetFotos() { AlbumID = albumId });
        }

        [HttpGet]
        [Route("GetComments")]
        public async Task<IEnumerable<Comments>> GetComments(int postId)
        {
            return await Mediator.Send(new Q_GetComentarios() { PostId = postId });
        }
    }
}
