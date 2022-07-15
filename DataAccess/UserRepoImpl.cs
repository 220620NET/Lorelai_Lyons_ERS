using Models;
using System;
using System.Data;
using System.Data.SqlClient; //to use this I need to go to git and use command 'git add package System.Data.SqlClient'

namespace DataAccess
{
    public class UserRepository : IUsersDAO
    {
        private readonly ConnectionFactory _connectionFactory;

        public UserRepository()
        {
            _connectionFactory = ConnectionFactory.GetInstance(File.ReadAllText("../DataAccess/connectionString.txt"));
        }

        public UserRepository(ConnectionFactory factory)
        {
            _connectionFactory = factory;
        }
        
        public List<Users> GetAllUsers()
        {
            List<Users> usersInRepo = new List<Users>();
        
            string queryString = "select * from Lor_P1.users;";

            SqlConnection dbConnect = _connectionFactory.GetConnection();

            SqlCommand returnUsers = new SqlCommand(queryString, dbConnect);                 //datatype for the active connection

            try
            {
                dbConnect.Open();                                                        //opens connection to the database
                SqlDataReader reader = returnUsers.ExecuteReader();                           //Stores the result set of a SQL statement into a variable 
                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}", reader[0], reader[1], reader[2], reader[3], reader[4]);//based on number of columns!!!!
                    usersInRepo.Add(new Users((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (string)reader[4]));
                }
                reader.Close();                                                           //closees connection to the database. Important!
                dbConnect.Close();                                                       //closes connection to server
            }
            catch (Exception ex)                                                          //If the connection fails
            {
                Console.WriteLine(ex.Message);                                            //Displays error message
            }
            return usersInRepo;                                                           //Keeps content displayed until exit
        }

        public List<Users> GetUserByUsername(string userName)
        {
            return null;
        }

        public List<Users> GetUserById(int userID)
        {
            return null;
        }

        public bool CreateUser(Users users)
        {
            return false;
        }
    }
}




            /*
            *******Notes Below******
            public bool CreateTodo(Todo todo){
            //this defines the sql operation we would like to do
            string sql = "insert into todoapp.todos (description) values (@description);";

            //datatype for an active connection
            SqlConnection connection = new SqlConnection(connectionString);

            //datatype to reference the sql command you want to do to a specific connection
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@description", todo.description); 
            //command.Parameters.AddWithValue("@name", "steve");

            try
            {
                //opening the connection to the database
                connection.Open();

                //storing the result set of a DQL statement into a variable

                //execute non query will be for DML statements
                int rowsAffected = command.ExecuteNonQuery();

                connection.Close();

                if(rowsAffected != 0){
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            return false;
        }*/
        



//TodoDAO todoDAO = new TodoDao();

        //Todo todoToBeCreated = new Todo("mop the floor");//CREATING A THING TO INSERT INTO THE TODO DATABASE

        //todoDAO.CreateTodo(todoToBeCreated);             //ACTUALLY INSERTING
        
        //todoDAO.DeleteTodo(2);                           //DELETING A LINE FROM THE DB using DeleteTodo method

        //List<Todo> todos = todoDAO.GetAllTodos();        //using our getall method

        //foreach(Todo todo in todos)                      //displaying the results from getall
        //{
        //    Console.WriteLine(todo);
        //} 