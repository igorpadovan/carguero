using Carguero.Domain.Validations;
using Carguero.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carguero.Tests.Validators
{
    [TestClass]
    public class UserValidatorTest
    {
        private List<User> _users = new List<User>();
        [TestMethod]
        public void ShouldValidateDuplicateUsername()
        {
            _users.Add(new User("igorpadovan"));
            _users.Add(new User("joaodasilva"));

            var validator = new UserValidator(_users);
            bool isUsernameUnique = validator.IsUsernameUnique("igorpadovan");
            Assert.IsFalse(isUsernameUnique);

            _users.Clear();
            _users.Add(new User("igorpadovan"));
            _users.Add(new User("joaodasilva"));

            validator = new UserValidator(_users);
            isUsernameUnique = validator.IsUsernameUnique("mariadasilva");
            Assert.IsTrue(isUsernameUnique);
        }
    }
}
