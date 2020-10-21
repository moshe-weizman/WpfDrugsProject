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
    class AddMedicalRecordViewModel: IAddToDb, IGoBackScreenVM, IViewModel, IScreenReplacementVM
    {
        private MedicalFileModel medicalFileModel;
        private PhysicianShellViewModel containingVm;

        public AddMedicalRecordViewModel(PhysicianShellViewModel containingVm, string patientId)
        {
            this.medicalFileModel = new MedicalFileModel(patientId);
            this.containingVm = containingVm;
            BackCommand = new BackCommand(this);
            AddToDbCommand = new AddToDbCommand(this);
            MedicalRecord = new MedicalRecord();
            ScreenReplacementCommand = new ScreenReplacementCommand(this);
        }

        public AddToDbCommand AddToDbCommand { get; set; }
        public ScreenReplacementCommand ScreenReplacementCommand { get; set; }
        public BackCommand BackCommand { get; set; }

        public MedicalRecord MedicalRecord{ set; get; }

        public void AddItemToDb()
        {
            throw new NotImplementedException();
        }

        public void GoBack()
        {
            containingVm.ReplaceUC(Screen.SEARCH_PATIENT_SCREEN);
        }

        public bool ItemAlreadyExists()
        {
            return true;
        }

        public void ReplaceScreen(Screen desiredScreen)
        {
            containingVm.ReplaceUC(desiredScreen);
        }

        public void UpdateExistingItem()
        {
            medicalFileModel.MedicalFile.MedicalRecords.Add(MedicalRecord);
            medicalFileModel.UpdateMedicalFile();
        }

        public bool UserWantsToReplaceExistingItem()
        {
            return true;
        }
    }
}
