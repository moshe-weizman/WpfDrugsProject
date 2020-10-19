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
    class VisitTheClinicViewModel: IAddToDb, IGoBackScreenVM
    {
        private PatientModel patientModel;
        private MainWindowViewModel containingVm;

        public VisitTheClinicViewModel(MainWindowViewModel containingVm, PatientModel patientModel)
        {
            this.patientModel = patientModel;
            this.containingVm = containingVm;
        }

        public AddToDbCommand AddToDbCommand { get; set; }

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

        public void UpdateExistingItem()
        {
            patientModel.CurrentPatient.MedicalFile.MedicalRecords.Add(MedicalRecord);
            patientModel.UpdatePatient();
        }

        public bool UserWantsToReplaceExistingItem()
        {
            return true;
        }
    }
}
