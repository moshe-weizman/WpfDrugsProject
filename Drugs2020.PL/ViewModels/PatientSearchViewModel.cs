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

        private PatientModel patientM;

        public PatientSearchViewModel(MainWindowViewModel containingVm, PatientModel patientM)
        {
            this.PatientSelectionCommand = new PatientSelectionCommand(this);
            this.BackCommand = new BackCommand(this);
            this.containingVm = containingVm;
            this.patientM = patientM;
        }
        public string PatientId
        {
            get { return patientM.PatientId; }
            set { patientM.PatientId = value; }
        }
        public Patient PatientFound
        {
            get { return patientM.CurrentPatient; }
            set { patientM.CurrentPatient = value; }
        }

       

        public void GetPatient()
        {
            PatientFound= patientM.GetPatient();
            if (PatientFound != null) {
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
