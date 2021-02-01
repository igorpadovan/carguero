using Carguero.Domain.Data;
using Carguero.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carguero.Domain.Services
{
    public class UserService : IUserService
    {
        private CargueroDbContext _cargueroDbContext;
        public UserService(CargueroDbContext cargueroDbContext)
        {
            _cargueroDbContext = cargueroDbContext;
        }
        public async Task Save(User user)
        {
            _cargueroDbContext.Users.Add(user);
            await _cargueroDbContext.SaveChangesAsync();
        }
    }
}
