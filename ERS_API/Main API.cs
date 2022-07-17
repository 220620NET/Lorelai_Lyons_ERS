using DataAccess;
using Services;                                    

var builder = WebApplication.CreateBuilder(args);
                                                    //(below)Adding our Connection Factory to DB
builder.Services.AddSingleton<ConnectionFactory>(ctx => ConnectionFactory.GetInstance(builder.Configuration.GetConnectionString("ErsDB"))); 

builder.Services.AddScoped<IUserDAO, UserRepository>();    //Adding both of our repositories
builder.Services.AddScoped<ITicketDAO, TicketRepository>();//          "   " 
builder.Services.AddTransient<AuthService>();          //Adding a dependency to AuthServices.

builder.Services.AddEndpointsApiExplorer();         //These two instruct our program that we will
builder.Services.AddSwaggerGen();                   //be using swagger to explore our program.

var app = builder.Build();                          //Builds our WebAPI.

app.UseSwagger();                                   //Swagger generates documentation for us.
app.UseSwaggerUI();                                 //                  "   "

app.MapGet("/", () => "Hello World!");              //Default endpoint.

app.MapGet("/users", () => new UserService(new UserRepository(ConnectionFactory.GetInstance(builder.Configuration.GetConnectionString("ErsDB")))).GetAllUsers());

app.Run();                                          //Runs the application!!
