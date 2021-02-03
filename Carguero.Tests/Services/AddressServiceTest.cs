using Carguero.Domain.Repositories;
using Carguero.Domain.Services;
using Carguero.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace Carguero.Tests.Services
{
    [TestClass]
    public class AddressServiceTest
    {
        [TestMethod]
        public async Task ShoulRegisterAddressForExistingUser()
        {
            var addressRepositoryMock = new Mock<IAddressRepository>();
            var userId1 = 1;

            var user = new User("igor");
            user.Id = userId1;
            var userRepositoryMock = new Mock<IUserRepository>();
            var addressService = new AddressService(addressRepositoryMock.Object, userRepositoryMock.Object);

            userRepositoryMock.Setup(ur => ur.GetById(userId1)).Returns(user);            

            var address = new Address("79000-000", 123, "Campo Grande", "Centro", null, "Mato Grosso do Sul", userId1);
            var addressRegistered = address;
            addressRegistered.SetId(userId1);
            addressRepositoryMock.Setup(ar => ar.SaveAsync(address)).Returns(Task.FromResult(address));
            bool registered = await addressService.RegisterAddress(address);

            Assert.IsTrue(registered);
        }
        [TestMethod]
        public async Task ShoulNotRegisterAddressForExistingUser()
        {
            var addressRepositoryMock = new Mock<IAddressRepository>();
            var userId1 = 25;

            var user = new User("fulano");
            user.Id = userId1;
            var userRepositoryMock = new Mock<IUserRepository>();
            var addressService = new AddressService(addressRepositoryMock.Object, userRepositoryMock.Object);

            userRepositoryMock.Setup(ur => ur.GetById(userId1)).Returns((User)null);

            var address = new Address("79000-000", 123, "Campo Grande", "Centro", null, "Mato Grosso do Sul", userId1);
            
            bool registered = await addressService.RegisterAddress(address);

            Assert.IsFalse(registered);
        }
    }
}
