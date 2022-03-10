using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CovidCertificate.Data;
using CovidCertificate.Data.Models;
using CovidCertificate.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using CovidCertificate.ViewModels.School;

namespace CovidCertificate.Controllers
{
    public class SchoolsController : Controller
    {
        private readonly ICovidService covidService;
        private readonly UserManager<User> userManager;

        public SchoolsController(ICovidService covidService, UserManager<User> userManager)
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
            this.covidService.CreateSchool(model.Name,model.CodeByAdmin,model.Address);
            return this.RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult Details(int id)
        {
            var school = this.covidService.GetSchoolById(id);
            var model = new DetailsViewModel()
            {
             Id=school.Id,
             CodeByAdmin = school.CodeByAdmin,
             Name = school.Name,
             Address =school.Address
            };

            return this.View(model);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var school = this.covidService.GetSchoolById(id);
            var model = new DetailsViewModel()
            {
                Id = school.Id,
                CodeByAdmin = school.CodeByAdmin,
                Name = school.Name,
                Address = school.Address
            };
            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(DetailsViewModel model)
        {
            this.covidService.EditSchool(model.Id,model.Name,model.CodeByAdmin,model.Address);
            return this.RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var school = this.covidService.GetSchoolById(id);
            var model = new DetailsViewModel()
            {
                Id = school.Id,
                CodeByAdmin = school.CodeByAdmin,
                Name = school.Name,
                Address = school.Address
            };
            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(DetailsViewModel model)
        {
            this.covidService.DeleteSchool(model.Id);
            return this.RedirectToAction("Index", "Home");
        }
    }
}
