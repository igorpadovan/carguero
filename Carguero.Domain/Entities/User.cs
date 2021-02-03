using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Carguero.Entities
{
    public class User{
        private List<Address> _addresses { get; set; }
        [Key]
        public  int Id { get; set;}

        public string Username { get; private set; }

        public string GetUsername()
        {
            return Username;
        }

        public void SetUsername(string name)
        {
            Username = name;
        }

        public User(string username)
        {
            SetUsername(username);
            _addresses = new List<Address>();
        }

        public void RegisterAddress(Address address)
        {
            _addresses.Add(address);
        }


    }
}