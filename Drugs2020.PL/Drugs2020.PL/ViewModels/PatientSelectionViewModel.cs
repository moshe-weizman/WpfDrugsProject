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
    class PatientSelectionViewModel
    {

        private PatientSelectionModel patientSelectionM;

        private PatientSelectionCommand patientSelectionCommand;

        public PatientSelectionViewModel()
        {
            this.patientSelectionM = new PatientSelectionModel();

            patientSelectionCommand = new PatientSelectionCommand(this);
        }

        public string PatientID { 
            get { return patientSelectionM.PatientID; }
            set { patientSelectionM.PatientID = value; } 
        }

       public Patient GetPatient()
        {
           return patientSelectionM.GetPatient();
        }

    }
}
