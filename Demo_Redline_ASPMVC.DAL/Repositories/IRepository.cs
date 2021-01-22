using Demo_Redline_ASPMVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Redline_ASPMVC.DAL.Repositories
{
    // Méthode du CRUD
    public interface IRepository<TKey, TEntity>
        where TEntity: IEntity<TKey>
    {
        // - Create
        TEntity Insert(TEntity entity);

        // - Read
        TEntity Get(TKey key);
        IEnumerable<TEntity> GetAll();

        // - Update
        TEntity Update(TKey key, TEntity entity);

        // - Delete
        bool Delete(TKey key);
    }
}
