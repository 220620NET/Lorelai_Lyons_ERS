using Models;
using Repository;

namespace UserServices
{
    public class UserService
    {
        private UserRepository userRepo = new UserRepo();

        public List<Users> GetAllUsers(){
            return userRepo.GetAllUsers();
        }

        public bool CreateUser(Users user){
            // since there isnt really business logic anywhere in this app, I made up a requirement that descriptions of todos can be only 10 characters long
            return todoDao.CreateTodo(todo);

        }

        public void DeleteOneTodo(int todoId){
            todoDao.DeleteOneTodo(todoId);
        }


    }
}