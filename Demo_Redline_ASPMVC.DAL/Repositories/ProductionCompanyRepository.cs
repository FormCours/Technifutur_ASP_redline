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
    public class ProductionCompanyRepository : RepositoryBase<long, ProductionCompany>
    {
        public override bool Delete(long key)
        {
            QueryDB query = new QueryDB("DELETE FROM ProductionCompany WHERE Id_ProductionCompany = @Id");
            query.AddParametre("@Id", key);

            return (Connector.ExecuteNonQuery(query) == 1);
        }

        public override ProductionCompany Get(long key)
        {
            QueryDB query = new QueryDB("SELECT * FROM ProductionCompany WHERE Id_ProductionCompany = @Id");
            query.AddParametre("@Id", key);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        public override IEnumerable<ProductionCompany> GetAll()
        {
            QueryDB query = new QueryDB("SELECT * FROM ProductionCompany");

            return Connector.ExecuteReader(query, ConvertReaderToEntity);
        }

        public override ProductionCompany Insert(ProductionCompany entity)
        {
            QueryDB query = new QueryDB("INSERT INTO ProductionCompany (Name) OUTPUT inserted.* VALUES (@name)");
            query.AddParametre("@name", entity.Name);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        public override ProductionCompany Update(long key, ProductionCompany entity)
        {
            QueryDB query = new QueryDB("UPDATE ProductionCompany SET Name = @name OUTPUT inserted.* WHERE Id_ProductionCompany = @Id");
            query.AddParametre("@Id", key);
            query.AddParametre("@name", entity.Name);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        protected override ProductionCompany ConvertReaderToEntity(SqlDataReader dataReader)
        {
            return new ProductionCompany(
                (long)dataReader["Id_ProductionCompany"],
                dataReader["Name"].ToString()
            );
        }
    }
}
