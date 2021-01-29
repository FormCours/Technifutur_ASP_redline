using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Redline_ASPMVC.WebApp.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public Movie LastMovie { get; set; }

    }
}