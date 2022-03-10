using CovidCertificate.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidCertificate.ViewModels.Certificate
{
    public class EditViewModel
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        public string ValidMonths { get; set; }
        public bool IsValid { get; set; }
        public User User { get; set; }
    }
}
