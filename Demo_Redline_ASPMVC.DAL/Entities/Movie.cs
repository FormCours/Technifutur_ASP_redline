﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Redline_ASPMVC.DAL.Entities
{
    public class Movie : IEntity<long>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Resume { get; set; }
        public int? Duration { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public long IdProductionCompany { get; set; }
        public string Picture { get; set; }

        public Movie(string title, string resume, int? duration, DateTime? releaseDate, long idProductionCompagny, string picture)
        {
            this.Id = 0;
            this.Title = title;
            this.Resume = resume;
            this.Duration = duration;
            this.ReleaseDate = releaseDate;
            this.IdProductionCompany = idProductionCompagny;
            this.Picture = picture;
        }

        internal Movie(long id, string title, string resume, int? duration, DateTime? releaseDate, long idProductionCompagny, string picture)
            : this(title, resume, duration, releaseDate, idProductionCompagny, picture)
        {
            this.Id = id;
        }
    }
}
