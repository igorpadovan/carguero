using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Carguero.Entities
{
    public class User{        
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
        }


    }
}