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

    public IResult TicketIdSearch(int ticketId)
    {
        try
        {   
            Tickets queriedTicket = _service.SearchByTicketId(ticketId);
            return Results.Created("/tickets/ticketId/{ticketId}", queriedTicket);
        }
        catch(Exception)
        {
            throw;
        }
    }

    public IResult TicketStatusSearch(Status status)
    {
        Console.WriteLine("Status: " + status);
        try
        {   
            List<Tickets> queriedTicket = _service.SearchByTicketStatus(status);
            return Results.Ok(queriedTicket);
        }
        catch(Exception)
        {
            throw;
        }
    }

    public IResult AuthorIdSearch(int authorId)
    {
        try
        {   
            List<Tickets> queriedTicket = _service.SearchByAuthorId(authorId);
            return Results.Ok(queriedTicket);
        }
        catch(Exception)
        {
            throw;
        }
    }

    public IResult Update(Tickets ticketUpdate)
    {
        Console.WriteLine(ticketUpdate.ToString());
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

    public IResult Delete(int ticketId)
    {
        try
        {
            _service.DeleteTicket(ticketId);
            return Results.Ok(ticketId);
        }
        catch(ResourceNotFound)
        {
            return Results.Conflict("No ticket with this ID exists.");
        }
    }
}