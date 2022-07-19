namespace Models;                             //This page contains the necessary components
                                              //for the Tickets to be submitted.
public enum Status
{
    Pending,
    Approved,
    Denied
}

public class Tickets                          //Tickets class...
{
    public int ticketId { get; set; }         //Unique TicketID number for search and organization.
    public int authorId { get; set; }         //Name of the creator of the ticket submission.
    public int resolverId { get; set; }       //Whether the ticket will be approved or not.
    public string description { get; set; }   //Description of expenses to be reimbursed.
    public Status status { get; set; }
    public string managerNote { get; set; }   //Manager can ask for more information or provide detail on why a claim may be denied.
    public decimal amount { get; set; }        //Total amount of money to be reimbursed.

    public Tickets() {}

    public Tickets(int ticketId, int authorId, int resolverId, string description, Status status, string managerNote, decimal amount)//use for accessing DB          
    {
        this.ticketId = ticketId;
        this.authorId = authorId;                            
        this.resolverId = resolverId;                                    
        this.description = description;
        this.status = status;                 //   "    "                             
        this.managerNote = managerNote;
        this.amount = amount;                                        
    }

    public Tickets(int authorId, int resolverId, string description, Status status, string managerNote, decimal amount)//used for entering information into DB          
    {
        this.authorId = authorId;                            
        this.resolverId = resolverId;                                    
        this.description = description;       //   "    "
        this.status = status;                             
        this.managerNote = managerNote;
        this.amount = amount;                                       
    }

    public Tickets(int authorId, string description, decimal amount)//used for entering information into DB          
    {
        this.authorId = authorId;                                                              
        this.description = description;       //   "    "
        this.amount = amount;                                       
    }

    public Tickets(int ticketId, int resolverId, int status, string managerNote)//used for entering information into DB          
    {                           
        this.ticketId = ticketId;
        this.resolverId = resolverId;                                           //   "    "
        this.status = (Status) status;                             
        this.managerNote = managerNote;                                     
    }

    public int StatusToNum(string userEntry)
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

    public string NumToStatus(int userEntry)
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
    
    public override string ToString()
    {
        return $"TicketId: {this.ticketId}\nAuthorId: {this.authorId}\nResolverId: {this.resolverId}\nStatus: {this.status}\nDescription: {this.description}\n Amount: {this.amount}";
    }

    public Status StringToStatus(string input)
    {
        Dictionary<string,Status> dictStatus = new Dictionary<string, Status>()
        {
            {"Pending", Status.Pending},
            {"Approved", Status.Approved},
            {"Denied", Status.Denied}
        };

        return dictStatus[input];
    }

    public string StatusToString(Status input)
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