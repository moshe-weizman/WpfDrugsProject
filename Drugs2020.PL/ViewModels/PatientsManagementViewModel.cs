using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace Drugs2020.PL.ViewModels
{
    class PatientsManagementViewModel : INotifyPropertyChanged, IReplaceScreen, IEdit, IDelete, ISearch, IViewModel, IContainingVm
    {
        private PatientManagementModel patientManagementM;
        private AdminShellViewModel containingShellVm;

        public event PropertyChangedEventHandler PropertyChanged;

        public ReplaceScreenCommand AddCommand { get; set; }
        public EditingItemCommand EditCommand { get; set; }
        public DeleteItemCommand DeleteCommand { get; set; }
        public SearchItemCommand SearchCommand { get; set; }
        public ObservableCollection<Patient> Items { get; set; }
        private Patient selectedItem;
        public Patient SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedItem"));
            }
        }
        public PatientsManagementViewModel(AdminShellViewModel shellViewModel)
        {
            patientManagementM = new PatientManagementModel();
            Items = new ObservableCollection<Patient>(patientManagementM.Patients);
            Items.CollectionChanged += PatientsChanged;
            this.containingShellVm = shellViewModel;
            AddCommand = new ReplaceScreenCommand(this);
            EditCommand = new EditingItemCommand(this);
            DeleteCommand = new DeleteItemCommand(this);
            SearchCommand = new SearchItemCommand(this);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void PatientsChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                patientManagementM.SyncWithDb();
            }
        }

        public void OpenEditingScreen(object selectedPatient)
        {
            containingShellVm.PatientsTabVm = new UpdatePatientViewModel(this, selectedPatient as Patient);
        }

        public void RemoveItemFromDb(object selectedPatient)
        {
            Patient patient = selectedPatient as Patient;
            patientManagementM.RemoveFromDb(patient);
            Items.Remove(patient);
        }

        public bool IsUserSureToDelete()
        {
            return new DeleteDecisionViewmodel("patient").Decision;
        }

        public void GetItem(string id)
        {
            SelectedItem = Items.SingleOrDefault(i => i.ID == id);
        }

        public void ReturnToContaining()
        {
            containingShellVm.PatientsTabVm = this;
        }

        public void ReplaceScreen()
        {
            containingShellVm.PatientsTabVm = new AddPatientViewModel(this);
        }
    }
}
