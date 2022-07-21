using Exceptions;
using Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class TicketRepository : ITicketDAO
    {
        private readonly ConnectionFactory _connectionFactory;
    
        public TicketRepository(ConnectionFactory factory)
        {
            _connectionFactory = factory;
        }
        
        /// <summary>
        /// Retrieves and displays a list of all tickets contained in the users table of Lor_P1 database.
        /// Entries below this will have no redundant content information from this method.
        /// </summary>
        ///// <param userName="Rather than list all parameter explanations, check 'tickets' model class for further explanation on each parameter."></param>
        /// <returns>Returns the collection of information retreived from the tickets table of my database.</returns>
        /// <exception cref="RecordNotFoundException">Displays if connection to the database is lost.</exception>

        public List<Tickets> GetAllTickets()
        {
            List<Tickets> ticketsInRepo = new List<Tickets>();            //List will be comprised of table information and displayed at the end.
            
            string queryString = "select * from Lor_P1.tickets;";         //SQL command to be executed.

            SqlConnection dbConnect = _connectionFactory.GetConnection(); //Invoking connection factory to connect to database.

            SqlCommand getAll = new SqlCommand(queryString, dbConnect);   //Datatype for the active connection.

            Tickets ticketTest = new Tickets();

            try
            {
                dbConnect.Open();                                         //Opens connection to the database.
                SqlDataReader reader = getAll.ExecuteReader();            //Stores the result set of a SQL statement into a variable. 
                while (reader.Read())
                {
                    Console.WriteLine(                               //(below) These two lines display read information to the console.
                        "Ticket Id: {0} \tAuthor Id: {1}\tResolver Id: {2}\t Description: {3}\tStatus: {4}\tManager Note: {5}\tAmount: {6}",
                        reader[0], reader[1], reader[2], reader[3], reader["status"], reader[5], reader[6]);

                    ticketTest = new Tickets
                        {
                        ticketId = (int)reader[0],
                        authorId = (int)reader[1],
                        resolverId = (int)reader[2],
                        description = (string?)reader[3],               //             "      "
                        status = ticketTest.StringToStatus((string)reader["status"]),
                        amount = (decimal)reader[6]
                        };

                    if(reader[5] == DBNull.Value)
                    {
                        ticketTest.managerNote = "   ";
                    }
                    else
                    {
                        ticketTest.managerNote = (string)reader[5];
                    }
                    ticketsInRepo.Add(ticketTest);
                }
                reader.Close();                                      //Closees connection to the database. Important!
                dbConnect.Close();                                   //Closes connection to server.
            }
            catch(Exception)                                         //If the connection fails.
            {
                throw;                                               //Displays error message if table were to be empty.
            }
            return ticketsInRepo;                                    //Keeps content displayed until exit from application.
        }

        /// <summary>
        /// Retrieves and displays tickets submitted by a particular user by searching their unique ID number.
        /// </summary>
        ///// <param userName="See above note."></param>
        /// <returns>Returns instance of created ticket(s) to webAPI.</returns>
        /// <exception cref="ResourceNotFound">Displays if connection to the database is lost.</exception>

        public Tickets GetTicketByAuthorId(int authorId)
        {
            
            //List<Tickets> submittedList = new List<Tickets>(); 

            string queryString = "select * from Lor_P1.tickets where author_fk = @author_fk;";

            SqlConnection dbConnect = _connectionFactory.GetConnection();

            SqlCommand getAuthor = new SqlCommand(queryString, dbConnect);

            getAuthor.Parameters.AddWithValue("@author_fk", authorId);           //Using authorId as input for method.

            Tickets ticketInstance = new Tickets();                              //Instance of ticket to be returned at the end of method.

            try
            {
                dbConnect.Open();                     
                SqlDataReader reader = getAuthor.ExecuteReader();

                while (reader.Read())
                {
                    ticketInstance = new Tickets
                        {
                        ticketId = (int)reader[0],
                        authorId = (int)reader[1],
                        resolverId = (int)reader[2],
                        status = ticketInstance.StringToStatus((string)reader["status"]),
                        amount = (decimal)reader[6]
                        };

                    if(reader[3] == DBNull.Value)
                    {
                        ticketInstance.description = "   ";
                    }
                    else
                    {
                        ticketInstance.description = (string)reader[3];
                    }

                    if(reader[5] == DBNull.Value)
                    {
                        ticketInstance.managerNote = "   ";
                    }
                    else
                    {
                        ticketInstance.managerNote = (string)reader[5];
                    }

                    //submittedList.Add(ticketInstance);
                }

                reader.Close();                                       
                dbConnect.Close();                                      
            }
            catch(Exception)                                                       
            {
                throw;
            }
            return ticketInstance;                                 
        }

        /// <summary>
        /// Retrieves and displays tickets by searching unique ticket ID number.
        /// </summary>
        ///// <param userName="     "    "    "></param>
        /// <returns>Returns instance of created ticket to webAPI.</returns>
        /// <exception cref="RecordNotFoundException">Displays if connection to the database is lost.</exception>

        public Tickets GetTicketByTicketId(int ticketId)
        {
            //List<Tickets> submittedList = new List<Tickets>();   

            string queryString = "select * from Lor_P1.tickets where ticket_Id = @ticket_Id;";

            SqlConnection dbConnect = _connectionFactory.GetConnection();

            SqlCommand getAuthor = new SqlCommand(queryString, dbConnect); 

            getAuthor.Parameters.AddWithValue("@ticket_Id", ticketId);

            Tickets ticketInstance = new Tickets();

            try
            {
                dbConnect.Open();
                SqlDataReader reader = getAuthor.ExecuteReader();                         
                while (reader.Read())
                {
                    ticketInstance = new Tickets
                        {
                        ticketId = (int)reader[0],
                        authorId = (int)reader[1],
                        resolverId = (int)reader[2],
                        status = ticketInstance.StringToStatus((string)reader["status"]),
                        amount = (decimal)reader[6]
                        };

                    if(reader[3] == DBNull.Value)
                    {
                        ticketInstance.description = "   ";
                    }
                    else
                    {
                        ticketInstance.description = (string)reader[3];
                    }

                    if(reader[5] == DBNull.Value)
                    {
                        ticketInstance.managerNote = "   ";
                    }
                    else
                    {
                        ticketInstance.managerNote = (string)reader[5];
                    }

                    //submittedList.Add(ticketInstance);
                }
                
                reader.Close();                                          //closees connection to the database. Important!
                dbConnect.Close();                                       //closes connection to server
            }
            catch(Exception)                                             //If the connection fails
            {
                throw;                                                   //Displays error message
            }
            return ticketInstance;
        }

        /// <summary>
        /// Retrieves and displays tickets by calling their current status.
        /// </summary>
        ///// <param userName="     "    "    "></param>
        /// <returns>Returns instance of created ticket(s) to webAPI.</returns>
        /// <exception cref="RecordNotFoundException">Displays if connection to the database is lost.</exception>

        public List<Tickets> GetTicketByTicketStatus(Status status)                      
        {            
            Console.WriteLine("In Data Layer: " + status);
            List<Tickets> submittedList = new List<Tickets>(); 

            string queryString = "select * from Lor_P1.tickets where status = @status;";

            SqlConnection dbConnect = _connectionFactory.GetConnection();

            SqlCommand getStatus = new SqlCommand(queryString, dbConnect);               //datatype for the active connection

            getStatus.Parameters.AddWithValue("@status", status.ToString());

            Tickets ticketInstance = new Tickets();

            try
            {
                dbConnect.Open();                                                        //opens connection to the database
                SqlDataReader reader = getStatus.ExecuteReader();                        //Stores the result set of a SQL statement into a variable

                while (reader.Read())
                {
                    ticketInstance = new Tickets
                        {
                        ticketId = (int)reader[0],
                        authorId = (int)reader[1],
                        resolverId = (int)reader[2],
                        description = (string?)reader[3],               //             "      "
                        status = ticketInstance.StringToStatus((string)reader["status"]),
                        amount = (decimal)reader[6]
                        };

                    if(reader[3] == DBNull.Value)
                    {
                        ticketInstance.description = "   ";
                    }
                    else
                    {
                        ticketInstance.description = (string)reader[3];
                    }

                    if(reader[5] == DBNull.Value)
                    {
                        ticketInstance.managerNote = "   ";
                    }
                    else
                    {
                        ticketInstance.managerNote = (string)reader[5];
                    }
                    submittedList.Add(ticketInstance);
                }
                
                reader.Close();                                                      //closees connection to the database. Important!
                dbConnect.Close();                                                   //closes connection to server
            }
            catch(Exception)                                                         //If the connection fails
            {
                throw;                                                               //Displays error message
            }
            return submittedList;
        }

        /// <summary>
        /// Retrieves and displays a list of all users contained in the users table of Lor_P1 database.
        /// </summary>
        ///// <param userName="userName"></param>
        /// <returns>returns(user list)</returns>
        /// <exception cref="RecordNotFoundException">Displays if connection to the database is lost.</exception>

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

        /// <summary>
        /// Retrieves and displays a list of all users contained in the users table of Lor_P1 database.
        /// </summary>
        ///// <param userName="userName"></param>
        /// <returns>returns(user list)</returns>
        /// <exception cref="RecordNotFoundException">Displays if connection to the database is lost.</exception>

        public bool UpdateTicket(Tickets upTicket)
        {
            string queryString = "update Lor_P1.tickets set resolver_fk = @resolver_fk, status = @status, manager_note = @manager_note where ticket_Id = @ticket_Id;";

            List<Tickets> updateList = new TicketRepository(_connectionFactory).GetAllTickets();

            SqlConnection dbConnect = _connectionFactory.GetConnection();

            SqlCommand changeTicket = new SqlCommand(queryString, dbConnect);

            changeTicket.Parameters.AddWithValue("@ticket_Id", upTicket.ticketId);
            changeTicket.Parameters.AddWithValue("@resolver_fk", upTicket.resolverId);
            changeTicket.Parameters.AddWithValue("@status", upTicket.NumToStatus((int)upTicket.status).ToString());
            changeTicket.Parameters.AddWithValue("@manager_note", upTicket.managerNote);
            /*
            if(changeTicket.Parameters.AddWithValue("@manager_note", upTicket.managerNote) == DBNull.Value)
            {
                upTicket.managerNote = "   ";
            }
            else
            {
                upTicket.managerNote = changeTicket.Parameters.AddWithValue("@manager_note", upTicket.managerNote);
            }
*/
            try
            {
                dbConnect.Open();

                if((upTicket.ticketId > 0) && (upTicket.ticketId <= updateList.Count))
                {   /*
                    if(GetTicketByTicketId(upTicket.ticketId).status == status.Approved || GetTicketByTicketId(upTicket.ticketId).status == status.Denied)
                    {
                        return false;
                    }*/
                    
                    int rowsAffected = changeTicket.ExecuteNonQuery();                       //Execute non query will be for DML statements.

                    dbConnect.Close();                                                       //Closing connection tot he database.

                    if(rowsAffected != 0)                                                    //Returns true provided the values entered were *not* null.
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                throw;
            }

            return false;
        }
    }
} 