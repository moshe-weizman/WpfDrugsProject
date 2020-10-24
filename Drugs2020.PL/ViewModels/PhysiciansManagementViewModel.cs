using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class PhysiciansManagementViewModel : IReplaceScreen, IEdit, IDelete, ISearch, IViewModel, IContainingVm
    {
        private PhysiciansManagementModel physiciansManagementM;
        private AdminShellViewModel containingShellVm;
        public ReplaceScreenCommand AddCommand { get; set; }
        public EditingItemCommand EditCommand { get; set; }
        public DeleteItemCommand DeleteCommand { get; set; }
        public SearchItemCommand SearchCommand { get; set; }
        public ObservableCollection<Physician> Items { get; set; }

        public PhysiciansManagementViewModel(AdminShellViewModel shellViewModel)
        {
            physiciansManagementM = new PhysiciansManagementModel();
            Items = new ObservableCollection<Physician>(physiciansManagementM.Physicians);
            Items.CollectionChanged += PhysiciansChanged;
            this.containingShellVm = shellViewModel;
            AddCommand = new ReplaceScreenCommand(this);
            EditCommand = new EditingItemCommand(this);
            DeleteCommand = new DeleteItemCommand(this);
            SearchCommand = new SearchItemCommand(this);
        }

        private void PhysiciansChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                physiciansManagementM.SyncWithDb();
            }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void ReplaceScreen()
        {
            containingShellVm.PhysiciansTabVm = new AddPhysicianViewModel(this);
        }

        public void OpenEditingScreen(object selectedPhysician)
        {
            containingShellVm.PhysiciansTabVm = new UpdatePhysicianViewModel(this, selectedPhysician as Physician);
        }

        public void RemoveItemFromDb(object selectedPhysician)
        {
            Physician physician = selectedPhysician as Physician;
            physiciansManagementM.RemoveFromDb(physician);
            Items.Remove(physician);
        }

        public bool IsUserSureToDelete()
        {
            return new DeleteDecisionViewmodel("physician").Decision;
        }

        public void GetItem(string id)
        {
        }

        public void ReturnToContaining()
        {
            containingShellVm.PhysiciansTabVm = this;
        }
    }
}
