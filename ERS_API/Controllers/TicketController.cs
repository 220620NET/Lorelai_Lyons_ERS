using Exceptions;
using Models;
using Services;

namespace ErsAPI.Controllers;

public class TicketController
{
    private readonly TicketService _service;

    public TicketController(TicketService service)
    {
        _service = service;
    }

    public List<Tickets> GetAllTickets()
    {
        return _service.GetAllTickets();
    }

    public IResult GetTicketByTicketId(int ticketId)
    {
        try
        {   
            Tickets queriedTicket = _service.GetTicketByTicketId(ticketId);
            return Results.Created("/tickets/ticketId/{ticketId}", queriedTicket);
        }
        catch(InvalidCredentials)
        {
            return Results.BadRequest("No ticket with this ticketId exists.");
        }
    }
}