using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class PatientDataModel// לכאורה לא נצרך!!
    {
        private IBL bl;
        public Patient CurrentPatient { get; set; }
        public PatientDataModel()
        {
            bl = new BLImplementation();
        }
    }
}
