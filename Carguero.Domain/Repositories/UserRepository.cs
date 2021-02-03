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

        public async Task<User> SaveAsync(User user)
        {
            _cargueroDbContext.Users.Add(user);
            await _cargueroDbContext.SaveChangesAsync();
            return user;
        }

        public User GetByUsername(string username)
        {
            return _cargueroDbContext.Users.Where(u => u.Username == username).FirstOrDefault();
        }

        public User GetById(int id)
        {
            return _cargueroDbContext.Users.Where(u => u.Id == id).FirstOrDefault();
        }
    }
}
