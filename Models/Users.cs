namespace Models;                              //This page contains the necessary components

public class Users                              //to define the user class.
{
    public int userID{ get; set; }             //Unique employee ID number. 
    public string legalName{ get; set; }       //Employee's legal name     
    public string userName{ get; set; }        //Unique and custom employee login username.
    private string password{ get; set; }       //Custom defined employee login password.
    public string role{ get; set; }            //Enter employee role                                   
    
    //public User()                              //Constructor for the user class.           
    //{
        //legalName = "";
       // userID = 0;                            
        //userName = "";                                    
        //password = "";                         //   "    "                             
        //role = "";                                        
    //}

    public void SetLegalName(string legalnameToSet)
    {
        this.legalName = legalnameToSet;
    }

    public void SetUserName(string usernameToSet)  //Setname method allows user to choose login username.
    {
        this.userName = usernameToSet;
    }

    public void SetPass(string customPass)        //SetPass method allows user to choose password name.
    {
        this.password = customPass;
    }

    public void SetRole(string userRole)          //SetRole method allows user to enter employee role
    {
        this.role = userRole;
    }
}