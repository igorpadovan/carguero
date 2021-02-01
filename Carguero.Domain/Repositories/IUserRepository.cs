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
        IEnumerable<User> GetAll();
    }
}
