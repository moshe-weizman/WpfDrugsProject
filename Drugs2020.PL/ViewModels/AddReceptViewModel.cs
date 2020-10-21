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
        private MainWidowViewModel containingVm;
        private PhysicianShellModel patientModel;
        private DrugModel drugModel;
        public AddReceptViewModel(MainWidowViewModel containingVm, PhysicianShellModel patientModel)
        {
            this.containingVm = containingVm;
            this.patientModel = patientModel;
            AddToDbCommand = new AddToDbCommand(this);
            BackCommand = new BackCommand(this);
            drugModel = new DrugModel();
            DrugCollection = new ObservableCollection<Drug>(drugModel.DrugList);
        }

        public Recept Recept { get { return patientModel.Recept; } set { patientModel.Recept = value; } }
        public ObservableCollection<Drug> DrugCollection { get; set; }
        public AddToDbCommand AddToDbCommand { get; set; }
        public BackCommand BackCommand { get; set; }
        public Drug SelectedDrug { get { return patientModel.Recept.Drug; }
            set 
            {
                patientModel.Recept.Drug = value;
                if(PropertyChanged!=null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedDrug"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddItemToDb()
        {
            patientModel.AddRecept();
        }

        public void GoBack()
        {
            containingVm.ReplaceUC(Screen.ADD_MEDICAL_RECORD);
        }

        public bool ItemAlreadyExists()
        {
           return patientModel.ReceptAlreadyExists();
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
