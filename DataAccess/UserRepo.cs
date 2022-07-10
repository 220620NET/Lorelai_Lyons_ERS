using Models;
using Sensitive;
using System.Data.SqlClient;

namespace UserRepo
{
    public interface UsersDAO
    {
        public List<Users> GetAllUsers();
        //public bool CreateTodo(Todo todo);
        //public void DeleteOneTodo(int todoId);
    }
}