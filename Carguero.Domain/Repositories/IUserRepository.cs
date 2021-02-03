using Carguero.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carguero.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> SaveAsync(User user);
        User GetByUsername(string username);
        User GetById(int id);

        Task<List<User>> GetUsers();
    }
}
