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

        public Tickets GetTicketByTicketId(int ticketId)
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

        public Tickets GetTicketByAuthorId(int authorId)
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

        public Tickets GetTicketByTicketStatus(Status status)
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
                bool ticketGenerator = _ticketDAO.CreateTicket(createTicket);

                if(ticketGenerator)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(InvalidCredentials)
            {
                throw new InvalidCredentials();                
            }
        }

        public bool EditTicket(Tickets existingTicket)
        {
            try
            {
                return _ticketDAO.UpdateTicket(existingTicket);
            }
            catch(InvalidCredentials)
            {
                throw new InvalidCredentials();                
            }
        }
    }
}