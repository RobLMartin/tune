using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tune.Models;
using tune.ViewModels;
using tune.Migrations;

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

        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new AlbumFormViewModel
            {
                Genres = genres
            };

            return View("AlbumForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var album = _context.Albums.SingleOrDefault(c => c.Id == id);

            if (album == null)
            {
                return HttpNotFound();
            }

            var viewModel = new AlbumFormViewModel(album)
            {
                Genres = _context.Genres.ToList()
            };

            return View("AlbumForm", viewModel);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Album album)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AlbumFormViewModel(album)
                {
                    Genres = _context.Genres.ToList()
                };
                
                return View("AlbumForm", viewModel);
            }

            if (album.Id == 0)
            {
                album.DateAdded = DateTime.Now;
                _context.Albums.Add(album);
            }
            else
            {
                var albumInDb = _context.Albums.Single(m => m.Id == album.Id);
                albumInDb.Name = album.Name;
                albumInDb.GenreId = album.GenreId;
                albumInDb.NumberInStock = album.NumberInStock;
                albumInDb.ReleaseDate = album.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Albums");
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