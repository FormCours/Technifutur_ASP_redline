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
    public class RatingRepository : RepositoryBase<long, Rating>
    {
        public override bool Delete(long key)
        {
            QueryDB query = new QueryDB("DELETE FROM Rating WHERE Id_Rating = @Id");
            query.AddParametre("@Id", key);

            return (Connector.ExecuteNonQuery(query) == 1);
        }

        public override Rating Get(long key)
        {
            QueryDB query = new QueryDB("SELECT * FROM Rating WHERE Id_Rating = @Id");
            query.AddParametre("@Id", key);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        public IEnumerable<Rating> GetByMovie(long idMovie)
        {
            QueryDB query = new QueryDB("SELECT * FROM Rating WHERE Id_Movie = @IdMovie");
            query.AddParametre("@IdMovie", idMovie);

            return Connector.ExecuteReader(query, ConvertReaderToEntity);
        }

        public override IEnumerable<Rating> GetAll()
        {
            QueryDB query = new QueryDB("SELECT * FROM Rating");

            return Connector.ExecuteReader(query, ConvertReaderToEntity);
        }

        public override Rating Insert(Rating entity)
        {
            QueryDB query = new QueryDB("INSERT INTO Rating ([Score],[Comment],[RatingDate],[Id_Movie],[Id_Member]) " +
                                        "OUTPUT inserted.* VALUES (@score, @comment, @rating, @idMovie, @idMember)");
            query.AddParametre("@score", entity.Score);
            query.AddParametre("@comment", entity.Comment);
            query.AddParametre("@rating", entity.RatingDate);
            query.AddParametre("@idMovie", entity.IdMovie);
            query.AddParametre("@idMember", entity.IdMember);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        public override Rating Update(long key, Rating entity)
        {
            QueryDB query = new QueryDB("UPDATE Rating " +
                                        "SET [Score] = @score, [Comment] = @comment, [RatingDate] = @rating, [Id_Movie] = @idMovie, [Id_Member] = @idMember " + 
                                        "OUTPUT inserted.* WHERE Id_Rating = @Id");
            query.AddParametre("@Id", key);
            query.AddParametre("@score", entity.Score);
            query.AddParametre("@comment", entity.Comment);
            query.AddParametre("@rating", entity.RatingDate);
            query.AddParametre("@idMovie", entity.IdMovie);
            query.AddParametre("@idMember", entity.IdMember);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        protected override Rating ConvertReaderToEntity(SqlDataReader dataReader)
        {
            return new Rating(
                (long)dataReader["Id_Rating"],
                Convert.ToDouble(dataReader["Score"]),
                (dataReader["Comment"] is DBNull) ? null : dataReader["Comment"].ToString(),
                Convert.ToDateTime(dataReader["RatingDate"]),
                (long)dataReader["Id_Movie"],
                (long)dataReader["Id_Member"]
            );
        }
    }
}
