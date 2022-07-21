using System.Text.Json;
using System.Text.Json.Serialization;

namespace Models;                              /*This page contains the necessary components for the tickets class
                                                  to be submitted, edited, and used throughout the application*/

public enum Status                             //Used to define the potential states of submitted tickets.
{
    Pending,
    Approved,
    Denied
}

public class Tickets                           //Tickets class...
{
    public int ticketId { get; set; }          //Unique TicketID number for search and organization.
    public int authorId { get; set; }          //Name of the creator of the ticket submission.
    public int resolverId { get; set; }        //Whether the ticket will be approved or not.
    public string? description { get; set; }   //Description of expenses to be reimbursed. Can be left blank if desired.
    public Status status { get; set; }         //Status provides three options: Pending, Approved, Denied. Default state = pending.
    public string? managerNote { get; set; }   //Manager can ask for more information or provide detail on why a claim may be denied.
    public decimal amount { get; set; }        //Total amount of money to be reimbursed.

    public Tickets() {}                        //Empty ticket constructor.

    public Tickets(int ticketId, int authorId, int resolverId, string? description, Status status, string? managerNote, decimal amount)//Ticket constructor containing all variables.         
    {
        this.ticketId = ticketId;
        this.authorId = authorId;                            
        this.resolverId = resolverId;                                    
        this.description = description;        //   "    "
        this.status = status;                                              
        this.managerNote = managerNote;
        this.amount = amount;                                        
    }

    public Tickets(int authorId, int resolverId, string? description, Status status, string? managerNote, decimal amount)//Ticket constructor with all variables save 'ticketId'.          
    {
        this.authorId = authorId;                            
        this.resolverId = resolverId;                                    
        this.description = description;        //   "    "
        this.status = status;                             
        this.managerNote = managerNote;
        this.amount = amount;                                       
    }

    public Tickets(int authorIdEntry, int resolverId, string? descriptionEntry, decimal amountEntry)//Ticket constructor for submitting a new ticket into the database.        
    {
        this.authorId = authorIdEntry;                                                              
        this.description = descriptionEntry;       //   "    "
        this.amount = amountEntry;                                       
    }

    public Tickets(int ticketId, int resolverId, int status, string? managerNote)//Ticket constructor for approval/denial of submitted tickets.          
    {                           
        this.ticketId = ticketId;
        this.resolverId = resolverId;          //   "    "
        this.status = (Status) status;                             
        this.managerNote = managerNote;                                     
    }

    public int StatusToNum(string userEntry)                                     //Casts 'status' as an integer to pass back and forth between database and application.
    {
        switch (userEntry)
        {
            case "Approved":
                return 1;
            case "Denied":
                return 2;
            default:
                return 0;
        }
    }

    public string NumToStatus(int userEntry)                                     //Casts 'status' as a string stating in plain text the current state of the ticket.
    {
        switch (userEntry)
        {
            case 1:
                return "Approved";
            case 2:
                return "Denied";
            default:
                return "Pending";
        }
    }
    
    public override string ToString()                                            //Prints all ticket information as a string to the console.
    {
        return $"TicketId: {this.ticketId}\nAuthorId: {this.authorId}\nResolverId: {this.resolverId}\nStatus: {this.status}\nDescription: {this.description}\n Amount: {this.amount}";
    }

    public Status StringToStatus(string input)                //Somewhat obsolete, but this and the following dictionaries were my first attempt at casting the status as an integer.
    {
        Dictionary<string,Status> dictStatus = new Dictionary<string, Status>()
        {
            {"Pending", Status.Pending},
            {"Approved", Status.Approved},
            {"Denied", Status.Denied}
        };

        return dictStatus[input];
    }

    public string StatusToString(Status input)                                   //Not used in the program, but I left it in for potential updates down the line.
    {
        Dictionary<Status,string> dictStatus = new Dictionary<Status, string>()
        {
            {Status.Pending, "Pending"},
            {Status.Approved, "Approved"},
            {Status.Denied, "Denied"}
        };

        return dictStatus[input];
    }
}