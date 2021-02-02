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
        public async Task<bool> CreateUser(User user)
        {
            var registeredUser = _userRepository.GetByUsername(user.GetUsername());
            if (registeredUser != null)
                return false;

            user = await _userRepository.SaveAsync(user);
            return (user.Id > 0);
        }
    }
}
