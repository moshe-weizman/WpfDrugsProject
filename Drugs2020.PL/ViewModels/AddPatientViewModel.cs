using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Drugs2020.PL.ViewModels
{
    class AddPatientViewModel : IAddToDb , IGoBackScreenVM, IViewModel
    {
        private AddPatientModel addPatientM;

        private MainWindowViewModel containingVm;
        public AddToDbCommand AddToDbCommand { get; set; }

        public BackCommand BackCommand { get; set; }
        public Patient Patient
        {
            get { return addPatientM.Patient; }
            set { addPatientM.Patient = value; }
        }
        public Array SexEnumValues => Enum.GetValues(typeof(Sex));

        public AddPatientViewModel(MainWindowViewModel containingVm)
        {
            addPatientM = new AddPatientModel();
            this.containingVm = containingVm;
            AddToDbCommand = new AddToDbCommand(this);
            BackCommand = new BackCommand(this);
            Patient = new Patient();           
        }

        public void AddItemToDb()
        {
            addPatientM.AddPatientToDb();
        }

        public bool ItemAlreadyExists()
        {
            return addPatientM.DoesPatientExist();
        }

        public void UpdateExistingItem()
        {
            addPatientM.UpdatePatient();
        }

        public bool UserWantsToReplaceExistingItem()
        {
            ExistingItemDecisionViewModel existingItemDecision = new ExistingItemDecisionViewModel("Patient");
            return existingItemDecision.Decision;
        }

        public void GoBack()
        {
            containingVm.ReplaceUC(Screen.ACTIONS_MENU);
        }
    }
}
