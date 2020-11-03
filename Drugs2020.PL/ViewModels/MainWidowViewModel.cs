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
    public class MainWidowViewModel : INotifyPropertyChanged, IViewModel, IGoBackScreenVM
    {
        public event PropertyChangedEventHandler PropertyChanged;

        
        private LogInViewModel logInVM;
        private PhysicianShellViewModel physicianShellVM;
        private AdminShellViewModel adminShellVM;
        
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
        public MainWidowViewModel()
        {
            logInVM = new LogInViewModel(this);
            CurrentVm = logInVM;
        }

        public void InitPhysicianSell(IUser user)
        {
            physicianShellVM = new PhysicianShellViewModel(this, (Physician)user);
            CurrentVm = physicianShellVM;
        }

        public void InitAdminSell(IUser user)
        {
            adminShellVM = new AdminShellViewModel(this, (Admin)user);
            CurrentVm = adminShellVM;
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void ReplaceUC(Screen currentVM)
        {
            switch (currentVM)
            {
                case Screen.LOGIN_SCREEN:
                    CurrentVm = logInVM;
                    break;
                case Screen.PHYSICIAN_SHELL:
                   
                    break;
                case Screen.ADMIN_SHELL:
                    break;
                default: break;
            }
        }

        public void GoBack()
        {
            logInVM.Password = "";
            logInVM.UserId = "";
            CurrentVm = logInVM;

        }
    }
}
