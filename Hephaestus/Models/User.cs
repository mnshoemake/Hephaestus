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
        public User()
        {
            this.UserName = "DEFAULT";
            this.EmailAddress = "DEFAULT";
            this.Password = "DEFAULT";
        }

        public User(string userName, string emailAddress, string password)
        {
            this.UserName = userName;
            this.EmailAddress = emailAddress;
            this.Password = password;
        }

        public User(string userName, string firstName, string lastName, string emailAddress, string password)
        {
            this.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = emailAddress;
            this.Password = password;
        }

        public User(int id, string userName, string firstName, string lastName, string emailAddress)
        {
            this.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = emailAddress;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public List<Hero> Heroes { get; set; }

    }
}

