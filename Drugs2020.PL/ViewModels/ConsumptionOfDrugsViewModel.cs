using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using System.ComponentModel;

namespace Drugs2020.PL.ViewModels
{
    class ConsumptionOfDrugsViewModel: IViewModel, IGoBackScreenVM, IChangeListDisplayVM, IDelete, INotifyPropertyChanged
    {
        private MedicalFileModel medicalFileModel;

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Recept> DrugsPreviouslyTaken { get; set; }
        public ObservableCollection<Recept> DrugsTake { get; set; }
        public BackCommand BackCommand { get; set; }
        public DeleteItemCommand RemoveFromDb { get; set; }
        public ChangeListDisplayCommand ChangeListDisplayCommand { get; set; }
        public ObservableCollection<Recept> ListDisplay { get; set; }
        private PhysicianShellViewModel containingVm;
        public ConsumptionOfDrugsViewModel(PhysicianShellViewModel containingVm, string patientId)
        {
            medicalFileModel = new MedicalFileModel(patientId);
            this.containingVm = containingVm;
            DrugsPreviouslyTaken = new ObservableCollection<Recept>(medicalFileModel.AllRecepts.Where(x=> x.TreatmentEndDate < DateTime.Now));
            DrugsTake = new ObservableCollection<Recept>(medicalFileModel.AllRecepts.Where(x => x.TreatmentEndDate >= DateTime.Now));
            ListDisplay = new ObservableCollection<Recept>(DrugsTake);
            BackCommand = new BackCommand(this);
            ChangeListDisplayCommand = new ChangeListDisplayCommand(this);
            RemoveFromDb = new DeleteItemCommand(this);
        }

        public void ChangeListDisplay(ListsTypes list)
        {
            switch (list)
            {
                case ListsTypes.DRUGS_TAKE:
                    ListDisplay.Clear();
                    foreach (var Item in DrugsTake)
                        ListDisplay.Add(Item);
                    break;
                case ListsTypes.DRUGS_PREVIOUSLY_TAKEN:
                    ListDisplay.Clear();
                    foreach (var Item in DrugsPreviouslyTaken)
                        ListDisplay.Add(Item);
                    break;
                default: break;
            }
        }
        
        public void GoBack()
        {
            containingVm.ReplaceScreen(Screen.ADD_MEDICAL_FILE);
        }

        public void RemoveItemFromDb(object selectedPrescription)
        {
            try
            {
                medicalFileModel.RemoveReceiptFromDb(selectedPrescription as Recept);
                DrugsTake.Remove((Recept)selectedPrescription);
                ListDisplay.Remove((Recept)selectedPrescription);

            }
            catch (ArgumentException e) { containingVm.ShowMessage(e.Message); }
            catch (Exception e) { containingVm.ShowMessage(e.Message); }
        }

        public bool IsUserSureToDelete()
        {
            return new DeleteDecisionViewmodel("receipt").Decision;

        }

        public void DeleteSelected(object selectedPrescription)
        {
            Recept recept = selectedPrescription as Recept;
            if (DrugsPreviouslyTaken.Contains(recept))
            {
                containingVm.ShowMessage("An expired prescription cannot be deleted");
            }
            else
            {
                containingVm.LetUserDecide("Are you sure you want to delete this prescription from the system?", new Action(() => RemoveItemFromDb(selectedPrescription)));
            }
        }
    }
}
