using CovidCertificate.Data;
using CovidCertificate.Data.Models;
using CovidCertificate.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidCertificate.Services
{
    public class CovidService : ICovidService
    {

        private readonly ApplicationDbContext context;
        public CovidService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void CreateCertificate(DateTime issueDate, string validMonths, bool isValid)
        {
            var certificate = new Certificate
            {
                IssueDate = issueDate,
                ValidMonths = validMonths,
                IsValid = isValid

            };

            this.context.Certificate.Add(certificate);
            this.context.SaveChanges();
        }

        public void DeleteCertificate(int certificateId)
        {
            var certificate = this.context.Certificate.FirstOrDefault(p => p.Id == certificateId);
            certificate.IsValid = false;
            this.context.SaveChanges();
        }

        public void EditCertificate(int certificateId, DateTime issueDate, string validMonths, bool isValid)
        {
            var certificate = this.context.Certificate.FirstOrDefault(p => p.Id == certificateId);

            certificate.IssueDate = issueDate;
            certificate.ValidMonths = validMonths;
            certificate.IsValid = isValid;

            this.context.SaveChanges();
        }

        public List<Certificate> GetAllCertificates()
        {
            var certificate = this.context.Certificate.Where(o => o.IsValid == false).
            Include(o => o.User).
            ToList();
            return certificate;
        }

        public Certificate GetCertificateById(int id)
        {
            var certificate = this.context.Certificate.FirstOrDefault(c => c.Id == id);
            return certificate;
        }

        void ICovidService.CreateSchool(string name, string codebyAdmin, string address)
        {
            var school = new School
            {
                Name=name,
                CodeByAdmin=codebyAdmin,
                Address=address

            };

            this.context.School.Add(school);
            this.context.SaveChanges();
        }

        void ICovidService.DeleteSchool(int schoolId)
        {
            var school = this.context.School.FirstOrDefault(p => p.Id == schoolId);
            this.context.SaveChanges();
        }

        void ICovidService.EditSchool(int schoolId, string name, string codebyAdmin, string address)
        {
            var school = this.context.School.FirstOrDefault(p => p.Id == schoolId);

            school.Name = name;
            school.CodeByAdmin = codebyAdmin;
            school.Address = address;

            this.context.SaveChanges();
        }

        School ICovidService.GetSchoolById(int id)
        {
            var school = this.context.School.FirstOrDefault(c => c.Id == id);
            return school;
        }
    }
}
