using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Redline_ASPMVC.DAL.Entities
{
    public class Rating : IEntity<long>
    {
        public long Id { get; set; }
        public double Score { get; set; }
        public string Comment { get; set; }
        public DateTime RatingDate { get; set; }
        public long IdMovie { get; set; }
        public long IdMember { get; set; }

        public Rating(double score, string comment, DateTime ratingDate, long idMovie, long idMember)
        {
            this.Id = 0;
            this.Score = score;
            this.Comment = comment;
            this.RatingDate = ratingDate;
            this.IdMovie = IdMovie;
            this.IdMember = IdMember;
        }

        internal Rating(long id, double score, string comment, DateTime ratingDate, long idMovie, long idMember)
            : this(score, comment, ratingDate, idMovie, idMember)
        {
            this.Id = id;
        }
    }
}
