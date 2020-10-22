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
        private IViewModel patientsVm; 
        public IViewModel PatientsVm
        {
            get { return patientsVm; }
            set
            {
                patientsVm = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("PatientsVm"));
            }
        }
        private IViewModel physiciansVm;
        public IViewModel PhysiciansVm
        {
            get { return physiciansVm; }
            set
            {
                physiciansVm = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("PhysiciansVm"));
            }
        }
        private IViewModel drugsVm;
        public IViewModel DrugsVm
        {
            get { return drugsVm; }
            set
            {
                drugsVm = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("DrugsVm"));
            }
        }
        private IViewModel statisticsVm;
        public IViewModel StatisticsVm
        {
            get { return statisticsVm; }
            set
            {
                statisticsVm = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("StatisticsVm"));
            }
        }
        private PatientsManagementViewModel patientsManagementVm;

        public AdminShellViewModel()
        {
            patientsManagementVm = new PatientsManagementViewModel(this);
            patientsVm = patientsManagementVm;
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
                    PatientsVm = patientsManagementVm;
                    break;
                default:
                    break;
            }
        }
    }
}
