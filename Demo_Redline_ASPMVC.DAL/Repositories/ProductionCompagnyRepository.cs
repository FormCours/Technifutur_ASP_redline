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
    public class ProductionCompagnyRepository : RepositoryBase<long, ProductionCompagny>
    {
        public override bool Delete(long key)
        {
            QueryDB query = new QueryDB("DELETE FROM ProductionCompagny WHERE Id_ProductionCompagny = @Id");
            query.AddParametre("@Id", key);

            return (Connector.ExecuteNonQuery(query) == 1);
        }

        public override ProductionCompagny Get(long key)
        {
            QueryDB query = new QueryDB("SELECT * FROM ProductionCompagny WHERE Id_ProductionCompagny = @Id");
            query.AddParametre("@Id", key);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        public override IEnumerable<ProductionCompagny> GetAll()
        {
            QueryDB query = new QueryDB("SELECT * FROM ProductionCompagny");

            return Connector.ExecuteReader(query, ConvertReaderToEntity);
        }

        public override ProductionCompagny Insert(ProductionCompagny entity)
        {
            QueryDB query = new QueryDB("INSERT INTO ProductionCompagny (Name) OUTPUT inserted.* VALUES (@name)");
            query.AddParametre("@name", entity.Name);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        public override ProductionCompagny Update(long key, ProductionCompagny entity)
        {
            QueryDB query = new QueryDB("UPDATE ProductionCompagny SET Name = @name OUTPUT inserted.* WHERE Id_ProductionCompagny = @Id");
            query.AddParametre("@Id", key);
            query.AddParametre("@name", entity.Name);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        protected override ProductionCompagny ConvertReaderToEntity(SqlDataReader dataReader)
        {
            return new ProductionCompagny(
                (long)dataReader["Id_ProductionCompagny"],
                dataReader["Name"].ToString()
            );
        }
    }
}
