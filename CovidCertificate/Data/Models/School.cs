namespace CovidCertificate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class School
    {
        public School()
        {
            this.Users = new List<User>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string CodeByAdmin { get; set; }
        public string Address { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
