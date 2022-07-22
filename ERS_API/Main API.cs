using DataAccess;
using ErsAPI.Controllers;
using Exceptions;
using Models;
using Services;                                    

var builder = WebApplication.CreateBuilder(args);
                                                    //(below)Adding our Connection Factory to DB
builder.Services.AddSingleton<ConnectionFactory>(ctx => ConnectionFactory.GetInstance(builder.Configuration.GetConnectionString("ErsDB"))); 

builder.Services.AddScoped<IUserDAO, UserRepository>();    //Adding both of our repositories
builder.Services.AddScoped<ITicketDAO, TicketRepository>();//          "   " 
builder.Services.AddScoped<AuthController>();
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<TicketController>();
builder.Services.AddTransient<AuthService>();          //Adding a dependency to AuthServices.
builder.Services.AddTransient<UserService>();          //I may not need services references w/controllers?
builder.Services.AddTransient<TicketService>();

builder.Services.AddEndpointsApiExplorer();         //These two instruct our program that we will
builder.Services.AddSwaggerGen();                   //be using swagger to explore our program.

var app = builder.Build();                          //Builds our WebAPI.

app.UseSwagger();                                   //Swagger generates documentation for us.
app.UseSwaggerUI();                                 //                  "   "

//user search methods
app.MapGet("/users/allUsers", (UserController controller) => controller.GetAllUsers());

app.MapGet("/users/userName/{userName}", (string userName, UserController controller) => controller.UserNameSearch(userName));

app.MapGet("/users/userId/{userId}", (int userId, UserController controller) => controller.UserIdSearch(userId));

//Ticket search methods
app.MapGet("/getAllTickets", (TicketController controller) => controller.GetAllTickets());

app.MapGet("/tickets/ticketId/{ticketId}", (int ticketId, TicketController controller) => controller.TicketIdSearch(ticketId));

app.MapGet("/tickets/authorId/{authorId}", (int authorId, TicketController controller) => controller.AuthorIdSearch(authorId));

app.MapGet("/tickets/ticketStatus/{ticketStatus}", (Status status, TicketController controller) => controller.TicketStatusSearch(status));

//user features
app.MapPut("/tickets/update", (Tickets ticket, TicketController controller) => controller.Update(ticket));

app.MapPost("/tickets/submission", (Tickets ticket, TicketController controller) => controller.Submit(ticket));

app.MapPost("/register", (Users user, AuthController controller) => controller.Register(user));

app.MapPost("/login", (Users user, AuthController controller) => controller.Login(user));   

app.MapDelete("/tickets/delete", (int ticketId, TicketController controller) => controller.Delete(ticketId));

app.MapDelete("/users/delete", (int userId, UserController controller) => controller.DeleteAccount(userId));

app.Run();                                          //Runs the application!!

//INSERT INTO Issues(Title, Content, DateCreated) OUTPUT INSERTED.Id VALUES (@title, @content, @date)
//ExecuteScalar - returns first column of first row

