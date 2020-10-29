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
    class HistoricalMedicalRecordsViewModel : IViewModel, IGoBackScreenVM, IScreenReplacementVM, INotifyPropertyChanged
    {
        public ObservableCollection<MedicalRecord> MedicalRecordsCollection { get; set; }

        private MedicalRecordModel medicalRecordM;
        private PhysicianShellViewModel containingVm;

        public event PropertyChangedEventHandler PropertyChanged;

        public BackCommand BackCommand { get; set; }

        public ScreenReplacementCommand ScreenReplacementCommand { get; set; }
        public HistoricalMedicalRecordsViewModel(PhysicianShellViewModel containingVm, string patientId, Physician physician)
        {
            this.containingVm = containingVm;
            this.medicalRecordM = new MedicalRecordModel(patientId, physician);
            MedicalRecordsCollection = new ObservableCollection<MedicalRecord>(medicalRecordM.MedicalRecordsList);
            BackCommand = new BackCommand(this);
            ScreenReplacementCommand = new ScreenReplacementCommand(this);
        }
        public MedicalRecord SelectedMedicalRecord
        {
            set
            {
                medicalRecordM.MedicalRecord = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedMedicalRecord"));
            }
        }
        public void GoBack()
        {
            containingVm.ReplaceScreen(Screen.ADD_MEDICAL_FILE);
        }

        public void ReplaceScreen(Screen desiredScreen)
        {
            containingVm.ReplaceScreen(desiredScreen);
           
        }
    }
}
