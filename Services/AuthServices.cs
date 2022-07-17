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

        public Users Login(string userName, string password)
        {
            Users user;
            try
            {
                user = _user.GetUserByUserName(userName);
                if (user.userName == "")
                {
                    throw new ResourceNotFound();
                }
                if (user.password == password)
                {
                    return user;
                }
                else { throw new InvalidCredentials(); }
            }
            catch (ResourceNotFound)
            {
                throw new ResourceNotFound();
            }
            catch (InvalidCredentials)
            {
                throw new InvalidCredentials();
            }
        }
        
        public Users RegisterUser(Users newUser)
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
                    Users user = _user.RegisterUser(newUser);
                    return user;
                }
            }
            
            catch(UsernameNotAvailable)
            {
                throw new UsernameNotAvailable();                
            }

            catch(ResourceNotFound)
            {
                return _user.RegisterUser(newUser);
            }
        }
    }
}