using Bertoni.Web.DataSource;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bertoni.Web.Controllers
{
    public class AlbumController : Controller
    {
        IAlbumDataSource _ds;
        string _apiBaseURL;
        public AlbumController(IAlbumDataSource ds, IConfiguration config)
        {
            _ds = ds;
            _apiBaseURL = config["BertoniApiURL"];
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.URL = _apiBaseURL;
            var albums = await _ds.GetAlbums();
            return View(albums);
        }
    }
}
