using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Demo_Redline_ASPMVC.WebApp.Models
{
    public class Rating
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }

        [Required]
        [Display(Name = "Score")]
        public double Score { get; set; }

        [Display(Name = "Commentaire")]
        public string Comment { get; set; }

        [Display(Name = "Date d'envoi")]
        public DateTime RatingDate { get; set; }


        [ScaffoldColumn(false)]
        public long IdMovie { get; set; }

        [ScaffoldColumn(false)]
        public long IdMember { get; set; }
    }
}