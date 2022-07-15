using Models;
using System.Data.SqlClient;

namespace DataAccess
{
    public interface ITicketDAO
    {
        public List<Ticket> GetAllTickets();
        //public bool CreateTodo(Todo todo);
        //public void DeleteOneTodo(int todoId);
    }

    public interface IUsersDAO
    {
        public List<Users> GetAllUsers();
        //public bool CreateTodo(Todo todo);
        //public void DeleteOneTodo(int todoId);
    }
}