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
    class AddMedicalRecordViewModel: IAddToDb, IGoBackScreenVM, IViewModel, IContainingVm, IReplaceScreen
    {
        private MedicalRecordModel medicalRecordModel;
        private PhysicianShellViewModel containingVm;
        private string patientId;
        private string physicianId;
        public AddMedicalRecordViewModel(PhysicianShellViewModel containingVm, string patientId,string physicianId)
        {
            this.medicalRecordModel = new MedicalRecordModel(patientId, physicianId);
            this.containingVm = containingVm;
            BackCommand = new BackCommand(this);
            AddToDbCommand = new AddToDbCommand(this);
            MedicalRecord = new MedicalRecord();
            this.patientId = patientId;
            this.physicianId = physicianId;
            ReplaceScreenCommand = new ReplaceScreenCommand(this);

        }

        public AddToDbCommand AddToDbCommand { get; set; }
        public BackCommand BackCommand { get; set; }
        public ReplaceScreenCommand ReplaceScreenCommand { get; set; }
        public MedicalRecord MedicalRecord{ set { medicalRecordModel.MedicalRecord=value; } get {return medicalRecordModel.MedicalRecord; } }

        public void AddItemToDb()
        {
            medicalRecordModel.AddMedicalRecordToDb();
        }

        public void GoBack()
        {
            containingVm.ReplaceUC(Screen.SEARCH_PATIENT_SCREEN);
        }

        public bool ItemAlreadyExists()
        {
          return  medicalRecordModel.MedicalRecordAlreadyExists();
        }

       
        public void UpdateExistingItem()
        {
            medicalRecordModel.UpdateMedicalRecord();
            
        }

        public bool UserWantsToReplaceExistingItem()
        {
            ExistingItemDecisionViewModel decision = new ExistingItemDecisionViewModel("medical record");
            return decision.Decision;
        }

        public void ReturnToContaining()
        {
            containingVm.AddMedicalRecordTab = this;
        }

        public void ReplaceScreen()
        {
            containingVm.AddMedicalRecordTab = new HistoricalMedicalRecordsViewModel(this, patientId, physicianId);
        }
    }
}
