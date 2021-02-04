using Carguero.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carguero.Domain.Services
{
    public interface IAddressService
    {
        Task<bool> RegisterAddress(Address address);
        Task<bool> UpdateAddress(Address address);
        Task<bool> IsBrazilianAddress(Address address);
        string FormatAddressForMapsApi(Address address);
        List<Address> GetAddressesByUsername(string username);
    }
}
