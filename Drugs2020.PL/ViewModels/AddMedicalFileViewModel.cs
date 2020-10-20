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
    class AddMedicalFileViewModel: IViewModel, IAddToDb , IGoBackScreenVM , INotifyPropertyChanged
    {
        private PatientModel patientModel;
        private MainWindowViewModel containingVm;

        public event PropertyChangedEventHandler PropertyChanged;

        public BackCommand BackCommand { get; set; }
        public AddToDbCommand AddToDbCommand { get; set; }
        public MedicalFile MedicalFile
        {
            get { return patientModel.MedicalFile; }
            set { 
                patientModel.MedicalFile = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MedicalFile"));
                }
            }
        }
        public AddMedicalFileViewModel(MainWindowViewModel containingVm, PatientModel patientModel)
        {
            this.containingVm = containingVm;
            this.patientModel = patientModel;
            AddToDbCommand = new AddToDbCommand(this);
            BackCommand = new BackCommand(this);
        }

        public void AddItemToDb()
        {
            patientModel.AddMedicalFileToPatient();
        }

        public bool ItemAlreadyExists()
        {
            return patientModel.MedicalFileAlreadyExists();
        }

        public bool UserWantsToReplaceExistingItem()
        {
            return true;
        }

        public void UpdateExistingItem()
        {
            patientModel.UpdateMedicalFile();
        }

        public void GoBack()
        {
            containingVm.ReplaceUC(Screen.ADD_MEDICAL_RECORD);
        }
    }
}
