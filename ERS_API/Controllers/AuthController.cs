using Exceptions;
using Models;
using Services;

namespace ErsAPI.Controllers;

public class AuthController
{
    private readonly AuthService _service;

    public AuthController(AuthService service)
    {
        _service = service;
    }

    public IResult RegisterUser(Users userToRegister)
    {
        Console.WriteLine(userToRegister.ToString());

        if(userToRegister.userName == null)
        {
            return Results.BadRequest("Name cannot be null");
        }
        try
        {
            _service.RegisterUser(userToRegister);
            return Results.Created("/register", userToRegister);
        }
        catch(DuplicateRecord)
        {
        return Results.Conflict("User with this username already exists.");
        }
    }
}