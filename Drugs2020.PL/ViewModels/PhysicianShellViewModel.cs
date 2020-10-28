using Drugs2020.BLL.BE;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class PhysicianShellViewModel : INotifyPropertyChanged, IViewModel, IContainingVm, IScreenReplacementVM
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private PatientDetailsViewModel patientDetailsVM;
        private MedicalFileViewModel medicalFileVM;
        private AddMedicalRecordViewModel addMedicalRecordVM;
        private AddReceptViewModel addReceptVM;
        private ConsumptionOfDrugsViewModel consumptionOfDrugsVM;
        private HistoricalMedicalRecordsViewModel historicalMedicalRecordsVM;
        private PatientSearchViewModel patientSearchVM;

        private PhysicianShellModel physicianShellModel;
        public Physician PhysicianUser { get; set; }

        private IViewModel currentVM;
        public IViewModel CurrentVM
        {
            get { return currentVM; }
            set
            {
                currentVM = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentVM"));
            }
        }
        public string PateintID { 
            get
            { 
                return physicianShellModel.CurrentPatient.ID; 
            } 
            set 
            { 
                physicianShellModel.CurrentPatient.ID = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("PateintID"));
            } 
        }

        public PhysicianShellViewModel(MainWidowViewModel containingVm, string patientId,Physician physicianUser)
        {
            physicianShellModel = new PhysicianShellModel();
            Init(patientId);
            //patientSearchVM = new PatientSearchViewModel(containingVm, physicianUser);
            this.PhysicianUser = physicianUser;
            CurrentVM = null;
            //PersonalDetailsTab = patientDetailsVM;
            //AddReceptTab = addReceptVM;
            //AddMedicalRecordTab = addMedicalRecordVM;
            //MedicalFileTab = medicalFileVM;
        }

        public void Init(string patientId)
        {
            patientDetailsVM = new PatientDetailsViewModel(this, patientId);
            medicalFileVM = new MedicalFileViewModel(this, patientId, PhysicianUser);
            addMedicalRecordVM = new AddMedicalRecordViewModel(this, patientId, PhysicianUser);
            addReceptVM = new AddReceptViewModel(this, patientId, PhysicianUser);
            consumptionOfDrugsVM = new ConsumptionOfDrugsViewModel(this, patientId);
            historicalMedicalRecordsVM = new HistoricalMedicalRecordsViewModel(this, patientId, PhysicianUser);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void ReplaceScreen(Screen currentVM)
        {
            switch (currentVM)
            {
                case Screen.SEARCH_PATIENT_SCREEN:
                    CurrentVM = patientSearchVM;
                    break;
                case Screen.ADD_MEDICAL_FILE:
                    CurrentVM = medicalFileVM;
                    break;
                case Screen.ADD_MEDICAL_RECORD:
                    CurrentVM = addMedicalRecordVM;
                    break;
                case Screen.ADD_RECEPT:
                    CurrentVM = addReceptVM;
                    break;
                case Screen.PATIENT_DATA:
                    CurrentVM = patientDetailsVM;
                        break;
                case Screen.LIST_OF_DRUGS_TAKEN_BY_PATIENT:
                    CurrentVM = consumptionOfDrugsVM;
                    break;
                case Screen.LIST_OF_MEDICAL_RECORDS:
                    CurrentVM = historicalMedicalRecordsVM;
                        break;
                case Screen.EMPTY:
                    CurrentVM= null;
                    break;
                default: break;
            }
        }

       
        //public void GetItem(string id)?
        //{

        //}
    }
    
}
