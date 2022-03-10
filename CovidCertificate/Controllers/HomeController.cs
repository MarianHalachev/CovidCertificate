using CovidCertificate.Data.Models;
using CovidCertificate.Models;
using CovidCertificate.Services.Interfaces;
using CovidCertificate.ViewModels.Certificate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CovidCertificate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICovidService covidService;
        public HomeController(ICovidService covidService)
        {
            this.covidService = covidService;
        }

        public IActionResult Index()
        {
            var certificates = this.covidService.GetAllCertificates();
            var displayCertificates = new CertificateViewModel
            {
                Count = certificates.Count,
                Certificates = this.ExtractDisplayCertificates(certificates)
            };
            return View(displayCertificates);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<DisplayViewModel> ExtractDisplayCertificates(List<Certificate> certificates)
        {
            var list = new List<DisplayViewModel>();
            foreach (var certificate in certificates)
            {
                var model = new DisplayViewModel
                {
                    Id= certificate.Id,
                    IssueDate = certificate.IssueDate,
                    ValidMonths=certificate.ValidMonths,
                    IsValid = certificate.IsValid
       
                };

                list.Add(model);
            }

            return list;View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
