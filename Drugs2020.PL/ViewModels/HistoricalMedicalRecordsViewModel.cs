using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class HistoricalMedicalRecordsViewModel : IViewModel, IGoBackScreenVM
    {
        public ObservableCollection<MedicalRecord> MedicalRecordsCollection { get; set; }

        private MedicalRecordModel medicalRecordM;
        private PhysicianShellViewModel containingVm;
        public BackCommand BackCommand { get; set; }
        public HistoricalMedicalRecordsViewModel(PhysicianShellViewModel containingVm, string patientId, Physician physician)
        {
            this.containingVm = containingVm;
            this.medicalRecordM = new MedicalRecordModel(patientId, physician);
            MedicalRecordsCollection = new ObservableCollection<MedicalRecord>(medicalRecordM.MedicalRecordsList);
            BackCommand = new BackCommand(this);
        }
        public void GoBack()
        {
            containingVm.ReplaceScreen(Screen.ADD_MEDICAL_FILE);
        }
    }
}
