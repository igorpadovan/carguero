﻿using Carguero.Entities;
using System.Threading.Tasks;

namespace Carguero.Domain.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUser(User user);
    }
}
