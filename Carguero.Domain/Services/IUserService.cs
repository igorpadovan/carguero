using Carguero.Entities;
using System.Threading.Tasks;

namespace Carguero.Domain.Services
{
    public interface IUserService
    {
        bool CreateUser(User user);
    }
}
