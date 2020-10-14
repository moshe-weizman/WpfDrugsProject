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
        }
        public string PatientID
        {
            get { return patientSearchM.PatientID; }
            set { patientSearchM.PatientID = value; }
        }
        private Patient patientFoundM;//בשביל מה זה נצרך?
        public Patient PatientFound//בשביל מה זה נצרך?
        {
            get { return patientSearchM.PatientFound; }
            set { patientSearchM.PatientFound = value; }
        }

       

        public Patient GetPatient()
        {
            return patientSearchM.GetPatient();
        }

        public void GoBack()
        {
            containingVm.ReplaceScreen(Screen.LOGIN_SCREEN);
        }
    }
}
