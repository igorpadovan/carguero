using Carguero.Domain.Data;
using Carguero.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Carguero.Domain.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private CargueroDbContext _cargueroDbContext;
        public AddressRepository(CargueroDbContext cargueroDbContext)
        {
            _cargueroDbContext = cargueroDbContext;
        }
        public Address GetById(int id)
        {
            return _cargueroDbContext.Addresses.Where(u => u.Id == id).FirstOrDefault();
        }

        public async Task<Address> Save(Address address)
        {
            _cargueroDbContext.Addresses.Add(address);
            await _cargueroDbContext.SaveChangesAsync();
            return address;
        }
    }
}
