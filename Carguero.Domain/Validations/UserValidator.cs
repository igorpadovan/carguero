using Carguero.Models;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Carguero.Domain.Validations
{
    public class UserValidator: AbstractValidator<User>
    {
        private readonly List<User> _users;
        public UserValidator(List<User> users)
        {
            _users = users;
            RuleFor(user => user.Username)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(60)
                .WithMessage("This field must be between 3 and 30 characters.");
            RuleFor(user => user.Username).Must(IsUsernameUnique)
                .WithMessage("Username must be unique");
        }

        public bool IsUsernameUnique(string username)
        {
            var user = _users.Find(u => u.Username == username);
            return (user == null);
        }
    }
}
