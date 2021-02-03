using Carguero.Domain.Entities;
using Carguero.Domain.Repositories;
using Carguero.Domain.Services;
using Carguero.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carguero.Tests.Services
{
    [TestClass]
    public class AddressServiceTest
    {
        private Mock<IAddressRepository> _addressRepositoryMock;
        private Mock<IUserRepository>  _userRepositoryMock;
        private Mock<IGoogleMapsApi> _googleMapsApiMock;

        public GoogleMapsCandidatesAddress _googleMapsCandidatesAddress;
        public int _userId1;
        public int _userId25;
        public User _user1;
        public Address _address;


        public AddressServiceTest()
        {
            _addressRepositoryMock = new Mock<IAddressRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _googleMapsApiMock = new Mock<IGoogleMapsApi>();

            _googleMapsCandidatesAddress = new GoogleMapsCandidatesAddress();
            var googleMapsCandidates = new List<GoogleMapsCandidates>();
            var mapsCadidate = new GoogleMapsCandidates();
            mapsCadidate.FormattedAddress = "Centro, Campo Grande - MS, 79000-000, Brasil";
            googleMapsCandidates.Add(mapsCadidate);
            _googleMapsCandidatesAddress.GoogleMapsCandidates = googleMapsCandidates;

            _userId1 = 1;
            _userId25 = 25;
            _user1 = new User("igor");
            _user1.Id = _userId1;

            _address = new Address("79000-000", 123, "Campo Grande", "Centro", null, "Mato Grosso do Sul", _userId1);
        }

        [TestMethod]
        public async Task ShoulRegisterAddressForExistingUser()
        {
            
            var addressService = new AddressService(_addressRepositoryMock.Object, _userRepositoryMock.Object, _googleMapsApiMock.Object);

            _userRepositoryMock.Setup(ur => ur.GetById(_userId1)).Returns(_user1);            
            _googleMapsApiMock.Setup(maps => maps.SearchAddress(addressService.FormatAddressForMapsApi(_address))).Returns(Task.FromResult(_googleMapsCandidatesAddress)); ;

            var addressRegistered = _address;
            addressRegistered.SetId(_userId1);
            _addressRepositoryMock.Setup(ar => ar.SaveAsync(_address)).Returns(Task.FromResult(_address));

            bool registered = await addressService.RegisterAddress(_address);

            Assert.IsTrue(registered);
        }
        [TestMethod]
        public async Task ShoulNotRegisterAddressForExistingUser()
        {
            var addressRepositoryMock = new Mock<IAddressRepository>();
            

            var addressService = new AddressService(addressRepositoryMock.Object, _userRepositoryMock.Object, _googleMapsApiMock.Object);

            _userRepositoryMock.Setup(ur => ur.GetById(_userId1)).Returns((User)null);

            var address = new Address("79000-000", 123, "Campo Grande", "Centro", null, "Mato Grosso do Sul", _userId25);
            
            bool registered = await addressService.RegisterAddress(address);

            Assert.IsFalse(registered);
        }
    }
}
