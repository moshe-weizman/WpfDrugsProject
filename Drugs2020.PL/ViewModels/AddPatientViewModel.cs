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

        private AdminShellViewModel containingVm;
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

        public AddPatientViewModel(AdminShellViewModel containingVm)
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

        public async void AddItemToDb()
        {
            containingVm.startProcessing("Adding to database");
            await Task.Run(() =>
            {
                addPatientM.AddPatientToDb();
                containingVm.finishProcessing("Success!");
                GoBack();
            });

        }

        public bool ItemAlreadyExists()
        {
            return addPatientM.DoesPatientExist();
        }

        public async void UpdateExistingItem()
        {
            containingVm.startProcessing("Updating on database");
            await Task.Run(() =>
            {
                addPatientM.UpdatePatient();
                containingVm.finishProcessing("Success!");
                GoBack();
            });
        }
        
        public void UserWantsToReplaceExistingItem()
        {
            containingVm.LetUserDecide("A patient with this ID already exists in the system. \nDo you want to override it?", new Action(UpdateExistingItem));
        }

        public void GoBack()
        {
            containingVm.ReplaceScreen(Screen.PATIENTS_MANAGEMENT);
        }
    }
}
