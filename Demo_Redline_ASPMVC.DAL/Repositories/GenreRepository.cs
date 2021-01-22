
using Demo_Redline_ASPMVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Redline_ASPMVC.DAL.Repositories
{
    public class GenreRepository : IRepository<long, Genre>
    {
        // Se connecter la DB
        private string _ConnectionString;

        public GenreRepository()
        {
            _ConnectionString = @"Server=DESKTOP-CE6MM13\SQLEXPRESS;Database=Demo_Redline_ASPMVC;Trusted_Connection=True;";
        }

        // Méthode du CRUD
        public IEnumerable<Genre> getAll()
        {
            // Pour se connecter à SLQ server
            SqlConnection connection = new SqlConnection(_ConnectionString);

            // Creation de la commande SQL
            SqlCommand command = connection.CreateCommand();

            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT Id_Genre, Name FROM genre;";

            // Ouverture de la connexion
            connection.Open();

            // Execution de la requete pour obtenir un "reader" => Col/Row
            SqlDataReader reader = command.ExecuteReader();

            // Parcours des données de la requete
            List<Genre> genres = new List<Genre>();
            while(reader.Read())
            {
                // Recuperation des données de la Row
                long idGenre = (long)reader["Id_Genre"];
                string name = reader["Name"].ToString();

                genres.Add(new Genre(idGenre, name));
            }

            // On ferme de reader et la commande
            reader.Close();
            command.Dispose();

            // Fermeture de la connexion
            connection.Close();
            connection.Dispose();

            return genres;
        }





        public bool delete(long key)
        {
            throw new NotImplementedException();
        }

        public Genre get(long key)
        {
            throw new NotImplementedException();
        }

        public Genre insert(Genre entity)
        {
            throw new NotImplementedException();
        }

        public Genre update(long key, Genre entity)
        {
            throw new NotImplementedException();
        }
    }
}
