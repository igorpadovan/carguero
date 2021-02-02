using Carguero.Domain.Data;
using Carguero.Domain.Repositories;
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
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool CreateUser(User user)
        {
            var registeredUser = _userRepository.GetByUsername(user.GetUsername());
            if (registeredUser != null)
                return false;

            user = _userRepository.Save(user);
            return (user.Id > 0);
        }
    }
}
