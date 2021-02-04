using Carguero.Domain.Data;
using Carguero.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<Address> SaveAsync(Address address)
        {
            _cargueroDbContext.Addresses.Add(address);
            await _cargueroDbContext.SaveChangesAsync();
            return address;
        }

        public async Task<Address> UpdateAsync(Address address)
        {
            _cargueroDbContext.Addresses.Add(address);
            await _cargueroDbContext.SaveChangesAsync();
            return address;
        }

        public List<Address> GetAddressesByUsername(string username)
        {
            return _cargueroDbContext.Addresses.Where(x => x.User.Username == username).Include(a => a.User).ToList();
        }

        public int Delete(int id)
        {
            var address = GetById(id);
            if (address == null)
                return 0;
            _cargueroDbContext.Remove(address);
            return _cargueroDbContext.SaveChanges();
        }
    }
}
