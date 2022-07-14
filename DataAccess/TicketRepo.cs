using Models;
using Sensitive;
using System.Data.SqlClient;

namespace TicketRepo
{
    public interface TicketDAO
    {
        public List<Ticket> GetAllTickets();
        //public bool CreateTodo(Todo todo);
        //public void DeleteOneTodo(int todoId);
    }
}