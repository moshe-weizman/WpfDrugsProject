using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace Drugs2020.PL.ViewModels
{
    public class DrugsManagementViewModel : INotifyPropertyChanged, IScreenReplacementVM, IEdit, IDelete, ISearch, IViewModel, IContainingVm
    {
        private DrugsManagementModel drugsManagementM;
        private AdminShellViewModel containingShellVm;
        public event PropertyChangedEventHandler PropertyChanged;
        public EditingItemCommand EditCommand { get; set; }
        public DeleteItemCommand DeleteCommand { get; set; }
        public SearchItemCommand SearchCommand { get; set; }
        public ScreenReplacementCommand ScreenReplacementCommand { get; set; }

        public ObservableCollection<Drug> Items { get; set; }
        private Drug selectedItem;
        public Drug SelectedItem
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

        public DrugsManagementViewModel(AdminShellViewModel shellViewModel)
        {
            drugsManagementM = new DrugsManagementModel();
            Items = new ObservableCollection<Drug>(drugsManagementM.Drugs);
            Items.CollectionChanged += DrugsChanged;
            this.containingShellVm = shellViewModel;
            EditCommand = new EditingItemCommand(this);
            DeleteCommand = new DeleteItemCommand(this);
            SearchCommand = new SearchItemCommand(this);
            ScreenReplacementCommand = new ScreenReplacementCommand(this);
        }

        private void DrugsChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                drugsManagementM.SyncWithDb();
            }
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void OpenEditingScreen(object selectedDrug)
        {
            containingShellVm.CurrentVM = new UpdateDrugViewModel(containingShellVm, selectedDrug as Drug);
        }

        public void RemoveItemFromDb(object selectedDrug)
        {
            Drug drug = selectedDrug as Drug;
            drugsManagementM.RemoveFromDb(drug);
            Items.Remove(drug);
        }

        public bool IsUserSureToDelete()
        {
            return new DeleteDecisionViewmodel("drug").Decision;
        }

        public void GetItem(string id)
        {
            SelectedItem = Items.SingleOrDefault(i => i.IdCode == id);
        }

        public void ReplaceScreen(Screen desiredScreen)
        {
            containingShellVm.ReplaceScreen(desiredScreen);
        }
    }
}