using Carguero.Domain.Repositories;
using Carguero.Entities;
using System.Threading.Tasks;

namespace Carguero.Domain.Services
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRespository;
        private IUserRepository _userRepository;
        private IGoogleMapsApi _googleMapsApi;
        public AddressService(
            IAddressRepository addressRespository,
            IUserRepository userRepository,
            IGoogleMapsApi googleMapsApi)
        {
            _addressRespository = addressRespository;
            _userRepository = userRepository;
            _googleMapsApi = googleMapsApi;
        }

        public async Task<bool> RegisterAddress(Address address)
        {
            var user =  _userRepository.GetById(address.UserId);
            if (user == null)
                return false;
            address.setUser(user);

            bool iSBrazilianAddress =  await IsBrazilianAddress(address);

            await _addressRespository.SaveAsync(address);
            return (address.Id > 0);
        }

        public async Task<bool> IsBrazilianAddress(Address address)
        {
            var googleMapsAddress = await _googleMapsApi.SearchAddress(address);

            return false;
        }
    }
}
