using Exceptions;
using Models;
using Services;
using DataAccess;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace UI;

public class MainMenu
{
    public void Begin()
    {
        {
        /*
        private readonly AuthServices _auth;
        public FirstScreen(AuthServices auth)
        {
            _auth = auth;
        }    
        */
        bool running = true;

        while(running == true)
            {
            Console.WriteLine("Employee Reimbursement System [ERS]\n1) Get all usrs\n2) Register\n3) GetUserByUserName\n0) EXIT");

            AuthService authServices = new AuthService();

            UserService userServices = new UserService();

            TicketService ticketServices = new TicketService();

            string? mainInput = Console.ReadLine();

            switch (mainInput)
                {
                case "1":

                    List<Users> usersInRepo = userServices.GetAllUsers();
                    foreach (Users user in usersInRepo)
                    {
                        Console.WriteLine(user);
                    }

                    List<Tickets> ticketsInRepo = ticketServices.GetAllTickets();
                    foreach (Tickets ticket in ticketsInRepo)
                    {
                        Console.WriteLine(ticket);
                    }

                    break;

                case "2":

                    Users newUser = new Users();
                    //Registering a user
                    Console.WriteLine("Registering a user...\n");

                    Console.WriteLine("Begin by entering your legal name:");

                    newUser.legalName = Console.ReadLine();

                    Console.WriteLine("Please enter a username:");

                    newUser.userName = Console.ReadLine();

                    Console.WriteLine("Please enter a password:");

                    newUser.password = Console.ReadLine();
                    
                    Console.WriteLine("Are you an employee? [y/n]:");

                    char roleReader = Console.ReadLine()[0];

                    if(roleReader == 'y')
                    {
                        newUser.role = Role.Employee;
                    }
                    else
                    {
                        newUser.role = Role.Manager;
                    }
                    try
                    {
                        return authServices.RegisterUser(newUser);
                    }
                    catch (InvalidCredentials)
                    { 
                        throw new InvalidCredentials("nahhhh.");
                    } 
                    
                    break;

                case "3":
                    Console.WriteLine("Okay, pls enter a username that you would like to look up:");

                    string input = Console.ReadLine();

                    return userServices.GetUserByUserName(input);

                    break;

                case "0":

                    //exit
                    running = false;
                    break;

                default:

                    Console.WriteLine("Invalid Input");
                    break;
                }
            }
        }
    }
}