/*                                      //Basic Outline for my hashing/salting
using Exceptions;
using Models;
using System;
using System.Data;
using System.Data.SqlClient; //to use this I need to go to git and use command 'git add package System.Data.SqlClient'
using System.Text;
using System.Security.Cryptography;

namespace DataAccess
{
    public class Encrypts : IEncryptionDAO
    {
        private readonly ConnectionFactory _connectionFactory;
    
        public TicketRepository(ConnectionFactory factory)
        {
            _connectionFactory = factory;
        }

        public Users HashPass(string password)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(password);
            var hashedPass = sha.ComputeHash(asByteArray);
            return Convert.ToBase64String(hashedPassword); 
        }

        public 

        public Users StoredPassword(string password)
        {
            Console.WriteLine("Please Enter your password");

            userPassword = Console.ReadLine();

            while(true)
            {
                try
                {
                userPassword = hashPass(password);  
                if(userPassword.Equals(password))
                {
                    Console.WriteLine("Password Success");
                }
                }
                catch
                {
                    throw new InvalidCredentials();
                }
                return false;
            }
        }

        public Users SaltHash(string password)
        {
            random randomString = new random();


        }
    }
}
*/