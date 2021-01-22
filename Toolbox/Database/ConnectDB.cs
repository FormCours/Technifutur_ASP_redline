using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox.Database
{
    public class ConnectDB
    {
        private string _ConnectionString;

        public ConnectDB(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentOutOfRangeException("La chaine de connexion n'est pas valide !");

            this._ConnectionString = connectionString;
        }

        /// <summary>
        /// Permet de générer un objet de connexion vers la DB
        /// </summary>
        /// <returns>Une instance de SqlConnection</returns>
        private SqlConnection createConnection()
        {
            return new SqlConnection(_ConnectionString);
        }

        private SqlCommand createCommand(SqlConnection connection, QueryDB query)
        {
            SqlCommand command = connection.CreateCommand();

            command.CommandType = query.IsProcedure ? CommandType.StoredProcedure : CommandType.Text;
            command.CommandText = query.Request;

            foreach (KeyValuePair<string, object> kvp in query.Parametres)
            {
                // Attention, si la valeur est un "null" C#, il faut le convertir en "Null" pour Database
                SqlParameter paramId = new SqlParameter(kvp.Key, kvp.Value ?? DBNull.Value);
                command.Parameters.Add(paramId);
            }

            return command;
        }

        public int ExecuteNonQuery(QueryDB query)
        {
            using (SqlConnection connection = createConnection())
            {
                using (SqlCommand command = createCommand(connection, query))
                {
                    connection.Open();

                    int nbRow = command.ExecuteNonQuery();
                    return nbRow;
                }
            }
        }

        public object ExecuteScalar(QueryDB query)
        {
            using (SqlConnection connection = createConnection())
            {
                using (SqlCommand command = createCommand(connection, query))
                {
                    connection.Open();

                    object o = command.ExecuteScalar();
                    return (o == DBNull.Value) ? null : o;
                }
            }
        } 

        // TODO: public IEnumerable<...> ExecuteReader (...)
    }
}
