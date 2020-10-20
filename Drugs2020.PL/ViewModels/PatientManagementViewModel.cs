using Drugs2020.BLL.BE;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class PatientManagementViewModel
    {
        private PatientManagementModel patientManagementM;
        public ObservableCollection<Patient> Patients
        {
            get { return patientManagementM.Patients; }
            set { patientManagementM.Patients = value; }
        }

    }
}
