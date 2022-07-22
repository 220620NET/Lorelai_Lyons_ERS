using Exceptions;
using Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class UserRepository : IUserDAO
    {
        private readonly ConnectionFactory _connectionFactory;

        public UserRepository(ConnectionFactory factory)
        {
            _connectionFactory = factory;
        }
        
        /// <summary>
        /// Retrieves and displays a list of all users contained in the users table of Lor_P1 database.
        /// Entries below this will have no redundant content information from this method.
        /// </summary>
        /// <param userName="Rather than list all parameter explanations, check 'Users' model class for further explanation on each parameter."></param>
        /// <returns>Returns the collection of information retreived from the tickets table of my database.</returns>
        /// <exception cref="RecordNotFoundException">Displays if there was no information to retrieve from table.</exception>
        public List<Users> GetAllUsers()
        {
            List<Users> usersInRepo = new List<Users>();                  //List will be comprised of table information and displayed at the end.
        
            string queryString = "select * from Lor_P1.users;";           //SQL command to be executed.

            SqlConnection dbConnect = _connectionFactory.GetConnection(); //Invoking connection factory to connect to database.

            SqlCommand returnUsers = new SqlCommand(queryString, dbConnect);//Datatype for the active connection.

            Users userInstance = new Users();                        //Instantiated user to be converted to an integer to fit into class model from DB.
            try
            {
                dbConnect.Open();                                    //Opens connection to the database.
                SqlDataReader reader = returnUsers.ExecuteReader();  //Stores the result set of a SQL statement into a variable .
                while (reader.Read())
                {                                                    //(below) This line displays read information to the console.
                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}", reader[0], reader[1], reader[2], reader[3]);

                    int roleNum = userInstance.RoleToNum((string)reader[4]);

                    usersInRepo.Add(new Users                        //Adding read information from database to list above.
                    (
                     (int)reader[0],
                     (string)reader[1],
                     (string)reader[2],                              //      "      "
                     (string)reader[3],
                     (Role)roleNum
                    ));
                }
                reader.Close();                                      //Closees connection to the database.
                dbConnect.Close();                                   //Closes connection to server.
            }
            catch (Exception ex)                                     //If the connection fails.
            {
                Console.WriteLine(ex.Message);                       //Displays error message.
            }
            return usersInRepo;                                      //Keeps content displayed until exit.
        }

        /// <summary>
        /// Retrieves and displays a list of all users contained in the users table of Lor_P1 database.
        /// </summary>
        /// <param userName="userName"></param>
        /// <returns>returns(user list)</returns>
        /// <exception cref="RecordNotFoundException">exception descriptions</exception>
        public Users GetUserByUserName(string userName)                             //Method to search for user by their username.
        {
            string queryString = "select * from Lor_P1.users where userName = @userName;";

            SqlConnection dbConnect = _connectionFactory.GetConnection();

            SqlCommand userSearch = new SqlCommand(queryString, dbConnect);

            userSearch.Parameters.AddWithValue("@userName", userName);

            Users userInstance = new Users();

            Users functionUser = new Users();

            //try
            //{
                dbConnect.Open();
                SqlDataReader reader = userSearch.ExecuteReader(); 
                reader.Read();
                if(!reader.HasRows)
                {
                    throw new ResourceNotFound();
                }
                else
                {
                    int roleNum = userInstance.RoleToNum((string)reader[4]);

                    userInstance = new Users
                    (
                        (int)reader[0],
                        (string)reader[1],
                        (string)reader[2],
                        (string)reader[3],
                        (Role)roleNum
                    );
                }                    
                reader.Close();                                                           //closees connection to the database.
                dbConnect.Close();                                                        //closes connection to server.
            //}
            /*
            catch                                                          //If the connection fails.
            {
                throw new InvalidCredentials("Information provided was not in an acceptable format.");//Displays error message.
            }
            */
            return userInstance;
        }

        /// <summary>
        /// Retrieves and displays a list of all users contained in the users table of Lor_P1 database.
        /// </summary>
        /// <param userName="userName"></param>
        /// <returns>returns(user list)</returns>
        /// <exception cref="RecordNotFoundException">exception descriptions</exception>
        public Users GetUserByUserId(int userId)                                        //Method to search for user by their userId.
        {
            string queryString = "select * from Lor_P1.users where user_Id = @user_Id;";

            SqlConnection dbConnect = _connectionFactory.GetConnection();

            SqlCommand userSearch = new SqlCommand(queryString, dbConnect);

            userSearch.Parameters.AddWithValue("@user_Id", userId);

            Users userInstance = new Users();

            //try
            //try
            //{
                dbConnect.Open();
                SqlDataReader reader = userSearch.ExecuteReader(); 
                reader.Read();
                if(!reader.HasRows)
                {
                    throw new ResourceNotFound();
                }
                else
                {
                    int roleNum = userInstance.RoleToNum((string)reader[4]);

                    userInstance = new Users
                    (
                        (int)reader[0],
                        (string)reader[1],
                        (string)reader[2],
                        (string)reader[3],
                        (Role)roleNum
                    );
                }                    
                reader.Close();                                                           //closees connection to the database.
                dbConnect.Close();                                                        //closes connection to server.
            //}
            /*
            catch                                                          //If the connection fails.
            {
                throw new InvalidCredentials("Information provided was not in an acceptable format.");//Displays error message.
            }
            */
            return userInstance;
        }

        /// <summary>
        /// Retrieves and displays a list of all users contained in the users table of Lor_P1 database.
        /// </summary>
        /// <param userName="userName"></param>
        /// <returns>returns(user list)</returns>
        /// <exception cref="RecordNotFoundException">exception descriptions</exception>
        public Users RegisterUser(Users newUser)                                              //Method to register a user.
        {                                                                                 //*below* SQL Command to enter record information.
            string sqlStmnt = "insert into Lor_P1.users (legalName, userName, password, role) values (@legalName, @userName, @password, @role);";

            SqlConnection dbConnect = _connectionFactory.GetConnection();                 //Invoking our instance of the Connection Factory.
            
            SqlCommand registerUser = new SqlCommand(sqlStmnt, dbConnect);                //Defining the registerUser methods and arguments.

            registerUser.Parameters.AddWithValue("@legalName", newUser.legalName); 
            registerUser.Parameters.AddWithValue("@userName", newUser.userName);
            registerUser.Parameters.AddWithValue("@password", newUser.password);
            registerUser.Parameters.AddWithValue("@role", newUser.RoleToString(newUser.role));
            
            //try
            //{
                dbConnect.Open();                                                        //Opening the connection to the database.
                
                int rowsAffected = registerUser.ExecuteNonQuery();                       //Execute non query will be for DML statements.

                dbConnect.Close();                                                       //Closing connection tot he database.

                if(rowsAffected != 0)                                                    //Returns true provided the values entered were *not* null.
                {
                    if(newUser.userName != null)
                    {
                        return GetUserByUserName(newUser.userName);
                    }
                    else
                    {
                        throw new UsernameNotAvailable();
                    }
                }
                else
                {
                    throw new UsernameNotAvailable();
                }
            //}
            /*
            catch
            {
                throw new InvalidCredentials("Information provided was not in an acceptable format."); 
            }*/
        }

        public bool DeleteUserByUserId(int userId)
        {
            string deleteString = "delete from Lor_P1.users where user_Id = @user_Id;";

            SqlConnection dbConnect = _connectionFactory.GetConnection();

            SqlCommand deleteUser = new SqlCommand(deleteString, dbConnect);

            deleteUser.Parameters.AddWithValue("@user_Id", userId);

            dbConnect.Open();

            try
            {
                int rowsAffected = deleteUser.ExecuteNonQuery();
                
                if(rowsAffected != 0)                                                    //Returns true provided the values entered were *not* null.
                {
                    return true;
                }

                else
                {
                    return false;
                }

                dbConnect.Close();                                                       //Closing connection tot he database.
            }
            
            catch(Exception)
            {
                throw;
            }

            return false;
        }
    }
}