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
    public class RoleRepository : RepositoryBase<long, Role>
    {
        public override bool Delete(long key)
        {
            QueryDB query = new QueryDB("DELETE FROM [Role] WHERE Id_Role = @Id");
            query.AddParametre("@Id", key);

            return (Connector.ExecuteNonQuery(query) == 1);
        }

        public override Role Get(long key)
        {
            QueryDB query = new QueryDB("SELECT * FROM [Role] WHERE Id_Role = @Id");
            query.AddParametre("@Id", key);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        public override IEnumerable<Role> GetAll()
        {
            QueryDB query = new QueryDB("SELECT * FROM [Role]");

            return Connector.ExecuteReader(query, ConvertReaderToEntity);
        }

        public override Role Insert(Role entity)
        {
            QueryDB query = new QueryDB("INSERT INTO [Role] ([Name]) OUTPUT inserted.* VALUES (@name)");
            query.AddParametre("@name", entity.Name);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        public override Role Update(long key, Role entity)
        {
            QueryDB query = new QueryDB("UPDATE [Role] SET Name = @name OUTPUT inserted.* WHERE Id_Role = @Id");
            query.AddParametre("@Id", key);
            query.AddParametre("@name", entity.Name);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        protected override Role ConvertReaderToEntity(SqlDataReader dataReader)
        {
            return new Role(
                (long)dataReader["Id_Role"],
                dataReader["Name"].ToString()
            );
        }
    }
}
