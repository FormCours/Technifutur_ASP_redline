using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Redline_ASPMVC.WebApp.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public Movie LastMovie { get; set; }

    }

    public class HomeAddViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public Movie NewMovie { get; set; }
        public List<int> SelectedGenre { get; set; }
    }


    public class HomeMovieViewModel
    {
        public Movie Movie { get; set; }
        public Rating NewRating { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }
    }

}