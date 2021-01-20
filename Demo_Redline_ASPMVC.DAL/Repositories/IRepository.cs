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
        TEntity insert(TEntity entity);

        // - Read
        TEntity get(TKey key);
        IEnumerable<TEntity> getAll();

        // - Update
        TEntity update(TKey key, TEntity entity);

        // - Delete
        bool delete(TKey key);
    }
}
