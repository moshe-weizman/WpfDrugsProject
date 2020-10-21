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
    class PatientSearchViewModel : IViewModel, ISearch , IGoBackScreenVM 
    {

        private MainWidowViewModel containingShellVm;
        public SearchItemCommand PatientSelectionCommand { get; set; }
        public BackCommand BackCommand { get; set; }

        private PhysicianShellModel patientM;

        public PatientSearchViewModel(MainWidowViewModel containingVm, PhysicianShellModel patientM)
        {
            this.PatientSelectionCommand = new SearchItemCommand(this);
            this.BackCommand = new BackCommand(this);
            this.containingShellVm = containingVm;
            this.patientM = patientM;
        }
        
        public Patient PatientFound
        {
            get { return patientM.CurrentPatient; }
            set { patientM.CurrentPatient = value; }
        }    

        public void GetItem(string id)
        {
             patientM.GetPatient(id);
            if (PatientFound != null)
            {
                ReplaceScreen();
            }
        }

        public void GoBack()
        {
            containingShellVm.ReplaceUC(Screen.LOGIN_SCREEN);
        }

        public void ReplaceScreen()
        {
           
            // if (!PatientFound.GetType().GetProperties().Any(prop => prop == null))//if all properties is null so open medical file screen
             //   containingVm.ReplaceUC(Screen.ADD_MEDICAL_FILE);
         //   else
                containingShellVm.ReplaceUC(Screen.ADD_MEDICAL_RECORD);

        }
    }
}
