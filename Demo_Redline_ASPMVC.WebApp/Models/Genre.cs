using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Redline_ASPMVC.WebApp.Models
{
    public class Genre
    {
        public long Id { get; set; }

        public string Name { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}