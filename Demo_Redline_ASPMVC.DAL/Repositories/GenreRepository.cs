
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
    public class GenreRepository : RepositoryBase<long, Genre>
    {
        protected override Genre ConvertReaderToEntity(SqlDataReader dataReader)
        {
            return new Genre(
                (long)dataReader["Id_Genre"],
                dataReader["Name"].ToString()
            );
        }

        // Méthode du CRUD
        public override IEnumerable<Genre> GetAll()
        {
            QueryDB query = new QueryDB("SELECT Id_Genre, Name FROM genre;");

            //Func<SqlDataReader, Genre> del = dataReader => new Genre(
            //    (long)dataReader["Id_Genre"],
            //    dataReader["Name"].ToString()
            //);

            return Connector.ExecuteReader<Genre>(query, ConvertReaderToEntity);
        }

        public override Genre Get(long key)
        {
            QueryDB query = new QueryDB("SELECT Id_Genre, Name FROM Genre WHERE Id_Genre = @id");
            query.AddParametre("@id", key);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        public override Genre Insert(Genre entity)
        {
            string sql = "INSERT INTO [Genre] (Name)"
                        + " OUTPUT inserted.Id_Genre, inserted.Name"
                        + " VALUES (@name)";

            QueryDB query = new QueryDB(sql);
            query.AddParametre("@name", entity.Name);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        public override Genre Update(long key, Genre entity)
        {
            string sql = "UPDATE Genre"
                        + " SET [Name] = @name"
                        + " OUTPUT inserted.Id_Genre, inserted.Name"
                        + " WHERE [Id_Genre] = @id";

            QueryDB query = new QueryDB(sql);
            query.AddParametre("@id", entity.Id);
            query.AddParametre("@name", entity.Name);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        public override bool Delete(long key)
        {
            QueryDB query = new QueryDB("DELETE FROM Genre WHERE Id_Genre = @id;");
            query.AddParametre("@id", key);

            int nbRow = Connector.ExecuteNonQuery(query);
            return (nbRow == 1);
        }

        public int GetNumberOfGenre()
        {
            QueryDB query = new QueryDB("SELECT COUNT(*) FROM Genre;");

            int nbGenre = (int)Connector.ExecuteScalar(query);
            return nbGenre;
        }
    }
}
