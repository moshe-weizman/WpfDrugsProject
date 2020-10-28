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
    class AddMedicalRecordViewModel: IAddToDb,  IViewModel, IContainingVm
    {
        private MedicalRecordModel medicalRecordModel;
        private PhysicianShellViewModel containingVm;
        private string patientId;
        private Physician physicianUser;
        public AddMedicalRecordViewModel(PhysicianShellViewModel containingVm, string patientId, Physician physicianUser)
        {
            this.medicalRecordModel = new MedicalRecordModel(patientId, physicianUser);
            this.containingVm = containingVm;
            AddToDbCommand = new AddToDbCommand(this);
            this.patientId = patientId;
            this.physicianUser = physicianUser;
        }

        public AddToDbCommand AddToDbCommand { get; set; }
        public MedicalRecord MedicalRecord{ set { medicalRecordModel.MedicalRecord=value; } get {return medicalRecordModel.MedicalRecord; } }

        public void AddItemToDb()
        {
            medicalRecordModel.AddMedicalRecordToDb();
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

       
       
    }
}
