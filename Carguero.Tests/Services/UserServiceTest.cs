using Carguero.Domain.Repositories;
using Carguero.Domain.Services;
using Carguero.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carguero.Tests.Services
{
    [TestClass]
    public class UserServiceTest
    {

        [TestMethod]
        public async Task ShoulNotRegisterDuplicatedUsername()
        {
            
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);
            var user = new User("igor");

            userRepositoryMock.Setup(ur => ur.GetByUsername("igor")).Returns(user);

            var createdUser = userService.CreateUser(user);
            Assert.IsFalse(createdUser);
        }
    }
}
