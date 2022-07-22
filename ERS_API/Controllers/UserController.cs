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

    public IResult UserNameSearch(string userName)
    {
        try
        {   
            Users queriedUser = _service.SearchByUserName(userName);
            return Results.Created("/users/userName/{userName}", queriedUser);
        }
        catch(InvalidCredentials)
        {
            return Results.BadRequest("No user with this name exists.");
        }
    }

    public IResult UserIdSearch(int userId)
    {
        try
        {   
            Users queriedUser = _service.SearchByUserId(userId);
            return Results.Created("/users/userId/{userId}", queriedUser);
        }
        catch(InvalidCredentials)
        {
            return Results.BadRequest("No user with this userId exists.");
        }
    }

    public IResult DeleteAccount(int userId)
    {
        try
        {
            _service.DeleteUser(userId);
            return Results.Ok(userId);
        }
        catch(ResourceNotFound)
        {
            return Results.Conflict("No user with this ID exists.");
        }
    }
}