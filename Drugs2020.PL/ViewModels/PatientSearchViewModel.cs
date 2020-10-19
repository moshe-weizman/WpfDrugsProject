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
    class PatientSearchViewModel : IViewModel, IPatientSearchViewModel , IGoBackScreenVM 
    {

        private MainWindowViewModel containingVm;
        public PatientSelectionCommand PatientSelectionCommand { get; set; }
        public BackCommand BackCommand { get; set; }

        private PatientSearchModel patientSearchM;

        public PatientSearchViewModel(MainWindowViewModel containingVm)
        {
            this.patientSearchM = new PatientSearchModel();

            PatientSelectionCommand = new PatientSelectionCommand(this);

            BackCommand = new BackCommand(this);

            this.containingVm = containingVm;
            containingVm.CurrentPatient = new Patient();
        }
        public string PatientID
        {
            get { return patientSearchM.PatientId; }
            set { patientSearchM.PatientId = value; }
        }
        private Patient patientFoundM;//בשביל מה זה נצרך?
        public Patient PatientFound//בשביל מה זה נצרך?
        {
            get { return patientSearchM.PatientFound; }
            set { patientSearchM.PatientFound = value; }
        }

       

        public void GetPatient()
        {
            PatientFound= patientSearchM.GetPatient();
            if (PatientFound != null) {
                containingVm.CurrentPatient = PatientFound;
                ReplaceScreen();
            }
        }

        public void GoBack()
        {
            containingVm.ReplaceLeftUC(Screen.LOGIN_SCREEN);
        }

        public void ReplaceScreen()
        {
            containingVm.ReplaceRightUC(Screen.PATIENT_DATA);
            if(!PatientFound.GetType().GetProperties().Any(prop => prop == null))//if all properties is null so open medical file screen
               containingVm.ReplaceLeftUC(Screen.ADD_MEDICAL_FILE);

        }
    }
}
