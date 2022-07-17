namespace Models;                              //This page contains the necessary components.

public enum Role                               //List of eligible roles.
{
    Employee,
    Manager
}

public class Users                            //Define the user class.
{
    public int userId { get; set; }           //Unique employee ID number. 
    public string legalName { get; set; }     //Employee's legal name.     
    public string userName { get; set; }      //Unique and custom employee login username.
    public string password { get; set; }     //Custom defined employee login password.
    public Role role { get; set; }            //Enter employee role.

    public Users() {}                                   
    
    public Users(int userId, string legalName,string userName, string password, Role role)//use for accessing DB          
    {
        this.userId = userId; 
        this.legalName = legalName;                                 
        this.userName = userName;                                    
        this.password = password;                         //   "    "                             
        this.role = role;                                        
    }

    public Users(string legalName, string userName, string password, Role role)//used for entering information into DB          
    {
        this.legalName = legalName;                          
        this.userName = userName;                                    
        this.password = password;                         //   "    "                             
        this.role = role;                                        
    }

    public Users(string legalName, string userName, string password, int role)
    {
        this.legalName = legalName;
        this.userName = userName;
        this.password = password;
        this.role = (Role) role;
    }


    public int RoleToNum(string userEntry)
    {
        if(userEntry == "Manager")
        {
            return 1;
        }
        else { return 0; }
    }

    public string RoleToString(Role role)
    {
        if(role == Role.Employee)
        {
            return "Employee";
        }
        else { return "Manager"; }
    }

    public override string ToString()
    { 
        return $"UserId: {this.userId}, Legal Name: {this.legalName}, Userame: {this.userName}, Role: {RoleToString(this.role)}";
    }
    /*
    public Role StringToRole(string input)
    {
        Dictionary<string,Role> declareRole = new Dictionary<string, Role>()
        {
            {"Employee", Role.Employee},
            {"Manager", Role.Manager}
        };

        return declareRole[input];
    }

    public String RoleToString(Role input)
    {
        Dictionary<Role,string> declareRole = new Dictionary<Role, string>()
        {
            {Role.Employee, "Employee"},
            {Role.Manager, "Manager"}
        };

        return declareRole[input];
    }
    */
}