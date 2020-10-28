using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class PhysicianShellViewModel : INotifyPropertyChanged, IViewModel, IContainingVm, IScreenReplacementVM, ISearch, IGoBackScreenVM
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
        public SearchItemCommand SearchCommand { get; set; }

        public BackCommand SignOutCommand { get; set; }
        public Physician PhysicianUser { get; set; }

        public Patient PatientFound {
            get
            {
                return physicianShellModel.CurrentPatient;
            } 
            set {
                physicianShellModel.CurrentPatient = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("PatientFound"));
            }
        }

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
        private MainWidowViewModel containingVm;
        public PhysicianShellViewModel(MainWidowViewModel containingVm , Physician physicianUser)
        {
            this.containingVm = containingVm;
            SearchCommand = new SearchItemCommand(this);
            SignOutCommand = new BackCommand(this);
            physicianShellModel = new PhysicianShellModel();
            //patientSearchVM = new PatientSearchViewModel(containingVm, physicianUser);
            this.PhysicianUser = physicianUser;
            IsEnabledActionsMenu = false;
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
            IsEnabledActionsMenu = true;
        }
        private bool isEnabledActionsMenu;
        public bool IsEnabledActionsMenu
        {
            get { return isEnabledActionsMenu; }
            set
            {
                isEnabledActionsMenu = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsEnabledActionsMenu"));
            }
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void ReplaceScreen(Screen currentVM)
        {
            switch (currentVM)
            {
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

        public void GetItem(string patientId)
        {
            physicianShellModel.GetPatient(patientId);
            if (PatientFound != null)
            {
                Init(patientId);
            }
        }

        public void GoBack()
        {
            CurrentVM = new LogInViewModel(containingVm);
        }
    }
    
}
