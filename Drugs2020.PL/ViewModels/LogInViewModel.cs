using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class LogInViewModel : ILogInViewModel, IViewModel, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private LogInModel logInModel;

        private MainWidowViewModel containingVm;
        public LogInCommand LogInUserCommand { get; set; }
        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsBusy"));
            }
        }

        private bool isPasswordInvalid;

        public bool IsPasswordInvalid
        {
            get { return isPasswordInvalid; }
            set
            {
                isPasswordInvalid = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsPasswordInvalid"));
            }
        }
        private string message;

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Message"));
            }
        }


        public string UserId
        {
            get { return logInModel.UserId; }
            set { logInModel.UserId = value; }
        }

        public string Password
        {
            get { return logInModel.Password; }
            set { logInModel.Password = value; }
        }
        public IUser User
        {
            get { return logInModel.User; }
            set { logInModel.User = value; }
        }

        public LogInViewModel(MainWidowViewModel containingVm)
        {
            this.containingVm = containingVm;
            logInModel = new LogInModel();
            LogInUserCommand = new LogInCommand(this);
            Message = "";
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        
        public void IdentifyUser()
        {
            try
            {
                logInModel.IdentifyUser();
            }
            catch (KeyNotFoundException e) {  }
            catch (Exception e) {  }
        }
        public bool ValidatePassword()
        {
            return logInModel.ValidatePassword();
        }
        public async void LogUserIn()
        {
            IsPasswordInvalid = false;
            IsBusy = true;
            await Task.Run(() =>
            {
                if (User is Physician)

                    containingVm.InitPhysicianSell(User);
                else
                    containingVm.InitAdminSell(User);
                IsBusy = false;
            });
        }

        public async void LogIn()
        {
            IsBusy = true;
            Message = "Checking";
            await Task.Run(() =>
            {
                try
                {
                    IdentifyUser();

                }
                catch (KeyNotFoundException ex) 
                {
                    IsBusy = false;
                    IsPasswordInvalid = true;
                }
                if (User != null && ValidatePassword() == true)
                {
                    LogUserIn();
                }
                else
                {
                    IsBusy = false;
                    IsPasswordInvalid = true;
                }
            });
        }
    }
}
