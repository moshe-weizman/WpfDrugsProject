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

        private MainWindowViewModel containingVm;
        public SearchItemCommand PatientSelectionCommand { get; set; }
        public BackCommand BackCommand { get; set; }

        private PatientModel patientM;

        public PatientSearchViewModel(MainWindowViewModel containingVm, PatientModel patientM)
        {
            this.PatientSelectionCommand = new SearchItemCommand(this);
            this.BackCommand = new BackCommand(this);
            this.containingVm = containingVm;
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
            containingVm.ReplaceUC(Screen.LOGIN_SCREEN);
        }

        public void ReplaceScreen()
        {
           
            // if (!PatientFound.GetType().GetProperties().Any(prop => prop == null))//if all properties is null so open medical file screen
             //   containingVm.ReplaceUC(Screen.ADD_MEDICAL_FILE);
         //   else
                containingVm.ReplaceUC(Screen.ADD_MEDICAL_RECORD);

        }
    }
}
