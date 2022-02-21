using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidCertificate.Data.Models
{
    public class User:IdentityUser
    {
        public User()
        {
            this.Certificates = new List<Certificate>();
        }
        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public School School { get; set; }
    }
}
