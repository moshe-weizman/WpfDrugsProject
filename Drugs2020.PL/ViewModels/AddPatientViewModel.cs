using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class AddPatientViewModel : IAddToDb , IGoBackScreenVM, IViewModel
    {
        private AddPatientModel addPatientM;

        private PatientsManagementViewModel containingVm;
        public AddToDbCommand UpdateDbCommand { get; set; }
        public DateTime TodayDate { get; set; }
        public bool IsNewPatient { get; }
        public BackCommand BackCommand { get; set; }
        public Patient Patient
        {
            get { return addPatientM.Patient; }
            set { addPatientM.Patient = value; }
        }
        public Array SexEnumValues => Enum.GetValues(typeof(Sex));

        public AddPatientViewModel(PatientsManagementViewModel containingVm)
        {
            addPatientM = new AddPatientModel();
            this.containingVm = containingVm;
            UpdateDbCommand = new AddToDbCommand(this);
            TodayDate = DateTime.Today;
            IsNewPatient = true;
            BackCommand = new BackCommand(this);
            Patient = new Patient();           
        }

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public void AddItemToDb()
        {
            addPatientM.AddPatientToDb();
            containingVm.Items.Add(Patient);
            GoBack();
        }

        public bool ItemAlreadyExists()
        {
            return addPatientM.DoesPatientExist();
        }

        public async void UpdateExistingItem()
        {
            containingVm.Items.Remove(containingVm.Items.Single(i => i.ID == Patient.ID));
            containingVm.Items.Add(Patient);
            GoBack();
            await Task.Run(() => addPatientM.UpdatePatient());
            //to anounce for success
        }

        public bool UserWantsToReplaceExistingItem()
        {
            ExistingItemDecisionViewModel existingItemDecision = new ExistingItemDecisionViewModel("Patient");
            return existingItemDecision.Decision;
        }

        public void GoBack()
        {
            containingVm.ReturnToContaining();
        }
    }
}
