using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using AutoMapper;
using tune.Dtos;
using tune.Models;

namespace tune.Controllers.Api
{
    public class AlbumsController : ApiController
    {
        private ApplicationDbContext _context;

        public AlbumsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<AlbumDto> GetAlbums()
        {
            return _context.Albums
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Album, AlbumDto>);
        }

        public IHttpActionResult GetAlbum(int id)
        {
            var album = _context.Albums.SingleOrDefault(c => c.Id == id);

            if (album == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Album, AlbumDto>(album));
        }

        [HttpPost]
        public IHttpActionResult CreateAlbum(AlbumDto albumDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var album = Mapper.Map<AlbumDto, Album>(albumDto);
            _context.Albums.Add(album);
            _context.SaveChanges();

            albumDto.Id = album.Id;
            return Created(new Uri(Request.RequestUri + "/" + album.Id), albumDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateAlbum(int id, AlbumDto albumDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var albumInDb = _context.Albums.SingleOrDefault(c => c.Id == id);

            if (albumInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(albumDto, albumInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAlbum(int id)
        {
            var albumInDb = _context.Albums.SingleOrDefault(c => c.Id == id);


            if (albumInDb == null)
            {
                return NotFound();
            }

            _context.Albums.Remove(albumInDb);
            _context.SaveChanges();


            return Ok();
        }
    }
}
