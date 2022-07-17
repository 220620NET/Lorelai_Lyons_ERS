using Models;
using DataAccess;
using Exceptions;

namespace Services
{
    public class AuthService
    {
        
        private readonly IUserDAO _user;

        public AuthService(IUserDAO userDAO)
        {
            _user = userDAO;
        }
        /*
        public AuthService(IUsersDAO usersDAO)
        {
            _user = usersDAO;
        }
        */

        /*
        public Users Login(string username, string password)
        {
            Users user;
            try
            {
                user = _user.GetUserByUsername(username);
                if (user.username == "")
                {
                    throw new ResourceNotFoundException();
                }
                if (user.password == password)
                {
                    return user;
                }
                else { throw new InvalidCredentialsException(); }
            }
            catch (ResourceNotFoundException)
            {
                throw new ResourceNotFoundException();
            }
            catch (InvalidCredentialsException)
            {
                throw new InvalidCredentialsException();
            }
        }
        */
        public bool RegisterUser(Users newUser)
        {
            try
            {
                Users creationInstance = _user.GetUserByUserName(newUser.userName);
                
                if(creationInstance.userName == newUser.userName)
                {
                    throw new UsernameNotAvailable();
                }
                else if (newUser.userName == "" || newUser.userName.Contains(";") || newUser.userName.Contains("drop"))
                {
                    throw new UsernameNotAvailable();
                }
                else
                {
                    return _user.RegisterUser(newUser);
                }
            }
            catch(UsernameNotAvailable)
            {
                throw new UsernameNotAvailable();                
            }            
        }
    }
}