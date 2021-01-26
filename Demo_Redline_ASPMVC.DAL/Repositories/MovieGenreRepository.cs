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
    public class MovieGenreRepository : RepositoryBase<long, MovieGenre>
    {
        public override bool Delete(long key)
        {
            QueryDB query = new QueryDB("DELETE FROM Movie_Genre WHERE Id_MovieGenre = @Id");
            query.AddParametre("@Id", key);

            return (Connector.ExecuteNonQuery(query) == 1);
        }

        public override MovieGenre Get(long key)
        {
            QueryDB query = new QueryDB("SELECT * FROM Movie_Genre WHERE Id_MovieGenre = @Id");
            query.AddParametre("@Id", key);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        public override IEnumerable<MovieGenre> GetAll()
        {
            QueryDB query = new QueryDB("SELECT * FROM Movie_Genre");

            return Connector.ExecuteReader(query, ConvertReaderToEntity);
        }

        public override MovieGenre Insert(MovieGenre entity)
        {
            QueryDB query = new QueryDB("INSERT INTO Movie_Genre ([Id_Movie],[Id_Genre]) OUTPUT inserted.* VALUES (@idMovie, @idGenre)");
            query.AddParametre("@idMovie", entity.IdMovie);
            query.AddParametre("@idGenre", entity.IdGenre);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        public override MovieGenre Update(long key, MovieGenre entity)
        {
            QueryDB query = new QueryDB("UPDATE Movie_Genre SET [Id_Movie] = @idMovie, [Id_Genre] = @idGenre OUTPUT inserted.* WHERE Id_MovieGenre = @Id");
            query.AddParametre("@Id", key);
            query.AddParametre("@idMovie", entity.IdMovie);
            query.AddParametre("@idGenre", entity.IdGenre);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        protected override MovieGenre ConvertReaderToEntity(SqlDataReader dataReader)
        {
            return new MovieGenre(
                (long)dataReader["Id_MovieGenre"],
                (long)dataReader["Id_Movie"],
                (long)dataReader["Id_Genre"]
            );
        }
    }
}
