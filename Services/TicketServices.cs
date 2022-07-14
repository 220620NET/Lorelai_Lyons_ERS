using Models;
using TicketRepo;

namespace TicketServices
{
    public class TicketService
    {
        private TicketRepository ticketRepo = new TicketRepository();

        public List<Ticket> GetAllTickets()
        {
            return ticketRepo.GetAllTickets();
        }
        /*
        public bool CreateUser(Users user){
            // since there isnt really business logic anywhere in this app, I made up a requirement that descriptions of todos can be only 10 characters long
            return todoDao.CreateTodo(todo);

        }

        public void DeleteOneTodo(int todoId){
            todoDao.DeleteOneTodo(todoId);
        }
        */
    }
}