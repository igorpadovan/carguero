using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Carguero.Entities
{
    public class User{
        private List<Address> _addresses { get; set; }
        [Key]
        public  int Id { get; set;}

        private string username;

        public string GetUsername()
        {
            return username;
        }

        public void SetUsername(string name)
        {
            username = name;
        }

        public IReadOnlyCollection<Address> Addresses
        {
            get { return _addresses.ToArray(); }
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