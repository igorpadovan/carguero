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

        public User Save(User user)
        {
            _cargueroDbContext.Users.Add(user);
            _cargueroDbContext.SaveChangesAsync();
            return user;
        }

        public User GetByUsername(string username)
        {
            return (User)_cargueroDbContext.Users.Where(u => u.GetUsername() == username);
        }
    }
}
