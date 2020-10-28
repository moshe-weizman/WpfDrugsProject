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
    class PhysicianShellViewModel : INotifyPropertyChanged, IViewModel, IContainingVm
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private PatientDetailsViewModel patientDetailsVM;
        private MedicalFileViewModel medicalFileVM;
        private AddMedicalRecordViewModel addMedicalRecordVM;
        private AddReceptViewModel addReceptVM;
        private ConsumptionOfDrugsViewModel consumptionOfDrugsVM;
        private HistoricalMedicalRecordsViewModel historicalMedicalRecordsVM;
        private PatientSearchViewModel patientSearchVM;

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

        private IViewModel personalDetailsTab;
        public IViewModel PersonalDetailsTab
        {
            get { return personalDetailsTab; }
            set
            {
                personalDetailsTab = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("PersonalDetailsTab"));
            }
        }
        private IViewModel medicalFileTab; 
        public IViewModel MedicalFileTab
        {
            get { return medicalFileTab; }
            set
            {
                medicalFileTab = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("MedicalFileTab"));
            }
        }
        private IViewModel addReceptTab;
        public IViewModel AddReceptTab
        {
            get { return addReceptTab; }
            set
            {
                addReceptTab = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("AddReceptTab"));
            }
        }
        private IViewModel addMedicalRecordTab;
        public IViewModel AddMedicalRecordTab
        {
            get { return addMedicalRecordTab; }
            set
            {
                addMedicalRecordTab = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("AddMedicalRecordTab"));
            }
        }
        private string physicianId;
        public PhysicianShellViewModel(MainWidowViewModel containingVm, string patientId,string physicianId)
        {
            this.physicianId = physicianId;
            
            patientSearchVM = new PatientSearchViewModel(containingVm, physicianId);
            Init(patientId);
            PersonalDetailsTab = patientDetailsVM;
            AddReceptTab = addReceptVM;
            AddMedicalRecordTab = addMedicalRecordVM;
            MedicalFileTab = medicalFileVM;
        }

        public void Init(string patientId)
        {
            patientDetailsVM = new PatientDetailsViewModel(this, patientId);
            medicalFileVM = new MedicalFileViewModel(this, patientId, physicianId);
            addMedicalRecordVM = new AddMedicalRecordViewModel(this, patientId, physicianId);
            addReceptVM = new AddReceptViewModel(this, patientId, physicianId);
            consumptionOfDrugsVM = new ConsumptionOfDrugsViewModel(this, patientId);
            historicalMedicalRecordsVM = new HistoricalMedicalRecordsViewModel(this, patientId, physicianId);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void ReplaceUC(Screen currentVM)
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
