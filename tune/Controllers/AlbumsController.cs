using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tune.Models;
using tune.ViewModels;

namespace tune.Controllers
{
    public class AlbumsController : Controller
    {
        private ApplicationDbContext _context;

        public AlbumsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var albums = _context.Albums.Include(a => a.Genre).ToList();

            return View(albums);
        }

        public ActionResult Details(int id)
        {
            var album = _context.Albums.Include(m => m.Genre).SingleOrDefault(a => a.Id == id);

            if (album == null)
            {
                return HttpNotFound();
            }

            return View(album);
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