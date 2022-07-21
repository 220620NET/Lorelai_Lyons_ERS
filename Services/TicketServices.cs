using Exceptions;
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

        public Tickets SearchByTicketId(int ticketId)
        {
            try
            {
                return _ticketDAO.GetTicketByTicketId(ticketId);
            }
            catch(ResourceNotFound)
            {
                throw new ResourceNotFound();
            }
        }

        public Tickets SearchByAuthorId(int authorId)
        {
            try
            {
                return _ticketDAO.GetTicketByAuthorId(authorId);
            }
            catch(ResourceNotFound)
            {
                throw new ResourceNotFound();
            }
        }

        public List<Tickets> SearchByTicketStatus(Status status)
        {
            try
            {
                return _ticketDAO.GetTicketByTicketStatus(status);
            }
            catch(ResourceNotFound)
            {
                throw new ResourceNotFound();
            }
        }

        public bool SubmitTicket(Tickets createTicket)
        {
            try
            {
                return _ticketDAO.CreateTicket(createTicket);
            }
            catch(Exception)
            {
                throw;                
            }
        }

        public bool EditTicket(Tickets existingTicket)
        {
            try
            {
                return _ticketDAO.UpdateTicket(existingTicket);
            }
            catch(Exception)
            {
                throw;                
            }
        }
    }
}