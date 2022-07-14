namespace Models;                             //This page contains the necessary components
                                              //for the Tickets to be submitted.
public class Ticket                           //Ticket class...
{
    public int ticketId { get; set; }         //Unique TicketID number for search and organization.
    public string author { get; set; }        //Name of the creator of the ticket submission.
    public string resolver { get; set; }      //Whether the ticket will be approved or not.
    public string description { get; set; }   //Description of expenses to be reimbursed.
    public string managerNote { get; set; }   //Manager can ask for more information or provide detail.
    public double amount { get; set; }       //Total amount of money to be reimbursed.

    public Ticket(int ticketId, string author, string resolver, string description, string managerNote, double amount)//use for accessing DB          
    {
        this.ticketId = ticketId;
        this.author = author;                            
        this.resolver = resolver;                                    
        this.description = description;                         //   "    "                             
        this.managerNote = managerNote;
        this.amount = amount;                                        
    }

    public Ticket(string author, string resolver, string description, string managerNote, double amount)//used for entering information into DB          
    {
        this.author = author;                            
        this.resolver = resolver;                                    
        this.description = description;                         //   "    "                             
        this.managerNote = managerNote;
        this.amount = amount;                                       
    }
}