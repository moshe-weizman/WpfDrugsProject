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
    class AddReceptViewModel: IViewModel, IAddToDb , INotifyPropertyChanged, ICreatePDFVM
    {
        private PhysicianShellViewModel containingVm;
       // private PhysicianShellModel patientModel;
        private ReceptModel addReceptModel;
       
        public string Conflicts
        {
            get { return addReceptModel.Conflicts; }
            set { addReceptModel.Conflicts = value; 
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Conflicts"));
            }
        }

        public AddReceptViewModel(PhysicianShellViewModel containingVm, string patientId, Physician physician)
        {
            addReceptModel = new ReceptModel(patientId, physician);
            this.containingVm = containingVm;
            AddToDbCommand = new AddToDbCommand(this);
            DrugCollection = new ObservableCollection<Drug>(addReceptModel.DrugList);
            OperationCommand = new CreatePDFCommand(this);
        }
        public CreatePDFCommand OperationCommand { get; set; }
        public Recept Recept { get { return addReceptModel.Recept; } set { addReceptModel.Recept = value; } }
        public ObservableCollection<Drug> DrugCollection { get; set; }
        public AddToDbCommand AddToDbCommand { get; set; }
        public Drug SelectedDrug { 
            set 
            {
                addReceptModel.Recept.IdCodeOfDrug = value.IdCode;
                addReceptModel.Recept.DrugGenericName = value.GenericName;
                if (PropertyChanged!=null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedDrug"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddItemToDb()
        {
            addReceptModel.AddRecept();
        }

        public void DoPDF()
        {
            addReceptModel.CreatePDF();
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
