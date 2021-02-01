using Carguero.Domain.Data;
using Carguero.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carguero.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private CargueroDbContext _cargueroDbContext;

        public UserRepository(CargueroDbContext cargueroDbContext)
        {
            _cargueroDbContext = cargueroDbContext;
        }

        public IEnumerable<User> GetAll()
        {
            return _cargueroDbContext.Users.ToList();
        }

        public async Task CreateUsername(User user)
        {
            _cargueroDbContext.Users.Add(user);
            await _cargueroDbContext.SaveChangesAsync();
        }
    }
}
