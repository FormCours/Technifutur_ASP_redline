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
        [DisplayFormat(DataFormatString = "{0:f2}")]
        public double Score { get; set; }

        [Display(Name = "Commentaire")]
        [DisplayFormat(NullDisplayText = "---")]
        public string Comment { get; set; }

        [Display(Name = "Date d'envoi")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime RatingDate { get; set; }


        [ScaffoldColumn(false)]
        public Movie Movie { get; set; }

        [ScaffoldColumn(false)]
        public MemberProfil Member { get; set; }
    }
}