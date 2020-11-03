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
        public bool IsBusy { get; set; }
        public string Message { get; set; }
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
        //private IViewModel patientsTabVm; 
        //public IViewModel PatientsTabVm
        //{
        //    get { return patientsTabVm; }
        //    set
        //    {
        //        patientsTabVm = value;
        //        if (PropertyChanged != null)
        //            PropertyChanged(this, new PropertyChangedEventArgs("PatientsTabVm"));
        //    }
        //}
        //private IViewModel physiciansTabVm;
        //public IViewModel PhysiciansTabVm
        //{
        //    get { return physiciansTabVm; }
        //    set
        //    {
        //        physiciansTabVm = value;
        //        if (PropertyChanged != null)
        //            PropertyChanged(this, new PropertyChangedEventArgs("PhysiciansTabVm"));
        //    }
        //}
        //private IViewModel drugsTabVm;
        //public IViewModel DrugsTabVm
        //{
        //    get { return drugsTabVm; }
        //    set
        //    {
        //        drugsTabVm = value;
        //        if (PropertyChanged != null)
        //            PropertyChanged(this, new PropertyChangedEventArgs("DrugsTabVm"));
        //    }
        //}
        //private IViewModel statisticsTabVm;
        //public IViewModel StatisticsTabVm
        //{
        //    get { return statisticsTabVm; }
        //    set
        //    {
        //        statisticsTabVm = value;
        //        if (PropertyChanged != null)
        //            PropertyChanged(this, new PropertyChangedEventArgs("StatisticsTabVm"));
        //    }
        //}




        //private bool isEnabledActionsMenu;
        //public bool IsEnabledActionsMenu
        //{
        //    get { return isEnabledActionsMenu; }
        //    set
        //    {
        //        isEnabledActionsMenu = value;
        //        if (PropertyChanged != null)
        //            PropertyChanged(this, new PropertyChangedEventArgs("IsEnabledActionsMenu"));
        //    }
        //}
        private IViewModel DecisionMessageScreen;
        private PatientsManagementViewModel patientsManagementVm;
        private PhysiciansManagementViewModel physiciansManagementVm;
        private DrugsManagementViewModel drugssManagementVm;
        private DrugStatisticsViewModel drugsStatisticsVm;
        public AdminShellViewModel(MainWidowViewModel containingVm, Admin user)
        {
            this.containingVm = containingVm;
            SignOutCommand = new BackCommand(this);
            ScreenReplacementCommand = new ScreenReplacementCommand(this);
             Message = "";
            patientsManagementVm = new PatientsManagementViewModel(this);
           // patientsTabVm = patientsManagementVm;
            physiciansManagementVm = new PhysiciansManagementViewModel(this);
           // physiciansTabVm = physiciansManagementVm;
            drugssManagementVm = new DrugsManagementViewModel(this);
          //  drugsTabVm = drugssManagementVm;
            drugsStatisticsVm = new DrugStatisticsViewModel();
            // statisticsTabVm = drugsStatisticsVm;
           
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

        public void GoBack()
        {
            containingVm.GoBack();
        }
    }
}
