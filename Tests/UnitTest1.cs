/*
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
    public void RegisterShouldRegisterNonExistingUser()
    {
        var moqRepo = new Mock<IUserDAO>();

        Users testUser = new Users
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

        moqRepo.Setup(repo => repo.SearchByUserName(testUser.userName)).Throws(new ResourceNotFound());
        moqRepo.Setup(repo => repo.RegisterUser(testUser)).Return(userToReturn);

        AuthService service = new AuthService(moqRepo.Object);

        //Act
        Users returnedUser = service.RegisterUser(testUser);

        //Assert (Verification)
        moqRepo.Verify(repo => repo.GetUserByUserName(testUser.userName), Times.Once());
        moqRepo.Verify(repo => repo.RegisterUser(testUser), Times.Once());

        //Verifying that the returned result is the same as what we've sent as well as what we've had the mock repository to respond with
        Assert.NotNull(returnedUser);
        Assert.Equal(returnedUser.userId, userToReturn.userId);
        Assert.Equal(returnedUser.userName, testUser.userName);
    }

    [Fact]
    public void RegisterShouldNotRegisterExistingUser()
    {
        var moqRepo = new Mock<IUserDAO>();

        Users testUser = new Users
        {
            legalName = "Name",
            userName = "Name123",
            password = "passw0rd!",
            role = 0
        };

        Users userToReturn = new Users
        {
            Id = 1,
            legalName = "Name",
            userName = "Name123",
            password = "passw0rd!",
            role = 0
        };

        moqRepo.Setup(repo => repo.GetUsersByUserName(testUser.userName)).Return(userToReturn);

        AuthService service = new AuthService(moqRepo.Object);

        //Act + Assert (Verification)
        Assert.Throws<DuplicateRecord>(() => service.RegisterUser(testUser));
        
        moqRepo.Verify(repo => repo.GetUserByUserName(testUser.userName),Times.Once());
    }
}
*/