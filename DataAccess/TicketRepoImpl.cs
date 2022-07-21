using Exceptions;
using Models;
using System;
using System.Data;
using System.Data.SqlClient; //to use this I need to go to git and use command 'git add package System.Data.SqlClient'

namespace DataAccess
{
    public class TicketRepository : ITicketDAO
    {
        private readonly ConnectionFactory _connectionFactory;
    
        public TicketRepository(ConnectionFactory factory)
        {
            _connectionFactory = factory;
        }
        
        public List<Tickets> GetAllTickets()                                             //eventually this will not even be a method
        {
            List<Tickets> ticketsInRepo = new List<Tickets>();
            
            string queryString = "select * from Lor_P1.tickets;";

            SqlConnection dbConnect = _connectionFactory.GetConnection();

            SqlCommand getAll = new SqlCommand(queryString, dbConnect);                 //datatype for the active connection

            try
            {
                dbConnect.Open();                                                        //opens connection to the database
                SqlDataReader reader = getAll.ExecuteReader();                          //Stores the result set of a SQL statement into a variable 
                while (reader.Read())
                {
                    Tickets ticketTest = new Tickets();

                    if(ticketTest.description == null) //doing seemingly nothing
                    {
                        ticketTest.description = "";
                    }

                    if(reader[5] == DBNull.Value)
                    {
                        ticketTest.managerNote = "";
                    }

                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", reader[0], reader[1], reader[2], reader[3], reader["status"], reader[5], reader[6]);//based on number of columns!!!!
                    ticketsInRepo.Add(new Tickets
                    {
                     ticketId = (int)reader[0],
                     authorId = (int)reader[1],
                     resolverId = (int)reader[2],
                     description = (string?)reader[3],
                     status = ticketTest.StringToStatus((string)reader["status"]),
                     amount = (decimal)reader[6]
                    });
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

        public Tickets GetTicketByAuthorId(int authorId)                             //
        {
            string queryString = "select * from Lor_P1.tickets where author_fk = @author_fk;";

            SqlConnection dbConnect = _connectionFactory.GetConnection();

            SqlCommand getAuthor = new SqlCommand(queryString, dbConnect);                 //datatype for the active connection

            getAuthor.Parameters.AddWithValue("@author_fk", authorId);

            Tickets ticketInstance = new Tickets();

            Tickets functionTicket = new Tickets();
            try
            {
                dbConnect.Open();                                                          //opens connection to the database
                SqlDataReader reader = getAuthor.ExecuteReader();                          //Stores the result set of a SQL statement into a variable 
                while (reader.Read())
                {
                    int statNum = functionTicket.StatusToNum((string)reader[4]);

                    //Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2], reader[3], reader["status"], reader[5], reader[6]);//based on number of columns!!!!
                    Tickets ticket = new Tickets
                    (
                     (int)reader[0],
                     (int)reader[1],
                     (int)reader[2],
                     (string)reader[3],
                     (Status)statNum,
                     (string)reader[5],
                     (decimal)reader[6]
                    );
                    ticketInstance = ticket;
                }
                reader.Close();                                                          //closees connection to the database. Important!
                dbConnect.Close();                                                       //closes connection to server
            }
            catch                                                         //If the connection fails
            {
                throw new InvalidCredentials("Information provided was not in an acceptable format.");                                           //Displays error message
            }
            return ticketInstance;
        }

        public Tickets GetTicketByTicketId(int ticketId)                           //
        {
            string queryString = "select * from Lor_P1.tickets where ticket_Id = @ticket_Id;";

            SqlConnection dbConnect = _connectionFactory.GetConnection();

            SqlCommand getAuthor = new SqlCommand(queryString, dbConnect);                 //datatype for the active connection

            getAuthor.Parameters.AddWithValue("@ticket_Id", ticketId);

            Tickets ticketInstance = new Tickets();

            Tickets functionTicket = new Tickets();
            try
            {
                dbConnect.Open();                                                        //opens connection to the database
                SqlDataReader reader = getAuthor.ExecuteReader();                          //Stores the result set of a SQL statement into a variable 
                while (reader.Read())
                {
                    int statNum = functionTicket.StatusToNum((string)reader[4]);

                    //Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2], reader[3], reader["status"], reader[5], reader[6]);//based on number of columns!!!!
                    Tickets ticket = new Tickets
                    (
                     (int)reader[0],
                     (int)reader[1],
                     (int)reader[2],
                     (string)reader[3],
                     (Status)statNum,
                     (string)reader[5],
                     (decimal)reader[6]
                    );
                    ticketInstance = ticket;
                }
                reader.Close();                                                          //closees connection to the database. Important!
                dbConnect.Close();                                                       //closes connection to server
            }
            catch                                                         //If the connection fails
            {
                throw new InvalidCredentials("Information provided was not in an acceptable format.");                                           //Displays error message
            }
            return ticketInstance;
        }

        public Tickets GetTicketByTicketStatus(Status status)                      //
        {            
            string queryString = "select * from Lor_P1.tickets where status = @status;";

            SqlConnection dbConnect = _connectionFactory.GetConnection();

            SqlCommand getStatus = new SqlCommand(queryString, dbConnect);                 //datatype for the active connection

            getStatus.Parameters.AddWithValue("@status", status);

            Tickets ticketInstance = new Tickets();

            try
            {
                dbConnect.Open();                                                        //opens connection to the database
                SqlDataReader reader = getStatus.ExecuteReader();                          //Stores the result set of a SQL statement into a variable 
                while (reader.Read())
                {
                    int ticketId = ticketInstance.StatusToNum((string)reader[4]);

                    //Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2], reader[3], reader["status"], reader[5], reader[6]);//based on number of columns!!!!
                    Tickets ticket = new Tickets
                    (
                     (int)reader[0],
                     (int)reader[1],
                     (int)reader[2],
                     (string)reader[3],
                     (Status)ticketId,
                     (string)reader[5],
                     (decimal)reader[6]
                    );
                }
                reader.Close();                                                          //closees connection to the database. Important!
                dbConnect.Close();                                                       //closes connection to server
            }
            catch                                                         //If the connection fails
            {
                throw new InvalidCredentials("Information provided was not in an acceptable format.");                                           //Displays error message
            }
            return ticketInstance;
        }

        public bool CreateTicket(Tickets newTicket)
        {
            string sqlStmnt = "insert into Lor_P1.tickets(author_fk, resolver_fk, description, amount) values(@author_fk, @resolver_fk, @description, @amount);";
            List<Users> submitterList = new UserRepository(_connectionFactory).GetAllUsers();

            SqlConnection dbConnect = _connectionFactory.GetConnection();                 //Invoking our instance of the Connection Factory.
            
            SqlCommand submitTicket = new SqlCommand(sqlStmnt, dbConnect);                //Defining the submitTicket methods and arguments.

            submitTicket.Parameters.AddWithValue("@author_fk", newTicket.authorId);
            submitTicket.Parameters.AddWithValue("@resolver_fk", newTicket.resolverId);
            submitTicket.Parameters.AddWithValue("@description", newTicket.description);
            submitTicket.Parameters.AddWithValue("@amount", newTicket.amount);
            try
            {
                dbConnect.Open();                                                        //Opening the connection to the database.
                if((newTicket.authorId > 0) && (newTicket.authorId <= submitterList.Count))
                {
                    int rowsAffected = submitTicket.ExecuteNonQuery();                       //Execute non query will be for DML statements.

                    dbConnect.Close();                                                       //Closing connection tot he database.

                    if(rowsAffected != 0)                                                    //Returns true provided the values entered were *not* null.
                    {
                        return true;
                    }
                }
                else
                {
                    throw new InvalidCredentials();
                }
            }

            catch
            {
                throw new InvalidCredentials("Information provided was not in an acceptable format."); 
            }

            return false;
        }

        public bool UpdateTicket(Tickets upTicket)
        {
            string queryString = "update Lor_P1.tickets set resolver_fk = @resolver_fk, status = @status, manager_note = @manager_note where ticket_Id = @ticket_Id;";
            List<Users> updateList = new UserRepository(_connectionFactory).GetAllUsers();

            SqlConnection dbConnect = _connectionFactory.GetConnection();

            SqlCommand changeTicket = new SqlCommand(queryString, dbConnect);

            changeTicket.Parameters.AddWithValue("@ticket_Id", upTicket.ticketId);
            changeTicket.Parameters.AddWithValue("@resolver_fk", upTicket.resolverId);
            changeTicket.Parameters.AddWithValue("@status", upTicket.NumToStatus((int)upTicket.status));
            changeTicket.Parameters.AddWithValue("@manager_note", upTicket.managerNote);
            
            try
            {
                dbConnect.Open();
                if((upTicket.ticketId > 0) && (upTicket.ticketId <= updateList.Count))
                {
                    if(GetTicketByTicketId(upTicket.ticketId).status==Status.Approved || GetTicketByTicketId(upTicket.ticketId).status == Status.Denied)
                    {
                        return false;
                    }
                    int rowsAffected = changeTicket.ExecuteNonQuery();                       //Execute non query will be for DML statements.

                    dbConnect.Close();                                                       //Closing connection tot he database.

                    if(rowsAffected != 0)                                                    //Returns true provided the values entered were *not* null.
                    {
                        return true;
                    }
                }
                else
                {
                    throw new InvalidCredentials();
                }
            }
            catch(ResourceNotFound)
            {
                throw new ResourceNotFound();
            }

            return false;
        }
    }
} 