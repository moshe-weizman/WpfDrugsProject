using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    public class CurrentPatient
    {
        public string PatientID { get; set; }

        public Patient Patient { get; set; }

        public CurrentPatient()
        {
            Patient = new Patient();
        }
    }
}
