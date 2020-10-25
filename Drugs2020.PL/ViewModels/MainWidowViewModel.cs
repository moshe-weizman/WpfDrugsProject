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
    class MainWidowViewModel : INotifyPropertyChanged, IViewModel, IGoBackScreenVM
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IViewModel _LeftCurrentVm;
        private LogInViewModel logInVM;
        private PatientSearchViewModel patientSearchVM;
        private AdminShellViewModel adminShellVM;
       
        public MainWidowViewModel()
        {
            logInVM = new LogInViewModel(this);
            LeftCurrentVm = logInVM;
            VmInit();
        }

        private void VmInit()
        {
            patientSearchVM = new PatientSearchViewModel(this);
            adminShellVM = new AdminShellViewModel(this);
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

        public void ReplaceUC(Screen currentVM)
        {
            switch (currentVM)
            {
                case Screen.LOGIN_SCREEN:
                    LeftCurrentVm = logInVM;
                    break;
                case Screen.SEARCH_PATIENT_SCREEN:
                    LeftCurrentVm = patientSearchVM;
                    break;
                case Screen.ADMIN_SHELL:
                    LeftCurrentVm = adminShellVM;
                    break;
                default: break;
            }
        }

        public void GoBack()
        {
            logInVM.Password = "";
            logInVM.UserId = "";
            LeftCurrentVm = logInVM;

        }
    }
}
