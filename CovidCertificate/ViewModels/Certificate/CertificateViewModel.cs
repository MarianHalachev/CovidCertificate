using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidCertificate.ViewModels.Certificate
{
    public class CertificateViewModel
    {
        public int Count { get; set; }

        public int Rows => this.Count % 5;

        public IEnumerable<DisplayViewModel> Certificates { get; set; }
    }
}
