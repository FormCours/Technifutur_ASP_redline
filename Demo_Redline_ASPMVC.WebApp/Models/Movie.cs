using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Demo_Redline_ASPMVC.WebApp.Models
{
    public class Movie
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }

        [Display(Name ="Titre")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Résumé")]
        [DisplayFormat(NullDisplayText ="---")]
        public string Resume { get; set; }

        [Display(Name ="Durée")]
        [DisplayFormat(NullDisplayText ="---")]
        public int? Duration { get; set; }

        [Display(Name ="Date de sortie")]
        [DisplayFormat(NullDisplayText = "---", DataFormatString ="{0:dd MMM yyyy}")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name ="Compagnie de production")]
        [Required]
        public string ProductionCompany { get; set; }

        [Display(Name ="Genre")]
        public List<Genre> Genres { get; set; }

        [Display(Name= "Affiche")]
        public string Picture { get; set; }
    }
}