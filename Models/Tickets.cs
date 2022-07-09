namespace Models;                             //This page contains the necessary components
                                              //for the Tickets to be submitted.
public class Ticket                           //Ticket class...
{
    public int ticketId { get; set; }         //Unique TicketID number for search and organization.
    public string author { get; set; }        //Name of the creator of the ticket submission.
    public string resolver { get; set; }      //Whether the ticket will be approved or not.
    public string description { get; set; }   //Description of expenses to be reimbursed.
    public string managerNote { get; set; }   //Manager can ask for more information or provide detail.
    public decimal amount { get; set; }       //Total amount of money to be reimbursed.
    
    public Ticket()                           //Constructor in order to intitialize ticket submissions.
    {
        ticketId = 0;                         
        author = "";
        resolver = "";                        //        "     "   
        description = "";
        managerNote = "";
        amount = 0;
    }

    public Ticket(decimal amount)             //Second constructor, will create more as necessary.
    {
        this.amount = amount;                 //Specify reimbursement total.
    }
}