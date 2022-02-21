using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidCertificate.Data.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ValidMonths { get; set; } 
        public bool IsValid { get; set; }
        public User User { get; set; }
    }
}
