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
    class PatientSearchViewModel : IViewModel, IPatientSearchViewModel
    {

        public PatientSelectionCommand PatientSelectionCommand { get; set; }
        private PatientSearchModel patientSearchM;
        public string PatientId
        {
            get { return patientSearchM.PatientId; }
            set { patientSearchM.PatientId = value; }
        }
        private Patient patientFoundM;
        public Patient PatientFound
        {
            get { return patientSearchM.PatientFound; }
            set { patientSearchM.PatientFound = value; }
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
