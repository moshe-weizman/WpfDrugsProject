using Drugs2020.BLL.BE;
using Drugs2020.PL.Models;
using Drugs2020.PL.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged, IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IViewModel _LeftCurrentVm;
        private IViewModel _RightCurrentVm;

        private LogInViewModel logInVM;
        private PatientSearchViewModel patientSearchVM;
        private AddPatientViewModel addPatientVM;
        private ActionsMenuViewModel actionsMenuVM;
        private PatientDataViewModel patientDataVM;
        private AddMedicalFileViewModel addMedicalFileVM;
        private VisitTheClinicViewModel visitingTheClinicVM;

        private PatientModel patientModel;
        public MainWindowViewModel()
        {
            patientModel = new PatientModel();
            MainWindowM = new MainWindowModel();
            logInVM = new LogInViewModel(this);
            patientSearchVM = new PatientSearchViewModel(this, patientModel);
            addPatientVM = new AddPatientViewModel(this);
            actionsMenuVM = new ActionsMenuViewModel(this);
            patientDataVM = new PatientDataViewModel(this, patientModel);
            addMedicalFileVM = new AddMedicalFileViewModel(this, patientModel);
            visitingTheClinicVM = new VisitTheClinicViewModel(this, patientModel);
            LeftCurrentVm = logInVM;
        }
        public MainWindowModel MainWindowM { get; set; }
        public IViewModel RightCurrentVm 
        {
            get { return _RightCurrentVm; }
            set { _RightCurrentVm = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("RightCurrentVm"));
            }
        }

        public IViewModel LeftCurrentVm
        {
            get { return _LeftCurrentVm; }
            set 
            { 
                _LeftCurrentVm = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("LeftCurrentVm"));
            }
        }

        public void ReplaceLeftUC(Screen currentVM)
        {
            switch (currentVM)
            {
                case Screen.LOGIN_SCREEN:
                    LeftCurrentVm = logInVM;
                    break;
                case Screen.SEARCH_PATIENT_SCREEN:
                    LeftCurrentVm = patientSearchVM;
                    break;
                case Screen.ADD_PATIENT_SCREEN:
                     LeftCurrentVm = addPatientVM;
                    break;
                case Screen.ACTIONS_MENU:
                    LeftCurrentVm = actionsMenuVM;
                    break;
                case Screen.ADD_MEDICAL_FILE:
                    LeftCurrentVm = addMedicalFileVM;
                    break;
                default: break;
            }
        }

        public void ReplaceRightUC(Screen currentVM)
        {
            switch (currentVM)
            {
                case Screen.PATIENT_DATA:
                    RightCurrentVm = patientDataVM;
                    break;
                case Screen.EMPTY:
                    RightCurrentVm = null;
                    break;
                default: break;
            }
        }
    }
}
