using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class PatientManagementViewModel : IAdd, IEdit, IDelete, IGoBackScreenVM, IViewModel
    {
        private PatientManagementModel patientManagementM;
        private AdminShellViewModel shellViewModel;
        public AddingItemCommand AddCommand { get; set; }
        public EditingItemCommand EditCommand { get; set; }
        public DeleteItemCommand DeleteCommand { get; set; }
        public BackCommand BackCommand { get; set; }
        public ObservableCollection<Patient> Patients
        {
            get { return patientManagementM.Patients; }
            set { patientManagementM.Patients = value; }
        }

        public PatientManagementViewModel(AdminShellViewModel shellViewModel)
        {
            patientManagementM = new PatientManagementModel();
            this.shellViewModel = shellViewModel;
            AddCommand = new AddingItemCommand(this);
            EditCommand = new EditingItemCommand(this);
            DeleteCommand = new DeleteItemCommand(this);
            BackCommand = new BackCommand(this);
        }

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void OpenAddingScreen()
        {
            shellViewModel.ReplaceScreen(Screen.ADD_PATIENT_SCREEN);
        }

        public void OpenEditingScreen()
        {
            throw new NotImplementedException();
        }

        public void RemoveItemFromDb()
        {
            throw new NotImplementedException();
        }

        public bool IsUserSureToDelete()
        {
            throw new NotImplementedException();
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }
    }
}
