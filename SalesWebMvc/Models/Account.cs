using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public ProfileStatus Profile { get; set; }

        public Account(int id, string name, string email, string user, string password, ProfileStatus profile)
        {
            Id = id;
            Name = name;
            Email = email;
            User = user;
            Password = password;
            Profile = profile;
        }
    }
}
