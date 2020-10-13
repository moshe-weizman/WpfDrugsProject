using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class PatientSearchViewModel
    {
        private PatientSearchModel patientSearchM;
        public PatientSelectionCommand PatientSelectionCommand { get; set; }

        public string PatientID { 
            get { return patientSearchM.PatientID; }
            set { patientSearchM.PatientID = value; } 
        }
        public PatientSearchViewModel()
        {
            this.patientSearchM = new PatientSearchModel();

            PatientSelectionCommand = new PatientSelectionCommand(this);
        }
        public Patient GetPatient()
        {
           return patientSearchM.GetPatient();
        }
    }
}
