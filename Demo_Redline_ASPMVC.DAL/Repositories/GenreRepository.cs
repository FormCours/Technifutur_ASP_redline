
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
    public class GenreRepository : IRepository<long, Genre>
    {
        // Se connecter la DB
        ConnectDB conector;
        private string _ConnectionString;

        public GenreRepository()
        {
            _ConnectionString = @"Server=DESKTOP-CE6MM13\SQLEXPRESS;Database=Demo_Redline_ASPMVC;Trusted_Connection=True;";
            conector = new ConnectDB(_ConnectionString);
        }

        private Genre ConvertReaderToGenre(SqlDataReader dataReader)
        {
            return new Genre(
                (long)dataReader["Id_Genre"],
                dataReader["Name"].ToString()
            );
        }

        // Méthode du CRUD
        public IEnumerable<Genre> GetAll()
        {
            QueryDB query = new QueryDB("SELECT Id_Genre, Name FROM genre;");

            //Func<SqlDataReader, Genre> del = dataReader => new Genre(
            //    (long)dataReader["Id_Genre"],
            //    dataReader["Name"].ToString()
            //);

            return conector.ExecuteReader<Genre>(query, ConvertReaderToGenre);
        }

        // TODO: Simplifier les méthodes Get, Insert et Update !

        public Genre Get(long key)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = $"SELECT Id_Genre, Name FROM Genre WHERE Id_Genre = @id";

                    SqlParameter paramKey = new SqlParameter("@id", key);
                    command.Parameters.Add(paramKey);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Genre genre = null;
                        if (reader.Read())
                        {
                            genre = new Genre(
                                (long)reader["Id_Genre"],
                                reader["Name"].ToString()
                            );
                        }
                        return genre;
                    }
                }
            }
        }

        public Genre Insert(Genre entity)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "INSERT INTO [Genre] (Name)"
                                        + " OUTPUT inserted.Id_Genre, inserted.Name"
                                        + " VALUES (@name)";

                    command.Parameters.AddWithValue("@name", entity.Name);


                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new Genre(
                            (long)reader["Id_Genre"],
                            reader["Name"].ToString()
                        );
                    }
                }
            }
        }

        public Genre Update(long key, Genre entity)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "UPDATE Genre"
                                        + " SET [Name] = @name"
                                        + " OUTPUT inserted.Id_Genre, inserted.Name"
                                        + " WHERE [Id_Genre] = @id";

                    command.Parameters.AddWithValue("@name", entity.Name);
                    command.Parameters.AddWithValue("@id", key);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Genre genre = null;
                        if (reader.Read())
                        {
                            genre = new Genre(
                                (long)reader["Id_Genre"],
                                reader["Name"].ToString()
                            );
                        }
                        return genre;
                    }
                }
            }
        }

        public bool Delete(long key)
        {
            QueryDB query = new QueryDB("DELETE FROM Genre WHERE Id_Genre = @id;");
            query.AddParametre("@id", key);

            int nbRow = conector.ExecuteNonQuery(query);
            return (nbRow == 1);
        }

        public int GetNumberOfGenre()
        {
            QueryDB query = new QueryDB("SELECT COUNT(*) FROM Genre;");

            int nbGenre = (int)conector.ExecuteScalar(query);
            return nbGenre;
        }

    }
}
