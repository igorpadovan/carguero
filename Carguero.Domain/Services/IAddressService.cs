using Carguero.Entities;
using System.Threading.Tasks;

namespace Carguero.Domain.Services
{
    public interface IAddressService
    {
        Task<bool> RegisterAddress(Address address);
        Task<bool> UpdateAddress(Address address);
        Task<bool> IsBrazilianAddress(Address address);
        string FormatAddressForMapsApi(Address address);
    }
}
