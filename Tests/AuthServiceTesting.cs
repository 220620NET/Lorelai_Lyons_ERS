using Exceptions;
using Moq;
using Models;
using Services;
using DataAccess;
using System;
using Xunit;
using System.Threading.Tasks;

namespace Tests;

public class AuthServiceTest
{
    [Fact]
    public void TestDuplicateUserRegister()
    {
        var moqRepo = new Mock<IUserDAO>(); //maybe repo here

        Users userToAdd = new Users
        {
            legalName = "Name",
            userName = "Name123",
            password = "passw0rd!",
            role = 0
        };

        Users userToReturn = new Users
        {
            userId = 1,
            legalName = "Name",
            userName = "Name123",
            password = "passw0rd!",
            role = 0
        };

        moqRepo.Setup(repo => repo.GetUserByUserName(userToAdd.userName)).Returns(userToReturn);

        AuthService service = new AuthService(moqRepo.Object);
       
        Xunit.Assert.Throws<UsernameNotAvailable>(() => service.RegisterUser(userToAdd));
        
        moqRepo.Verify(repo => repo.GetUserByUserName(userToAdd.userName), Times.Once());
    }
    /*
    [Fact]
    public void TestUserNameLoginFail()
    {
        var moqRepo = new Mock<IUserDAO>(); //maybe repo here

        Users userToAdd = new Users
        {
            legalName = "Name",
            userName = "Name123",
            password = "passw0rd!",
            role = 0
        };

        Users userToReturn = new Users
        {
            userId = 1,
            legalName = "Name",
            userName = "Name12345",
            password = "passw0rd!",
            role = 0
        };

        moqRepo.Setup(repo => repo.GetUserByUserName(userToAdd.userName)).Returns(userToAdd);//maybe throws here
        moqRepo.Setup(repo => repo.GetUserByUserName(userToReturn.userName)).Throws<UsernameNotAvailable>();;

        AuthService service = new AuthService(moqRepo.Object);
       
        Assert.Throws<InvalidCredentials>(() => service.Login(userToAdd));
        
        moqRepo.Verify(repo => repo.GetUserByUserName(userToAdd.userName), Times.Once());
    }

    [Fact]
    public void TestPasswordLoginFail()
    {
        var moqRepo = new Mock<IUserDAO>(); //maybe repo here

        Users userToAdd = new Users
        {
            legalName = "Name",
            userName = "Name123",
            password = "passw0rd!",
            role = 0
        };

        Users userToReturn = new Users
        {
            userId = 1,
            legalName = "Name",
            userName = "Name123",
            password = "p@ssw0rd!",
            role = 0
        };

        moqRepo.Setup(repo => repo.GetUserByUserName(userToAdd.userName)).Returns(userToReturn);//maybe throws here

        AuthService service = new AuthService(moqRepo.Object);
       
        Assert.Throws<InvalidCredentials>(() => service.Login(userToAdd));
        
        moqRepo.Verify(repo => repo.GetUserByUserName(userToAdd.userName), Times.Once());
    }*/    
}