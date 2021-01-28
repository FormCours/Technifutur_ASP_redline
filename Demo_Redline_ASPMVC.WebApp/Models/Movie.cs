using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Redline_ASPMVC.WebApp.Models
{
    public class Movie
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string ProductionCompany { get; set; }

        public List<Genre> Genres { get; set; }
    }
}