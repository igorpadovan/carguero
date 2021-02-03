using Carguero.Domain.Repositories;
using Carguero.Entities;
using System.Threading.Tasks;

namespace Carguero.Domain.Services
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRespository;
        public AddressService(IAddressRepository addressRespository)
        {
            _addressRespository = addressRespository;
        }

        public Task<bool> RegisterAddress(Address address)
        {
            throw new System.NotImplementedException();
        }
    }
}
