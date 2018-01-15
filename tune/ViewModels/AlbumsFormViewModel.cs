using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using tune.Models;

namespace tune.ViewModels
{
    public class AlbumFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1,20)]
        public byte? NumberInStock { get; set; }
        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public AlbumFormViewModel()
        {
            Id = 0;
        }

        public AlbumFormViewModel(Album album)
        {
            Id = album.Id;
            Name = album.Name;
            ReleaseDate = album.ReleaseDate;
            NumberInStock = album.NumberInStock;
            GenreId = album.GenreId;
        }
    }
}