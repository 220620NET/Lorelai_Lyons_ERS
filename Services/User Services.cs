using Exceptions;
using Models;
using DataAccess;

namespace Services
{
    public class UserService
    {
        private readonly IUserDAO _userDAO;
        
        public UserService(IUserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        //public UserRepository userRepo = new UserRepository(); //I had this as private but changed it to public....

        public List<Users> GetAllUsers()
        {
            return _userDAO.GetAllUsers();
        }

        public Users GetUserByUserName(string userName)
        {
            try
            {
                return _userDAO.GetUserByUserName(userName);
            }
            catch(UsernameNotAvailable)
            {
                throw new UsernameNotAvailable();
            }
        }

        public Users GetUserByUserId(int userId)
        {
            try
            {
                return _userDAO.GetUserByUserId(userId);
            }
            catch(UsernameNotAvailable)
            {
                throw new UsernameNotAvailable();
            }
        }
    }
}