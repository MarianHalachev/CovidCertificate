using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CovidCertificate.Data;
using CovidCertificate.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CovidCertificate.ViewModels.Certificate;
using CovidCertificate.Services.Interfaces;

namespace CovidCertificate.Controllers
{
    public class CertificatesController : Controller
    {
        private readonly ICovidService covidService;
        private readonly UserManager<User> userManager;

        public CertificatesController(ICovidService covidService, UserManager<User> userManager)
        {
            this.covidService = covidService;
            this.userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CreateViewModel model)
        {
            this.covidService.CreateCertificate(model.IssueDate, model.ValidMonths, model.IsValid);
            return this.RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult Details(int id)
        {
            var certificate = this.covidService.GetCertificateById(id);
            var model = new DetailsViewModel()
            {
                Id = certificate.Id,
                IssueDate = certificate.IssueDate,
                ValidMonths = certificate.ValidMonths,
                IsValid = certificate.IsValid,
                User = certificate.User
            };

            return this.View(model);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var certificate = this.covidService.GetCertificateById(id);
            var model = new DetailsViewModel()
            {
                Id = certificate.Id,
                IssueDate = certificate.IssueDate,
                ValidMonths = certificate.ValidMonths,
                IsValid = certificate.IsValid,
                User = certificate.User
            };
            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(DetailsViewModel model)
        {
            this.covidService.EditCertificate(model.Id, model.IssueDate, model.ValidMonths, model.IsValid);
            return this.RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var certificate = this.covidService.GetCertificateById(id);
            var model = new DetailsViewModel()
            {
                Id = certificate.Id,
                IssueDate = certificate.IssueDate,
                ValidMonths = certificate.ValidMonths,
                IsValid = certificate.IsValid,
                User = certificate.User
            };
            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(DetailsViewModel model)
        {
            this.covidService.DeleteCertificate(model.Id);
            return this.RedirectToAction("Index", "Home");
        }
        
    }
}