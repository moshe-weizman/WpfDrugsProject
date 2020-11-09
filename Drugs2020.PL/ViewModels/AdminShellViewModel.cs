using Drugs2020.BLL.BE;
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
        private MainWidowViewModel containingVm;
        public Admin Admin { get; set; }
        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set {
                isBusy = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsBusy"));
            }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { 
                message = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Message"));
            }
        }

        public BackCommand SignOutCommand { get; set; }
        public IViewModel DecisionMessage { get; set; }

        public ScreenReplacementCommand ScreenReplacementCommand { get; set; }

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
        
        private IViewModel DecisionMessageScreen;
        private PatientsManagementViewModel patientsManagementVm;
        private PhysiciansManagementViewModel physiciansManagementVm;
        private DrugsManagementViewModel drugssManagementVm;
        private DrugStatisticsViewModel drugsStatisticsVm;
        public AdminShellViewModel(MainWidowViewModel containingVm, Admin user)
        {
            this.containingVm = containingVm;
            this.Admin = user;
            SignOutCommand = new BackCommand(this);
            ScreenReplacementCommand = new ScreenReplacementCommand(this);
             Message = "";
            patientsManagementVm = new PatientsManagementViewModel(this);
            physiciansManagementVm = new PhysiciansManagementViewModel(this);
            drugssManagementVm = new DrugsManagementViewModel(this);
            drugsStatisticsVm = new DrugStatisticsViewModel();
            CurrentVM = null;
        }
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void ReplaceScreen(Screen desiredScreen)
        {
            switch (desiredScreen)
            {
                case Screen.LOGIN_SCREEN:
                    break;
                case Screen.ADD_PATIENT_SCREEN:
                    CurrentVM = new AddPatientViewModel(this);
                    break;
                case Screen.ADD_PHYSICIAN_SCREEN:
                    CurrentVM = new AddPhysicianViewModel(this);
                    break;
                case Screen.ADD_DRUG:
                    CurrentVM = new AddDrugViewModel(this);
                    break;
                case Screen.DATA:
                    CurrentVM = new DrugStatisticsViewModel();
                    break;
                case Screen.PHYSICIANS_MANAGEMENT:
                    CurrentVM = new PhysiciansManagementViewModel(this);
                     break;
                case Screen.DRUGS_MANAGEMENT:
                    CurrentVM = new DrugsManagementViewModel(this);
                    break;
                case Screen.PATIENTS_MANAGEMENT:
                    CurrentVM = new PatientsManagementViewModel(this);
                    break;
                case Screen.EMPTY:
                    break;
                default:
                    break;
            }
        }
        public void startProcessing(string message)
        {
            Message = message;
            IsBusy = true;
        }
        public async void finishProcessing(string message)
        {
            await Task.Run(() =>
            {
                Message = message;
                IsBusy = false;
                System.Threading.Thread.Sleep(3000);
                Message = "";
            });  
        }
        public void GoBack()
        {
            containingVm.GoBack();
        }
    }
}
