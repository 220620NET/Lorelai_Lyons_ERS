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

    public IResult GetTicketByAuthorId(int authorId)
    {
        try
        {   
            Tickets queriedTicket = _service.GetTicketByAuthorId(authorId);
            return Results.Created("/tickets/authorId/{authorId}", queriedTicket);
        }
        catch(InvalidCredentials)
        {
            return Results.BadRequest("No ticket with this authorId exists.");
        }
    }

    public IResult Update(Tickets ticketUpdate)
    {
        try
        {
            _service.EditTicket(ticketUpdate);
            return Results.Created("/tickets/update", ticketUpdate);
        }
        catch(DuplicateRecord)
        {
            return Results.Conflict("User with this username already exists.");
        }
    }

    public IResult Submit(Tickets ticketSubmission)
    {
        try
        {
            _service.SubmitTicket(ticketSubmission);
            return Results.Created("/tickets/submission", ticketSubmission);
        }
        catch(DuplicateRecord)
        {
            return Results.Conflict("User with this username already exists.");
        }
    }
}