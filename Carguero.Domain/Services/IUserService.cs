using Carguero.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carguero.Domain.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUser(User user);

        Task<List<User>> ListRegisteredUsers();
        User GetByUsername(string username);
    }
}
