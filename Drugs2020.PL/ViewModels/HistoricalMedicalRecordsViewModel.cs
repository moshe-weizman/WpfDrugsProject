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
    class HistoricalMedicalRecordsViewModel : IViewModel, IGoBackScreenVM, INotifyPropertyChanged, IEdit
    {
        public ObservableCollection<MedicalRecord> MedicalRecordsCollection { get; set; }

        private MedicalRecordModel medicalRecordM;
        private PhysicianShellViewModel containingVm;
        private string patientId;
        private Physician physician;

        public event PropertyChangedEventHandler PropertyChanged;
        public BackCommand BackCommand { get; set; }
        public EditingItemCommand EditingItemCommand { get; set; }
        public HistoricalMedicalRecordsViewModel(PhysicianShellViewModel containingVm, string patientId, Physician physician)
        {
            this.containingVm = containingVm;
            this.medicalRecordM = new MedicalRecordModel(patientId, physician);
            MedicalRecordsCollection = new ObservableCollection<MedicalRecord>(medicalRecordM.MedicalRecordsList);
            BackCommand = new BackCommand(this);
            EditingItemCommand = new EditingItemCommand(this);
            this.physician = physician;
            this.patientId = patientId;
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public MedicalRecord SelectedMedicalRecord
        {
            get { return medicalRecordM.MedicalRecord; }
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
        public  void OpenEditingScreen(object item)
        {
            if (SelectedMedicalRecord.AbleEdit)
                containingVm.CurrentVM = new AddMedicalRecordViewModel(containingVm, patientId, physician, SelectedMedicalRecord);
            else
               containingVm.ShowMessage("A doctor who did not create the medical record could not edit it");
        }
    }
}
