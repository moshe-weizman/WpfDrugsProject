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
    class AddMedicalRecordViewModel: IAddToDb, IGoBackScreenVM, IViewModel
    {
        private MedicalRecordModel medicalRecordModel;
        private PhysicianShellViewModel containingVm;

        public AddMedicalRecordViewModel(PhysicianShellViewModel containingVm, string patientId)
        {
            this.medicalRecordModel = new MedicalRecordModel(patientId);
            this.containingVm = containingVm;
            BackCommand = new BackCommand(this);
            AddToDbCommand = new AddToDbCommand(this);
            MedicalRecord = new MedicalRecord();
        }

        public AddToDbCommand AddToDbCommand { get; set; }
        public BackCommand BackCommand { get; set; }

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
            //medicalRecordModel.MedicalFile.MedicalRecords.Add(MedicalRecord);
            //medicalRecordModel.UpdateMedicalFile();
        }

        public bool UserWantsToReplaceExistingItem()
        {
            ExistingItemDecisionViewModel decision = new ExistingItemDecisionViewModel("medical record");
            return decision.Decision;
        }
    }
}
