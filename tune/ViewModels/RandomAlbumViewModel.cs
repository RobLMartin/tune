using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tune.Models;

namespace tune.ViewModels
{
    public class RandomAlbumViewModel
    {
        public Album Album { get; set; }
        public List<Customer> Customers { get; set; }
    }
}