using Demo_Redline_ASPMVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Database;

namespace Demo_Redline_ASPMVC.DAL.Repositories
{
    public abstract class RepositoryBase<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity: IEntity<TKey>
    {
        private ConnectDB _Connector;
        private string _ConnectionString;

        protected ConnectDB Connector
        {
            get { return _Connector; }
        }

        public RepositoryBase()
        {
            _ConnectionString = @"Server=DESKTOP-CE6MM13\SQLEXPRESS;Database=Demo_Redline_ASPMVC;Trusted_Connection=True;";
            _Connector = new ConnectDB(_ConnectionString);
        }

        protected abstract TEntity ConvertReaderToEntity(SqlDataReader dataReader);

        public abstract TEntity Get(TKey key);
        public abstract IEnumerable<TEntity> GetAll();
        public abstract TEntity Insert(TEntity entity);
        public abstract TEntity Update(TKey key, TEntity entity);
        public abstract bool Delete(TKey key);
    }
}
