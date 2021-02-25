using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bertoni.Core.Models
{
    public class Photo
    {
        public int AlbumID { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }
        public string ThumbnailURL { get; set; }
        public string Url { get; set; }
    }
}
