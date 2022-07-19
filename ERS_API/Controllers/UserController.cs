using Exceptions;
using Models;
using Services;

namespace ErsAPI.Controllers;

public class UserController
{
    private readonly UserService _service;

    public UserController(UserService service)
    {
        _service = service;
    }

    public IResult GetAllUsers()
    {
        List<Users> userList = _service.GetAllUsers();
        return Results.Accepted("/users/allUsers", userList);
    }

    public IResult GetUserByUserName(string userName)
    {
        try
        {   
            Users queriedUser = _service.GetUserByUserName(userName);
            return Results.Created("/users/userName/{userName}", queriedUser);
        }
        catch(InvalidCredentials)
        {
            return Results.BadRequest("No user with this name exists.");
        }
    }

    public IResult GetUserByUserId(int userId)
    {
        try
        {   
            Users queriedUser = _service.GetUserByUserId(userId);
            return Results.Created("/users/userId/{userId}", queriedUser);
        }
        catch(InvalidCredentials)
        {
            return Results.BadRequest("No user with this userId exists.");
        }
    }
}