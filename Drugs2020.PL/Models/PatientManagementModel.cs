using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class PatientManagementModel
    {
        public List<Patient> Patients { get; set; }//להחליף את זה לרשימה רגילה!!!
        private IBL bl;
        public PatientManagementModel()
        {
            bl = new BLImplementation();
            Patients = bl.GetAllPatients();
        }

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    
    }
}
