using DataAccess;
using Exceptions;
using Models;
using Services;                                    

var builder = WebApplication.CreateBuilder(args);
                                                    //(below)Adding our Connection Factory to DB
builder.Services.AddSingleton<ConnectionFactory>(ctx => ConnectionFactory.GetInstance(builder.Configuration.GetConnectionString("ErsDB"))); 

builder.Services.AddScoped<IUserDAO, UserRepository>();    //Adding both of our repositories
builder.Services.AddScoped<ITicketDAO, TicketRepository>();//          "   " 
builder.Services.AddTransient<AuthService>();          //Adding a dependency to AuthServices.
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<TicketService>();

builder.Services.AddEndpointsApiExplorer();         //These two instruct our program that we will
builder.Services.AddSwaggerGen();                   //be using swagger to explore our program.

var app = builder.Build();                          //Builds our WebAPI.

app.UseSwagger();                                   //Swagger generates documentation for us.
app.UseSwaggerUI();                                 //                  "   "

app.MapGet("/", () => "Hello World!");              //Default endpoint.

app.MapGet("/users", () =>
{
    var scope = app.Services.CreateScope();
    UserService getAll = scope.ServiceProvider.GetRequiredService<UserService>();

    return getAll.GetAllUsers();
});


app.MapGet("/tickets", () =>
{
    var scope = app.Services.CreateScope();
    TicketService getAll = scope.ServiceProvider.GetRequiredService<TicketService>();

    return getAll.GetAllTickets();
});

app.MapPost("/register", (Users user) =>
{
    var scope = app.Services.CreateScope();
    AuthService register = scope.ServiceProvider.GetRequiredService<AuthService>();

    try
    {
       register.RegisterUser(user);
       return Results.CreatedAtRoute("Registration success."); 
    }
    catch(DuplicateRecord)
    {
        return Results.Conflict("User with this username already exists.");
    }
});   

app.Run();                                          //Runs the application!!
/*
app.MapPost("/userbyusername", (Users user) =>
{
    var scope = app.Services.CreateScope();
    UserService byUserName = scope.ServiceProvider.GetRequiredService<UserService>();

    try
    {   
        byUserName.GetUserByUserName(user.userName);
        return Results.CreatedAtRoute("Cool here are the results");
    }
    catch(InvalidCredentials)
    {
        return Results.Conflict("No user with this name exists.");
    }
});
*/