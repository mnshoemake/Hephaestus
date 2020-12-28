using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Hephaestus.Models
{
    public class User
    {
        public User(string userName, string emailAddress)
        {
            this.Id = GetNextUserId();
            this.UserName = userName;
            this.EmailAddress = emailAddress;
        }

        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public List<Hero> UserHeroes { get; set; }

        private int GetNextUserId()
        {
            int lastUserId = 0;

            //do sql stuff to get last used numgen

            return lastUserId + 1;
        }
    }
}

