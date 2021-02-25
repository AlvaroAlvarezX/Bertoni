
using Bertoni.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bertoni.Web.DataSource
{
    public interface IAlbumDataSource
    {
        Task<IEnumerable<Bertoni.Core.Models.Album>> GetAlbums();

        Task<IEnumerable<Comments>> GetComments( int postId);

        Task<IEnumerable<Photo>> GetPhotos(int albumId);

    }
}
