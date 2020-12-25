using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hephaestus.Models
{
    public class User
    {
        public User(int userID, string userName, string emailAddress)
        {
            this.UserId = userID;
            this.UserName = userName;
            this.EmailAddress = emailAddress;
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public List<Hero> UserHeroes { get; set; }
    }
}

