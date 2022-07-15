using Models;                                                                  //The Connection Factory allows us to invoke connection string where we would like,
using System.Data.SqlClient;                                                   //without having to stress about creating new instances every time we want it.

namespace DataAccess
{
    public class ConnectionFactory
    {
        private static ConnectionFactory? _instance;                           //Private static field to hold the one instance we make
        private readonly string _connectionString;                             //The actual connection to DB we are holding

        private ConnectionFactory(string connectionString)                     //Private Connection Factory Constructor
        {
            _connectionString = connectionString;
        }

        public static ConnectionFactory GetInstance(string connectionString)   //Getter that returns connectionString
        {
            if(_instance == null)                                               
            {
                _instance = new ConnectionFactory(connectionString);           //Either generates the instance...
            }
            return _instance;                                                  //Or provides the existing one.
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}