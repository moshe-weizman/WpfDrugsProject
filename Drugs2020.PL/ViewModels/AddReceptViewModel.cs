using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class AddReceptViewModel: IViewModel, IAddToDb , IGoBackScreenVM, INotifyPropertyChanged
    {
        private PhysicianShellViewModel containingVm;
       // private PhysicianShellModel patientModel;
        private DrugModel drugModel;
        private AddReceptModel addReceptModel;
        public AddReceptViewModel(PhysicianShellViewModel containingVm, string patientId)
        {
            this.containingVm = containingVm;
            AddToDbCommand = new AddToDbCommand(this);
            BackCommand = new BackCommand(this);
            drugModel = new DrugModel();
            DrugCollection = new ObservableCollection<Drug>(drugModel.DrugList);
            addReceptModel = new AddReceptModel(patientId);
        }

        public Recept Recept { get { return addReceptModel.Recept; } set { addReceptModel.Recept = value; } }
        public ObservableCollection<Drug> DrugCollection { get; set; }
        public AddToDbCommand AddToDbCommand { get; set; }
        public BackCommand BackCommand { get; set; }
        public Drug SelectedDrug { get { return addReceptModel.Recept.Drug; }
            set 
            {
                addReceptModel.Recept.Drug = value;
                if(PropertyChanged!=null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedDrug"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddItemToDb()
        {
            addReceptModel.AddRecept();
        }

        public void GoBack()
        {
            containingVm.ReplaceUC(Screen.ADD_MEDICAL_RECORD);
        }

        public bool ItemAlreadyExists()
        {
           return addReceptModel.ReceptAlreadyExists();
        }

        public void UpdateExistingItem()
        {
            throw new NotImplementedException();
        }

        public bool UserWantsToReplaceExistingItem()
        {
            throw new NotImplementedException();
        }
    }
}
