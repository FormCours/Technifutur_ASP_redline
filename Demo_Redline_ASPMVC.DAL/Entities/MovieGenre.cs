using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Redline_ASPMVC.DAL.Entities
{
    public class MovieGenre : IEntity<long>
    {
        public long Id { get; set; }
        public long IdMovie { get; set; }
        public long IdGenre { get; set; }

        public MovieGenre(long idMovie, long idGenre)
        {
            this.Id = 0;
            this.IdMovie = idMovie;
            this.IdGenre = idGenre;
        }

        internal MovieGenre(long id, long idMovie, long idGenre)
            : this(idMovie, idGenre)
        {
            this.Id = id;
        }
    }
}
