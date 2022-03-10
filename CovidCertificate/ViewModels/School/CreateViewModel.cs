using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidCertificate.ViewModels.School
{
    public class CreateViewModel
    {
        [Required]
        [Display(Name ="Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name ="CodeByAdmin")]
        public string CodeByAdmin { get; set; }
        [Required]
        [Display(Name ="Address")]
        public string Address { get; set; }
    }
}
