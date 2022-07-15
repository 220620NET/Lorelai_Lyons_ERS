using Models;
using System;
using System.Data;
using System.Data.SqlClient; //to use this I need to go to git and use command 'git add package System.Data.SqlClient'

namespace DataAccess
{
    public class TicketRepository : ITicketDAO
    {
        private readonly ConnectionFactory _connectionFactory;

        public TicketRepository()
        {
            _connectionFactory = ConnectionFactory.GetInstance(File.ReadAllText("../DataAccess/connectionString.txt"));
        }

        public TicketRepository(ConnectionFactory factory)
        {
            _connectionFactory = factory;
        }
        
        public List<Tickets> GetAllTickets()                                             //eventually this will not even be a method
        {
            List<Tickets> ticketsInRepo = new List<Tickets>();
            
            string queryString = "select * from Lor_P1.tickets;";

            SqlConnection dbConnect = _connectionFactory.GetConnection();

            SqlCommand command = new SqlCommand(queryString, dbConnect);                 //datatype for the active connection

            try
            {
                dbConnect.Open();                                                        //opens connection to the database
                SqlDataReader reader = command.ExecuteReader();                          //Stores the result set of a SQL statement into a variable 
                while (reader.Read())
                {
                    Tickets ticketTest = new Tickets();

                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2], reader[3], reader["status"], reader[5], reader[6]);//based on number of columns!!!!
                    ticketsInRepo.Add(new Tickets
                    (
                     (int)reader[0],
                     (int)reader[1],
                     (int)reader[2],
                     (string)reader[3],
                     ticketTest.StringToStatus((string)reader["status"]),
                     (string)reader[5],
                     (decimal)reader[6]
                    ));
                }
                reader.Close();                                                          //closees connection to the database. Important!
                dbConnect.Close();                                                       //closes connection to server
            }
            catch (Exception ex)                                                         //If the connection fails
            {
                Console.WriteLine(ex.Message);                                           //Displays error message
            }
            return ticketsInRepo;                                                        //Keeps content displayed until exit
        }

        public List<Tickets> GetTicketByAuthor(int authorId)                             //
        {
            return null;
        }

        public List<Tickets> GetTicketByTicketId(int ticketId)                           //
        {
            return null;
        }

        public List<Tickets> GetTicketByTicketStatus(Status status)                      //
        {
            return null;
        }

        public bool CreateTicket(Tickets ticket)
        {
            return false;
        }

        public bool UpdateTicket(Tickets ticket)
        {
            return false;
        }
    }
} 

/*
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
        }
  

//TodoDAO todoDAO = new TodoDao();

        //Todo todoToBeCreated = new Todo("mop the floor");//CREATING A THING TO INSERT INTO THE TODO DATABASE

        //todoDAO.CreateTodo(todoToBeCreated);             //ACTUALLY INSERTING
        
        //todoDAO.DeleteTodo(2);                           //DELETING A LINE FROM THE DB using DeleteTodo method

        //foreach(Todo todo in todos)                      //displaying the results from getall
            //{
            //    Console.WriteLine(todo);
            //} 

*/