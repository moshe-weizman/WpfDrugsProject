using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class MedicalFileViewModel: IViewModel, IAddToDb , IGoBackScreenVM , INotifyPropertyChanged
    {
        private PhysicianShellViewModel containingShellVm;
        private MedicalFileModel medicalFileM;
        public event PropertyChangedEventHandler PropertyChanged;

        public BackCommand BackCommand { get; set; }
        public AddToDbCommand AddToDbCommand { get; set; }
        public MedicalFile MedicalFile
        {
            get { return medicalFileM.MedicalFile; }
            set {
                medicalFileM.MedicalFile = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MedicalFile"));
                }
            }
        }
        public MedicalFileViewModel(PhysicianShellViewModel containingShellVm, Patient patient)
        {
            this.containingShellVm = containingShellVm;
            medicalFileM = new MedicalFileModel(patient);
            AddToDbCommand = new AddToDbCommand(this);
            BackCommand = new BackCommand(this);
        }

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public void AddItemToDb()
        {
//            medicalFileM.AddMedicalFileToDb();
        }

        public bool ItemAlreadyExists()
        {
            //            return medicalFileM.MedicalFileAlreadyExists();
            return true;
        }

        public bool UserWantsToReplaceExistingItem()
        {
            ExistingItemDecisionViewModel decision = new ExistingItemDecisionViewModel("medical file");
            return decision.Decision;
        }

        public void UpdateExistingItem()
        {
  //          medicalFileM.UpdateMedicalFile();
        }

        public void GoBack()
        {
            containingShellVm.ReplaceUC(Screen.ADD_MEDICAL_RECORD);
        }
    }
}
