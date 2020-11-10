using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class PhysicianShellViewModel : INotifyPropertyChanged, IViewModel, IContainingVm, IScreenReplacementVM, ISearch, IGoBackScreenVM, IDecide
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
        public ScreenReplacementCommand ScreenReplacementCommand { get; set; }
        public SearchItemCommand SearchCommand { get; set; }
        public BackCommand SignOutCommand { get; set; }
        public Physician PhysicianUser { get; set; }
        private string message;
        public string Message {
            get
            {
                return message;
            }
            set
            {
                message = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Message"));
            }
        }
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set 
            { 
                isBusy = value; 
                if(PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsBusy"));
            }
        }

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
        //public string PateintID { 
        //    get
        //    { 
        //        return physicianShellModel.CurrentPatient.ID; 
        //    } 
        //    set 
        //    { 
        //        physicianShellModel.CurrentPatient.ID = value;
        //        if (PropertyChanged != null)
        //            PropertyChanged(this, new PropertyChangedEventArgs("PateintID"));
        //    } 
        //}
        private MainWidowViewModel containingVm;

        private string patientId;
        public void Init(string patientId)
        {
            this.patientId = patientId;
            physicianShellModel = new PhysicianShellModel(patientId);
          //  patientDetailsVM = new PatientDetailsViewModel(this, patientId);
           // medicalFileVM = new MedicalFileViewModel(this, patientId, PhysicianUser);
          //  addMedicalRecordVM = new AddMedicalRecordViewModel(this, patientId, PhysicianUser);
          //  addReceptVM = new AddReceptViewModel(this, patientId, PhysicianUser);
           // consumptionOfDrugsVM = new ConsumptionOfDrugsViewModel(this, patientId);
            //historicalMedicalRecordsVM = new HistoricalMedicalRecordsViewModel(this, patientId, PhysicianUser);
            IsEnabledActionsMenu = true;
        }
        private bool isEnabledActionsMenu;

        private string decisionMessage;
        public string DecisionMessage
        {
            get { return decisionMessage; }
            set
            {
                decisionMessage = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("DecisionMessage"));
            }
        }

        public DecisionCommand DecisionCommand { get; set; }

        private bool isDecisionMessageShown;
        public bool IsDecisionMessageShown
        {
            get { return isDecisionMessageShown; }
            set
            {
                isDecisionMessageShown = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsDecisionMessageShown"));
            }
        }
        private Action action;
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
        public PhysicianShellViewModel(MainWidowViewModel containingVm, Physician physicianUser)
        {
            Message = "";
            IsBusy = false;
            IsDecisionMessageShown = false;
            DecisionMessage = "";
            DecisionCommand = new DecisionCommand(this);
            this.containingVm = containingVm;
            ScreenReplacementCommand = new ScreenReplacementCommand(this);
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
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void ReplaceScreen(Screen currentVM)
        {
            switch (currentVM)
            {
                case Screen.ADD_MEDICAL_FILE:
                    CurrentVM = new MedicalFileViewModel(this, patientId, PhysicianUser);
                    break;
                case Screen.ADD_MEDICAL_RECORD:
                    CurrentVM = new AddMedicalRecordViewModel(this, patientId, PhysicianUser);
                    break;
                case Screen.ADD_RECEPT:
                    CurrentVM = new AddReceptViewModel(this, patientId, PhysicianUser);
                    break;
                case Screen.PATIENT_DATA:
                    CurrentVM = new PatientDetailsViewModel(this, patientId);
                    break;
                case Screen.LIST_OF_DRUGS_TAKEN_BY_PATIENT:
                    CurrentVM = new ConsumptionOfDrugsViewModel(this, patientId);
                    break;
                case Screen.LIST_OF_MEDICAL_RECORDS:
                    CurrentVM  = new HistoricalMedicalRecordsViewModel(this, patientId, PhysicianUser);
                        break;
                case Screen.EMPTY:
                    CurrentVM= null;
                    break;
                default: break;
            }
        }

        public void GetItem(string patientId)
        {
            try
            {
                physicianShellModel.GetPatient(patientId);
                Init(patientId);
            }
            catch (KeyNotFoundException e) { ShowMessage(e.Message); }
            catch (Exception e) { ShowMessage(e.Message); }
           
        }
        public async void ShowMessage(string message)
        {
            await Task.Run(() =>
            {
                Message = message;
                Thread.Sleep(3000);
                Message = "";
            });
        }
        public void LetUserDecide(string message, Action action)
        {
            DecisionMessage = message;
            IsDecisionMessageShown = true;
            this.action = action;
        }
        public void ExecuteDecision(bool decision)
        {
            if (decision)
            {
                action.Invoke();
            }
            IsDecisionMessageShown = false;
        }

        public void GoBack()
        {
            containingVm.ReplaceUC(Screen.LOGIN_SCREEN); 
        }

       
    }
    
}
