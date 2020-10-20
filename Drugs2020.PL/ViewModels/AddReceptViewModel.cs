using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class AddReceptViewModel: IViewModel, IAddToDb , IGoBackScreenVM
    {
        private MainWindowViewModel containingVm;
        private PatientModel patientModel;

        public AddReceptViewModel(MainWindowViewModel containingVm, PatientModel patientModel)
        {
            this.containingVm = containingVm;
            this.patientModel = patientModel;
            AddToDbCommand = new AddToDbCommand(this);
            BackCommand = new BackCommand(this);
        }

        public Recept Recept { get { return patientModel.Recept; } set { patientModel.Recept = value; } }

        public AddToDbCommand AddToDbCommand { get; set; }
        public BackCommand BackCommand { get; set; }
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
