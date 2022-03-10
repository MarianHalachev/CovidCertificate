using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidCertificate.ViewModels.Certificate
{
    public class CreateViewModel
    {
        [Required]
        [Display(Name ="ProductionDate")]
        public DateTime IssueDate { get; set; }
        [Required]
        [Display(Name ="ValidMonths")]
        public string ValidMonths { get; set; }
        [Required]
        [Display(Name ="IsValid")]
        public bool IsValid { get; set; }
    }
}
