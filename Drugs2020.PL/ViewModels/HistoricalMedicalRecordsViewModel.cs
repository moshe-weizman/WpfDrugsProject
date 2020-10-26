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
        private IContainingVm containingVm;

        public BackCommand BackCommand { get; set; }
        public HistoricalMedicalRecordsViewModel(IContainingVm containingVm, string patientId, string physicianId)
        {
            this.containingVm = containingVm;
            this.medicalRecordM = new MedicalRecordModel(patientId, physicianId);
            MedicalRecordsCollection = new ObservableCollection<MedicalRecord>(medicalRecordM.MedicalRecordsList);
            BackCommand = new BackCommand(this);
        }

        public void GoBack()
        {
            containingVm.ReturnToContaining();
        }
    }
}
