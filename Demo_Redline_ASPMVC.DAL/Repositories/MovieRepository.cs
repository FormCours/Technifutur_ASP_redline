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
    public class MovieRepository : RepositoryBase<long, Movie>
    {
        public override bool Delete(long key)
        {
            QueryDB query = new QueryDB("DELETE FROM Movie WHERE Id_Movie = @Id");
            query.AddParametre("@Id", key);

            return (Connector.ExecuteNonQuery(query) == 1);
        }

        public override Movie Get(long key)
        {
            QueryDB query = new QueryDB("SELECT * FROM Movie WHERE Id_Movie = @Id");
            query.AddParametre("@Id", key);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        public override IEnumerable<Movie> GetAll()
        {
            QueryDB query = new QueryDB("SELECT * FROM Movie");

            return Connector.ExecuteReader(query, ConvertReaderToEntity);
        }

        public Movie GetLastInsert()
        {
            QueryDB query = new QueryDB("SELECT TOP(1) * FROM Movie ORDER BY Id_Movie DESC");

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }


        public override Movie Insert(Movie entity)
        {
            QueryDB query = new QueryDB("INSERT INTO Movie ([Title],[Resume],[Duration],[ReleaseDate],[Id_ProductionCompany]) " +
                                        "OUTPUT inserted.* VALUES (@title, @resume, @duration, @relasedate, @idProductionCompagny)");
            query.AddParametre("@title", entity.Title);
            query.AddParametre("@resume", entity.Resume);
            query.AddParametre("@duration", entity.Duration);
            query.AddParametre("@relasedate", entity.ReleaseDate);
            query.AddParametre("@idProductionCompagny", entity.IdProductionCompagny);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        public override Movie Update(long key, Movie entity)
        {
            QueryDB query = new QueryDB("UPDATE Movie " +
                                        "SET [Title] = @title, [Resume] = @resume, [Duration] = @duration, [ReleaseDate] = @relasedate, [Id_ProductionCompany] = @idProductionCompagny" +
                                        " OUTPUT inserted.* WHERE Id_Movie = @Id");
            query.AddParametre("@Id", key);
            query.AddParametre("@title", entity.Title);
            query.AddParametre("@resume", entity.Resume);
            query.AddParametre("@duration", entity.Duration);
            query.AddParametre("@relasedate", entity.ReleaseDate);
            query.AddParametre("@idProductionCompagny", entity.IdProductionCompagny);

            return Connector.ExecuteReader(query, ConvertReaderToEntity).SingleOrDefault();
        }

        protected override Movie ConvertReaderToEntity(SqlDataReader dataReader)
        {
            return new Movie(
                (long)dataReader["Id_Movie"],
                dataReader["Title"].ToString(),
                (dataReader["Resume"] is DBNull) ? null : dataReader["Resume"].ToString(),
                (dataReader["Duration"] is DBNull) ? null : (int?)Convert.ToInt32(dataReader["Duration"]),
                (dataReader["ReleaseDate"] is DBNull) ? null : (DateTime?)Convert.ToDateTime(dataReader["ReleaseDate"]),
                (long)dataReader["Id_ProductionCompany"]
            );
        }
    }
}
