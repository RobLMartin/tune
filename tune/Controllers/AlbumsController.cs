using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tune.Models;

namespace tune.Controllers
{
    public class AlbumsController : Controller
    {
        // GET: Album/Random
        public ActionResult Random()
        {
            var album = new Album() { Name = "Fleet Foxes" };

            return View(album);
        }
    }
}