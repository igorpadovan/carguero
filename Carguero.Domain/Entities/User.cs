using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Carguero.Entities
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

        public void RegisterAddress(Address address)
        {
            _addresses.Add(address);
        }


    }
}