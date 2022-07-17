using Exceptions;
using Models;
using System;
using System.Data;
using System.Data.SqlClient; //to use this I need to go to git and use command 'git add package System.Data.SqlClient'

namespace DataAccess
{
    public class UserRepository : IUserDAO
    {
        private readonly ConnectionFactory _connectionFactory;
        /*I don't know if I need this anymore... I don't think I do
        public UserRepository()
        {
            _connectionFactory = ConnectionFactory.GetInstance(File.ReadAllText("../DataAccess/connectionString.txt"));
        }
        */
        public UserRepository(ConnectionFactory factory)
        {
            _connectionFactory = factory;
        }
        
        public List<Users> GetAllUsers()
        {
            List<Users> usersInRepo = new List<Users>();
        
            string queryString = "select * from Lor_P1.users;";

            SqlConnection dbConnect = _connectionFactory.GetConnection();

            SqlCommand returnUsers = new SqlCommand(queryString, dbConnect);             //datatype for the active connection

            try
            {
                dbConnect.Open();                                                        //opens connection to the database
                SqlDataReader reader = returnUsers.ExecuteReader();                      //Stores the result set of a SQL statement into a variable 
                while (reader.Read())
                {
                    Users testUser = new Users();

                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}", reader[0], reader[1], reader[2], reader[3], reader[4]);//based on number of columns!!!!
                    usersInRepo.Add(new Users
                    (
                     (int)reader[0],
                     (string)reader[1],
                     (string)reader[2],
                     (string)reader[3],
                     testUser.StringToRole((string)reader["role"])
                    ));
                }
                reader.Close();                                                           //closees connection to the database.
                dbConnect.Close();                                                        //closes connection to server.
            }
            catch (Exception ex)                                                          //If the connection fails.
            {
                Console.WriteLine(ex.Message);                                            //Displays error message.
            }
            return usersInRepo;                                                           //Keeps content displayed until exit.
        }

        public Users GetUserByUserName(string userName)                             //Method to search for user by their username.
        {
            string queryString = "select * from Lor_P1.users where username = @userName;";

            SqlConnection dbConnect = _connectionFactory.GetConnection();

            SqlCommand userSearch = new SqlCommand(queryString, dbConnect);

            userSearch.Parameters.AddWithValue("@userName", userName);

            Users testUser = new Users();

            try
            {
                dbConnect.Open();
                SqlDataReader reader = userSearch.ExecuteReader(); 
                while(reader.Read())
                {
                    return new Users
                    {
                        userId = (int)reader["user_ID"],
                        userName = (string)reader["username"],
                        password = (string)reader["password"],
                        role = testUser.StringToRole((string)reader["role"])
                    };
                }
                reader.Close();                                                           //closees connection to the database.
                dbConnect.Close();                                                        //closes connection to server.
            }
            catch                                                          //If the connection fails.
            {
                throw new InvalidCredentials("Information provided was not in an acceptable format.");//Displays error message.
            }
            return testUser;
        }

        public Users GetUserByUserId(int userId)                                        //Method to search for user by their userId.
        {
            string queryString = "select * from Lor_P1.users where userId = @userId;";

            SqlConnection dbConnect = _connectionFactory.GetConnection();

            SqlCommand userSearch = new SqlCommand(queryString, dbConnect);

            userSearch.Parameters.AddWithValue("@userId", userId);

            Users testUser = new Users();

            try
            {
                dbConnect.Open();
                SqlDataReader reader = userSearch.ExecuteReader(); 
                while(reader.Read())
                {
                    return new Users
                    {
                        userId = (int)reader["user_ID"],
                        userName = (string)reader["username"],
                        password = (string)reader["password"],
                        role = testUser.StringToRole((string)reader["role"])
                    };
                }
                reader.Close();                                                           //closees connection to the database.
                dbConnect.Close();                                                        //closes connection to server.
            }
            catch                                                          //If the connection fails.
            {
                throw new InvalidCredentials("Information provided was not in an acceptable format.");//Displays error message.
            }
            return testUser;
        }

        public bool RegisterUser(Users newUser)                                              //Method to register a user.
        {                                                                                 //*below* SQL Command to enter record information.
            string sqlStmnt = "insert into Lor_P1.users (legalName, userName, password, role) values (@legalName, @userName, @password, @role);";

            SqlConnection dbConnect = _connectionFactory.GetConnection();                 //Invoking our instance of the Connection Factory.
            
            SqlCommand registerUser = new SqlCommand(sqlStmnt, dbConnect);                //Defining the registerUser methods and arguments.

            registerUser.Parameters.AddWithValue("@legalName,", newUser.legalName); 
            registerUser.Parameters.AddWithValue("@userName", newUser.userName);
            registerUser.Parameters.AddWithValue("@password", newUser.password);
            registerUser.Parameters.AddWithValue("@role", newUser.RoleToString(newUser.role));

            try
            {
                dbConnect.Open();                                                        //Opening the connection to the database.
                
                int rowsAffected = registerUser.ExecuteNonQuery();                       //Execute non query will be for DML statements.

                dbConnect.Close();                                                       //Closing connection tot he database.

                if(rowsAffected != 0)                                                    //Returns true provided the values entered were *not* null.
                {
                    return true;
                }
            }

            catch
            {
                throw new InvalidCredentials("Information provided was not in an acceptable format."); 
            }

            return false;
        }
    }
}