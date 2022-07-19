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

    public IResult Login(Users userToLogin)
    {
        
        if(userToLogin.userName == null || userToLogin.password == null)
        {
            return Results.BadRequest("Name cannot be null");
        }
        try
        {
            userToLogin = _service.Login(userToLogin.userName, userToLogin.password);
            return Results.Ok(userToLogin);
        }
        catch(InvalidCredentials)
        {
            return Results.Unauthorized();
        }
    }

    public IResult RegisterUser(Users userToRegister)
    {
        //Console.WriteLine(userToRegister.ToString());     //If I want to print to console

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