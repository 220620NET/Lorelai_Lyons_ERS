using System.Text.Json;
using System.Text.Json.Serialization;

namespace Models;                              /*This page contains the necessary components for the users class
                                                 to be submitted, edited, and used throughout the application*/

public enum Role                               //Used to define the list of eligible roles users may have.
{
    Employee,
    Manager
}

public class Users                             //User class...
{
    [JsonIgnore]
    public int userId { get; set; }            //Unique employee ID number. 
    public string legalName { get; set; }      //Employee's legal name.     
    public string userName { get; set; }       //Unique and custom employee login username.
    public string password { get; set; }       //Custom defined employee login password.
    public Role role { get; set; }             //Enter employee role. Defaults to 'Employee.'

    public Users() {}                                  

    public Users(string userName, string password)                             //Constructor for user login.          
    {                                
        this.userName = userName;                                    
        this.password = password;              //   "    "                                                                     
    }

    public Users(string legalName, string userName, string password, int role) //Used for new user registering personal information into DB.
    {
        this.legalName = legalName;
        this.userName = userName;              //   "    "
        this.password = password;
        this.role = (Role) role;
    }

    public Users(int userId, string legalName, string userName, string password, Role role)//used for accessing and displaying information from DB.          
    {
        this.userId = userId; 
        this.legalName = legalName;                          
        this.userName = userName;              //   "    "        
        this.password = password;                                                      
        this.role = role;                                        
    }

    public int RoleToNum(string userEntry)                                     //Casts 'role' as an integer to pass back and forth between database and application.
    {
        if(userEntry == "Manager")             //Sets role as 1 if 'Manager is entered...
        {
            return 1;
        }
        else { return 0; }                     //or if 'Employeee' or null, defaults to 0.
    }

    public string RoleToString(Role role)                                      //Casts 'role' as an string to pass back and forth between database and application.
    {
        if(role == Role.Employee)              //Sets role as 'Manager' if 1 is entered...
        {
            return "Employee";
        }
        else { return "Manager"; }             //or if user enters 0 or null, defaults to 'Employee' role.
    }

    public override string ToString()                                          //Prints all ticket information as a string to the console.
    { 
        return $"UserId: {this.userId}, Legal Name: {this.legalName}, Userame: {this.userName}, Role: {RoleToString(this.role)}";
    }   
}