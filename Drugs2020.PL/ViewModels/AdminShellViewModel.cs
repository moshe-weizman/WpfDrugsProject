using Drugs2020.PL.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    public class AdminShellViewModel : INotifyPropertyChanged, IViewModel, IScreenReplacementVM, IGoBackScreenVM
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IGoBackScreenVM containingVm;
        public bool IsDecisionMessageShown { get; set; }
        public bool Decision { get; set; }
        public string UserName { get; set; }
        public bool IsBusy { get; set; }
        public string Message { get; set; }
        public BackCommand SignOutCommand { get; set; }
        private IViewModel patientsTabVm; 
        public IViewModel PatientsTabVm
        {
            get { return patientsTabVm; }
            set
            {
                patientsTabVm = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("PatientsTabVm"));
            }
        }
        private IViewModel physiciansTabVm;
        public IViewModel PhysiciansTabVm
        {
            get { return physiciansTabVm; }
            set
            {
                physiciansTabVm = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("PhysiciansTabVm"));
            }
        }
        private IViewModel drugsTabVm;
        public IViewModel DrugsTabVm
        {
            get { return drugsTabVm; }
            set
            {
                drugsTabVm = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("DrugsTabVm"));
            }
        }
        private IViewModel statisticsTabVm;
        public IViewModel StatisticsTabVm
        {
            get { return statisticsTabVm; }
            set
            {
                statisticsTabVm = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("StatisticsTabVm"));
            }
        }
        private IViewModel DecisionMessageScreen;
        private PatientsManagementViewModel patientsManagementVm;
        private PhysiciansManagementViewModel physiciansManagementVm;
        private DrugsManagementViewModel drugssManagementVm;

        public AdminShellViewModel(IGoBackScreenVM containingVm)
        {
            this.containingVm = containingVm;
            SignOutCommand = new BackCommand(this);
            patientsManagementVm = new PatientsManagementViewModel(this);
            patientsTabVm = patientsManagementVm;
            physiciansManagementVm = new PhysiciansManagementViewModel(this);
            physiciansTabVm = physiciansManagementVm;
            drugssManagementVm = new DrugsManagementViewModel(this);
            drugsTabVm = drugssManagementVm;
        }

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
       
        

        public void ReplaceScreen(Screen desiredScreen)
        {
            switch (desiredScreen)
            {
                case Screen.LOGIN_SCREEN:
                    break;
                case Screen.SEARCH_PATIENT_SCREEN:
                    break;
                case Screen.ACTIONS_MENU:
                    break;
                case Screen.ADD_PATIENT_SCREEN:
                    break;
                case Screen.ADD_PHYSICIAN_SCREEN:
                    break;
                case Screen.ADD_DRUG:
                    break;
                case Screen.DATA:
                    break;
                case Screen.PATIENT_DATA:
                    break;
                case Screen.ADD_MEDICAL_FILE:
                    break;
                case Screen.ADD_MEDICAL_RECORD:
                    break;
                case Screen.EMPTY:
                    break;
                case Screen.ADD_RECEPT:
                    break;
                case Screen.PATIENTS_MANAGEMENT:
                    PatientsTabVm = patientsManagementVm;
                    break;
                default:
                    break;
            }
        }

        public void GoBack()
        {
            containingVm.GoBack();
        }
    }
}
