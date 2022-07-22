using Models;                                                //This file holds all of the DAOs to be referenced in Services and the
using System.Data.SqlClient;                                 //repository implementations.

namespace DataAccess
{
    public interface ITicketDAO                              //Interface for the ticket repository.
    {
        List<Tickets> GetAllTickets();                       //Method names self explanatory and explained in more detail in 'TicketRepoImpl'
        bool CreateTicket(Tickets createTicket);
        bool UpdateTicket(Tickets existingTicket);           
        bool DeleteTicketByTicketId(int ticketId);
        Tickets GetTicketByTicketId(int ticketId);           
        List<Tickets> GetTicketByAuthorId(int authorId);
        List<Tickets> GetTicketByTicketStatus(Status status);
    }

    public interface IUserDAO                                //Interface for the user repository.
    {
        List<Users> GetAllUsers();                           //Method names self explanatory and explained in more detail in 'UserRepoImpl'
        Users RegisterUser(Users user);
        Users GetUserByUserId(int userId);
        Users GetUserByUserName(string userName);
        bool DeleteUserByUserId(int userId);      
    }
    /*
    public interface IEncryptionDAO();                       //Unimplemented 'IEncryption' interface. Attempting to hash and salt user passwords. 
    {
        Users HashPass(string password);                     //Takes the user password and converts it to an encrypted SHA256 string of characters.
        Users SaltHash(string password);                     //Adds a random string of characters into hashed password for extra security.   
        Users StoredPassword(string password);               //Compares users entered password to stored password in the database.
    }
    */
}