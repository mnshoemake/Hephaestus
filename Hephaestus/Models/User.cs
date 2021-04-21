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
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name = "Heroes")]
        public List<Hero> Heroes { get; set; }

    }
}

