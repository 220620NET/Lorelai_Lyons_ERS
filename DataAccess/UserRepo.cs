using Models;
using System.Data.SqlClient;

namespace DataAccess
{
    public interface UsersDAO
    {
        public List<Users> GetAllUsers();
        //public bool CreateTodo(Todo todo);
        //public void DeleteOneTodo(int todoId);
    }
}