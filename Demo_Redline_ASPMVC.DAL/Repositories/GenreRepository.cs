
using Demo_Redline_ASPMVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Redline_ASPMVC.DAL.Repositories
{
    public class GenreRepository : IRepository<long, Genre>
    {
        // Se connecter la DB



        // Méthode du CRUD
        public bool delete(long key)
        {
            throw new NotImplementedException();
        }

        public Genre get(long key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genre> getAll()
        {
            throw new NotImplementedException();
        }

        public Genre insert(Genre entity)
        {
            throw new NotImplementedException();
        }

        public Genre update(long key, Genre entity)
        {
            throw new NotImplementedException();
        }
    }
}
