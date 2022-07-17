using Models;                                                //This file holds all of the DAOs to be referenced in Services and the
using System.Data.SqlClient;                                 //repository implementations.

namespace DataAccess
{
    public interface ITicketDAO                              //Interface for the ticket repository.
    {
        List<Tickets> GetAllTickets();
        bool CreateTicket(Tickets createTicket);
        bool UpdateTicket(Tickets existingTicket);  //maybe change these to new ticket later?
        //public void DeleteTicket(Tickets existingTicket);  //also I got rid of all the 'publics...
        List<Tickets> GetTicketByTicketId(int ticketId);          //public may be redundant here?
        List<Tickets> GetTicketByAuthorId(int authorId);
        List<Tickets> GetTicketByTicketStatus(Status status);
    }

    public interface IUserDAO                               //Interface for the user repository.
    {
        List<Users> GetAllUsers();
        Users RegisterUser(Users user);
        Users GetUserByUserId(int userId);
        Users GetUserByUserName(string userName);
        //public void DeleteAccount(Users user);
    }
}