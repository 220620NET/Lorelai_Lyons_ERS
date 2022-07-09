﻿using Models;
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
        Console.WriteLine("This is the employee reimbursement system");
        Console.WriteLine("To begin, please enter your full name as you wish for it to appear in our records: \n");

        User employee1 =  new User();

        employee1.SetLegalName(Console.ReadLine());

        Console.WriteLine("You entered " + $": {employee1.legalName}\n" + " is that correct? Y/N \n");

        Console.WriteLine("Please enter your Username");

        employee1.SetUserName(Console.ReadLine());

        Console.WriteLine("You entered " + $": {employee1.userName}\n" + " is that correct? Y/N \n");

        Console.WriteLine("Please enter your role");

        employee1.SetRole(Console.ReadLine());

        Console.WriteLine("You entered " + $": {employee1.role}\n" + " is that correct? Y/N \n");

        Console.WriteLine("Your legal name is " + $": {employee1.legalName}");
        Console.WriteLine("Your username is " + $": {employee1.userName}");
        Console.WriteLine("Your role is " + $": {employee1.role}");
        Console.WriteLine("Your user ID number is " + $": {employee1.userID}");

        Console.WriteLine("Is all of that correct?");

        Ticket newTix = new Ticket(10.00M);
        Console.WriteLine(newTix.amount);

        List<Users> userList = UserRepository.GetAllUsers();
            Console.WriteLine($"Amount of Todos: {userList.Count()}");
            foreach (Users users in userList)
            {
                Console.WriteLine(users);
            }
        }
    }
}