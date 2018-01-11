using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tune.Models;
using tune.ViewModels;

namespace tune.Controllers
{
    public class AlbumsController : Controller
    {

        public ViewResult Index()
        {
            var albums = GetAlbums();

            return View(albums);
        }

        public ActionResult Details(int id)
        {
            var album = GetAlbums().SingleOrDefault(a => a.Id == id);

            if (album == null)
            {
                return HttpNotFound();
            }

            return View(album);
        }

        private IEnumerable<Album> GetAlbums()
        {
            return new List<Album>
            {
                new Album { Id = 1, Name = "Fleet Foxes - Self Titled" },
                new Album { Id = 2, Name = "Fleet Foxes - Helplessness Blues" },
                new Album { Id = 3, Name = "Fleet Foxes - Crack-Up" },
                new Album { Id = 4, Name = "Radiohead - Moon Shaped Pool" }
            };
        }

        //// GET: Album/Random
        //public ActionResult Random()
        //{
        //    var album = new Album() { Name = "Fleet Foxes" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer { Name = "Rob Martin" },
        //        new Customer { Name = "Jake Cummings" }

        //    };

        //    var viewModel = new RandomAlbumViewModel
        //    {
        //        Album = album,
        //        Customers = customers
        //    };

        //    return View(viewModel);
        //}

    }
}