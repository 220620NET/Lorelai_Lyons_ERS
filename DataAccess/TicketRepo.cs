using Models;
using System.Data.SqlClient;

namespace DataAccess
{
    public interface TicketDAO
    {
        public List<Ticket> GetAllTickets();
        //public bool CreateTodo(Todo todo);
        //public void DeleteOneTodo(int todoId);
    }
}