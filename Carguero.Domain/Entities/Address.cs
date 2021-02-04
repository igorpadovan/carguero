using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Carguero.Entities
{
    public class Address
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; private set; }

        [Required(ErrorMessage = "ZipCode is required.")]
        [RegularExpression(@"(^\d{5}-\d{3}$)", ErrorMessage = "ZipCode pattern 00000-000")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "ZipCode must be 9 characters")]
        public string ZipCode { get; private set; }

        [Required(ErrorMessage = "Number is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Number must be greater than zero")]
        public int Number { get; private set; }

        [Required(ErrorMessage = "City is required.")]
        [MinLength(3, ErrorMessage = "This field must be between 3 and 60 characters.")]
        [MaxLength(60, ErrorMessage = "This field must be between 3 and 60 characters.")]
        public string City { get; private set; }

        [Required(ErrorMessage = "District is required.")]
        [MinLength(3, ErrorMessage = "This field must be between 3 and 60 characters.")]
        [MaxLength(60, ErrorMessage = "This field must be between 3 and 60 characters.")]
        public string District { get; private set; }

        [MaxLength(100, ErrorMessage = "This field must be between 3 and 100 characters.")]
        public string Complement { get; private set; }

        [Required(ErrorMessage = "State is required.")]
        [MinLength(3, ErrorMessage = "This field must be between 3 and 60 characters.")]
        [MaxLength(60, ErrorMessage = "This field must be between 3 and 60 characters.")]
        public string State { get; private set; }

        [Required(ErrorMessage = "UserId is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "UserId must be greater than zero")]
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
        
        public void SetId(int id)
        {
            Id = id;
        }

        public void UpdateAddress(int id, int number, string complement)
        {
            Id = id;
            Number = number;
            Complement = complement;
        }

        public void SetUser(User user)
        {
            User = user;
        }

        public void SetComplement(string complement)
        {
            Complement = complement;
        }
        public void SetNumber(int number)
        {
            Number = number; ;
        }
        public void Destroy(int id, string username)
        {

        }
    }
}
