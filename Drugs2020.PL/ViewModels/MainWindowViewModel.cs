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

        private IViewModel _CurrentVm;
        private IViewModel _RightCurrentVm;

        private LogInViewModel logInVM;
        private PatientSearchViewModel patientSearchVM;
        private AddPatientViewModel addPatientVM;
        private ActionsMenuViewModel actionsMenuVM;

       
        public IViewModel RightCurrentVm 
        {
            get { return _RightCurrentVm; }
            set { _RightCurrentVm = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("RightCurrentVm"));
            }
        }

        public MainWindowModel MainWindowM { get; set; }
        public IViewModel CurrentVm
        {
            get { return _CurrentVm; }
            set 
            { 
                _CurrentVm = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentVm"));
            }
        }

        public MainWindowViewModel()
        {
            logInVM = new LogInViewModel(this);
            patientSearchVM = new PatientSearchViewModel(this);
            addPatientVM = new AddPatientViewModel(this);
            actionsMenuVM = new ActionsMenuViewModel(this);
            CurrentVm  = logInVM;
        }

        public void ReplaceLeftUC(Screen currentVM)
        {
            switch (currentVM)
            {
                case Screen.LOGIN_SCREEN:
                    CurrentVm = logInVM;
                    break;
                case Screen.SEARCH_PATIENT_SCREEN:
                    CurrentVm = patientSearchVM;
                    break;
                case Screen.ADD_PATIENT_SCREEN:
                     CurrentVm = addPatientVM;
                    break;
                case Screen.ACTIONS_MENU:
                    CurrentVm = actionsMenuVM;
                    break;
                default: break;
            }
        }

        public void ReplaceRightUC(Screen currentVM)
        {
            switch (currentVM)
            {
                case Screen.LOGIN_SCREEN:
                    RightCurrentVm = logInVM;
                    break;
                case Screen.SEARCH_PATIENT_SCREEN:
                    RightCurrentVm = patientSearchVM;
                    break;
                case Screen.ADD_PATIENT_SCREEN:
                    RightCurrentVm = addPatientVM;
                    break;
                case Screen.ACTIONS_MENU:
                    RightCurrentVm = actionsMenuVM;
                    break;
                default: break;
            }
        }
    }
}
