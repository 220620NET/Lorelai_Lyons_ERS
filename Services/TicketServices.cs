using Models;
using DataAccess;

namespace Services
{
    public class TicketService
    {
        private readonly ITicketDAO _ticketDAO;
        
        public TicketService(ITicketDAO ticketDAO)
        {
            _ticketDAO = ticketDAO;
        }

        public List<Tickets> GetAllTickets()
        {
            return _ticketDAO.GetAllTickets();
        }
    }
}