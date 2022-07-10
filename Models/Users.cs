namespace Models;                              //This page contains the necessary components

public class Users                              //to define the user class.
{
    public int userID { get; set; }             //Unique employee ID number. 
    public string legalName { get; set; }       //Employee's legal name     
    public string userName { get; set; }        //Unique and custom employee login username.
    private string password { get; set; }       //Custom defined employee login password.
    public string role { get; set; }            //Enter employee role                                   
    
    public Users(string legalName, int userID, string userName, string password, string role)//use for accessing DB          
    {
        this.legalName = legalName;
        this.userID = userID;                            
        this.userName = userName;                                    
        this.password = password;                         //   "    "                             
        this.role = role;                                        
    }

    public Users(string legalName, string userName, string password, string role)//used for entering information into DB          
    {
        this.legalName = legalName;                          
        this.userName = userName;                                    
        this.password = password;                         //   "    "                             
        this.role = role;                                        
    }

    public override string ToString()
    {
        return "userID: " + this.userID + "\t LegalName" + this.legalName + "\t Username: " + this.userName + "\t Role: " + this.role;
    }
}