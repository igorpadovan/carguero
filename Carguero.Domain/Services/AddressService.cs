using Carguero.Domain.Repositories;
using Carguero.Entities;
using System.Threading.Tasks;

namespace Carguero.Domain.Services
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRespository;
        private IUserRepository _userRepository;
        public AddressService(IAddressRepository addressRespository, IUserRepository userRepository)
        {
            _addressRespository = addressRespository;
            _userRepository = userRepository;
        }

        public async Task<bool> RegisterAddress(Address address)
        {
            var user =  _userRepository.GetById(address.UserId);
            if (user == null)
                return false;
            address.setUser(user);
            await _addressRespository.SaveAsync(address);
            return (address.Id > 0);
        }
    }
}
