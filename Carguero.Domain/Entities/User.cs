using Carguero.Domain.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Carguero.Models
{
    public class User{
        private List<Address> _addresses { get; set; }
        [Key]
        public  int Id { get; set;}

        [Required(ErrorMessage = "Username is required.")]
        [MinLength(3, ErrorMessage = "This field must be between 3 and 30 characters.")]
        [MaxLength(30, ErrorMessage = "This field must be between 3 and 30 characters.")]
        public string Username { get; set;}

        public IReadOnlyCollection<Address> Addresses
        {
            get { return _addresses.ToArray(); }
        }

        public User(string username)
        {
            Username = username;
            _addresses = new List<Address>();
        }

        public List<string> Validate()
        {
            List<string> validationError = new List<string>();

            var validator = new UserValidator(new List<User>());
            var result = validator.Validate(this);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    validationError.Add($" { error.PropertyName } : { error.ErrorMessage }");
                }
            }

            return validationError;
        }

        public void RegisterAddress(Address address)
        {
            _addresses.Add(address);
        }

    }
}