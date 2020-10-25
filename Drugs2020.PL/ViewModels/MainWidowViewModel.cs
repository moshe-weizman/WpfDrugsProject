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
    class MainWidowViewModel : INotifyPropertyChanged, IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IViewModel _LeftCurrentVm;
        private IViewModel _RightCurrentVm;

        private LogInViewModel logInVM;
        private PatientSearchViewModel patientSearchVM;
        private AdminShellViewModel adminShellVM;
       // private PhysicianShellViewModel physicianShellVM;


     //   private PhysicianShellModel patientModel;
        public MainWidowViewModel()
        {
            //  patientModel = new PhysicianShellModel();
            //   MainWindowM = new MainWindowModel();
            logInVM = new LogInViewModel(this);

            // physicianShellVM = new PhysicianShellViewModel(this, patientModel);
            LeftCurrentVm = logInVM;
            VmInit();
        }

        private void VmInit()
        {
            patientSearchVM = new PatientSearchViewModel(this);
            adminShellVM = new AdminShellViewModel();
            //await Task.Run(() =>
            //{
            //    patientSearchVM = new PatientSearchViewModel(this);
            //    adminShellVM = new AdminShellViewModel();
            //});
        }

        //  public MainWindowModel MainWindowM { get; set; }
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

        public void ReplaceUC(Screen currentVM)
        {
            switch (currentVM)
            {
                case Screen.LOGIN_SCREEN:
                    LeftCurrentVm = logInVM;
                    break;
                case Screen.SEARCH_PATIENT_SCREEN:
                    LeftCurrentVm = patientSearchVM;
                    RightCurrentVm = null;
                    break;
                case Screen.ADMIN_SHELL:
                    LeftCurrentVm = adminShellVM;
                    RightCurrentVm = null;
                    break;
                default: break;
            }
        }
    }
}
