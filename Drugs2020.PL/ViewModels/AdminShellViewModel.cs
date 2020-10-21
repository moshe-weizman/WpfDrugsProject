using Drugs2020.PL.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class AdminShellViewModel : INotifyPropertyChanged, IViewModel, IScreenReplacementVM
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ScreenReplacementCommand ScreenReplacementCommand { get; set; }
        private IViewModel currentVm; 
        public IViewModel CurrentVm
        {
            get { return currentVm; }
            set
            {
                currentVm = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentVm"));
            }
        }
        private PatientManagementViewModel patientManagementVm;

        public AdminShellViewModel()
        {
            patientManagementVm = new PatientManagementViewModel(this);
            ScreenReplacementCommand = new ScreenReplacementCommand(this);
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
                    CurrentVm = new AddPatientViewModel(this);
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
                    CurrentVm = patientManagementVm;
                    break;
                default:
                    break;
            }
        }
    }
}
