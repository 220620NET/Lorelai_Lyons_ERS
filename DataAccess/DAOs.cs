using Models;                                                //This file holds all of the DAOs to be referenced in Services and the
using System.Data.SqlClient;                                 //repository implementations.

namespace DataAccess
{
    public interface ITicketDAO                              //Interface for the ticket repository.
    {
        public List<Tickets> GetAllTickets();
        //public bool CreateTicket(Tickets createTicket);
        //public bool UpdateTicket(Tickets existingTicket);  //maybe change these to new ticket later?
        //public void DeleteTicket(Tickets existingTicket);
        //public Tickets GetTicketsById(int ticketId);
        //public Tickets GetTicketByAuthor(string author);
        //publick Tickets GetTicketByStatus(string status);
    }

    public interface IUsersDAO                               //Interface for the user repository.
    {
        public List<Users> GetAllUsers();
        //public bool RegisterUser(Users user);
        //public Users GetUserById(int userId);
        //public Users GetUserByUserName(string userName);
        //public void DeleteAccount(Users user);
    }
}