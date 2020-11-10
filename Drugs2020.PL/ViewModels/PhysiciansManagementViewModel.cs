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

namespace Drugs2020.PL.ViewModels
{
    class PhysiciansManagementViewModel : INotifyPropertyChanged, IEdit, IDelete, ISearch, IViewModel, IContainingVm, IScreenReplacementVM
    {
        private PhysiciansManagementModel physiciansManagementM;
        private AdminShellViewModel containingShellVm;
        public event PropertyChangedEventHandler PropertyChanged;
        public EditingItemCommand EditCommand { get; set; }
        public DeleteItemCommand DeleteCommand { get; set; }
        public SearchItemCommand SearchCommand { get; set; }
        public ScreenReplacementCommand ScreenReplacementCommand { get; set; }
        public ObservableCollection<Physician> Items { get; set; }
        private Physician selectedItem;
        public Physician SelectedItem
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
        public PhysiciansManagementViewModel(AdminShellViewModel shellViewModel)
        {
            physiciansManagementM = new PhysiciansManagementModel();
            Items = new ObservableCollection<Physician>(physiciansManagementM.Physicians);
            Items.CollectionChanged += PhysiciansChanged;
            this.containingShellVm = shellViewModel;
            EditCommand = new EditingItemCommand(this);
            DeleteCommand = new DeleteItemCommand(this);
            SearchCommand = new SearchItemCommand(this);
            ScreenReplacementCommand = new ScreenReplacementCommand(this);
        }

        private void PhysiciansChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                physiciansManagementM.SyncWithDb();
            }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
       

        public void OpenEditingScreen(object selectedPhysician)
        {
            containingShellVm.CurrentVM = new UpdatePhysicianViewModel(containingShellVm, selectedPhysician as Physician);
        }

        public void RemoveItemFromDb(object selectedPhysician)
        {
            Physician physician = selectedPhysician as Physician;
            try
            {
                physiciansManagementM.RemoveFromDb(physician);
            }
            catch (ArgumentException ex) { containingShellVm.ShowMessage(ex.Message); }
            catch (Exception ex) { containingShellVm.ShowMessage(ex.Message); }
            Items.Remove(physician);
        }

        public bool IsUserSureToDelete()
        {
            return new DeleteDecisionViewmodel("physician").Decision;
        }

        public void GetItem(string id)
        {
            SelectedItem = Items.SingleOrDefault(i => i.ID == id);
        }

        public void ReplaceScreen(Screen desiredScreen)
        {
            containingShellVm.ReplaceScreen(Screen.ADD_PHYSICIAN_SCREEN);
        }

        public void DeleteSelected(object selectedPhysician)
        {
            containingShellVm.LetUserDecide("Are you sure you want to delete this physician from the system?", new Action(() => RemoveItemFromDb(selectedPhysician)));
        }
    }
}
