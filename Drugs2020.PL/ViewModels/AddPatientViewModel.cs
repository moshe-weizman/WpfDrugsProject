using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;

namespace Drugs2020.PL.ViewModels
{
    class AddPatientViewModel : IAddToDb , IGoBackScreenVM, IViewModel
    {
        private AddPatientModel addPatientM;

        private AdminShellViewModel shellVm;
        public AddToDbCommand AddToDbCommand { get; set; }

        public BackCommand BackCommand { get; set; }
        public Patient Patient
        {
            get { return addPatientM.Patient; }
            set { addPatientM.Patient = value; }
        }
        public Array SexEnumValues => Enum.GetValues(typeof(Sex));

        public AddPatientViewModel(AdminShellViewModel shellVm)
        {
            addPatientM = new AddPatientModel();
            this.shellVm = shellVm;
            AddToDbCommand = new AddToDbCommand(this);
            BackCommand = new BackCommand(this);
            Patient = new Patient();           
        }

        public void AddItemToDb()
        {
            addPatientM.AddPatientToDb();
            GoBack();
        }

        public bool ItemAlreadyExists()
        {
            return addPatientM.DoesPatientExist();
        }

        public void UpdateExistingItem()
        {
            addPatientM.UpdatePatient();
            GoBack();
        }

        public bool UserWantsToReplaceExistingItem()
        {
            ExistingItemDecisionViewModel existingItemDecision = new ExistingItemDecisionViewModel("Patient");
            return existingItemDecision.Decision;
        }

        public void GoBack()
        {
            shellVm.ReplaceScreen(Screen.PATIENTS_MANAGEMENT);
        }
    }
}
