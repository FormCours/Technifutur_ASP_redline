
using Demo_Redline_ASPMVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Redline_ASPMVC.DAL.Repositories
{
    /*
    public class GenreRepository : IRepository<long, Genre>
    {
        // Se connecter la DB
        private string _ConnectionString;

        public GenreRepository()
        {
            _ConnectionString = @"Server=DESKTOP-CE6MM13\SQLEXPRESS;Database=Demo_Redline_ASPMVC;Trusted_Connection=True;";
        }

        // Méthode du CRUD

        #region Premiere version du GetGall
        //public IEnumerable<Genre> GetAll()
        //{
        //    // Pour se connecter à SLQ server
        //    SqlConnection connection = new SqlConnection(_ConnectionString);

        //    // Creation de la commande SQL
        //    SqlCommand command = connection.CreateCommand();

        //    command.CommandType = System.Data.CommandType.Text;
        //    command.CommandText = "SELECT Id_Genre, Name FROM genre;";

        //    // Ouverture de la connexion
        //    connection.Open();

        //    // Execution de la requete pour obtenir un "reader" => Col/Row
        //    SqlDataReader reader = command.ExecuteReader();

        //    // Parcours des données de la requete
        //    List<Genre> genres = new List<Genre>();
        //    while(reader.Read())
        //    {
        //        // Recuperation des données de la Row
        //        long idGenre = (long)reader["Id_Genre"];
        //        string name = reader["Name"].ToString();

        //        genres.Add(new Genre(idGenre, name));
        //    }

        //    // On ferme de reader et la commande
        //    reader.Close();
        //    command.Dispose();

        //    // Fermeture de la connexion
        //    connection.Close();
        //    connection.Dispose();

        //    return genres;
        //}
        #endregion
        #region Seconde version du GetAll avec "using"
        public IEnumerable<Genre> GetAll()
        {
            // Pour se connecter à SLQ server
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                // Creation de la commande SQL
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT Id_Genre, Name FROM genre;";

                    // Ouverture de la connexion
                    connection.Open();

                    // Execution de la requete pour obtenir un "reader" => Col/Row
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Parcours des données de la requete
                        List<Genre> genres = new List<Genre>();
                        while (reader.Read())
                        {
                            // Recuperation des données de la Row
                            long idGenre = (long)reader["Id_Genre"];
                            string name = reader["Name"].ToString();

                            genres.Add(new Genre(idGenre, name));
                        }

                        return genres;
                    }
                }
            }
        }
        #endregion

        public Genre Get(long key)
        {
            using(SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = $"SELECT Id_Genre, Name FROM Genre WHERE Id_Genre = @id";

                    SqlParameter paramKey = new SqlParameter("@id", key);
                    command.Parameters.Add(paramKey);

                    connection.Open();

                    using(SqlDataReader reader = command.ExecuteReader())
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
            using(SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
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
                        if(reader.Read())
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
            using(SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "DELETE FROM Genre WHERE Id_Genre = @id;";

                    SqlParameter paramId = new SqlParameter("@id", key);
                    command.Parameters.Add(paramId);

                    connection.Open();

                    int nbRow = command.ExecuteNonQuery();

                    return (nbRow == 1);
                }
            }
        }

    }
    */
}
