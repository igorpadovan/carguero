using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Carguero.Models
{
    public class Address
    {
        public int Id { get; private set; }
        public string ZipCode { get; private set; }
        public int Number { get; private set; }
        public string City { get; private set; }
        public string District { get; private set; }
        public string Complement { get; private set; }
        public string State { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }

        public Address(string zipCode, int number, string city, string district, string complement, string state, int userId)
        {
            ZipCode = zipCode;
            Number = number;
            City = city;
            District = district;
            Complement = complement;
            State = state;
            UserId = userId;
        }        

        public void UpdateAddress(int id, int number, string complement)
        {
            Id = id;
            Number = number;
            Complement = complement;
        }

        public void Destroy(int id, string username)
        {

        }
    }
}
