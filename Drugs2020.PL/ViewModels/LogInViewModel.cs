using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System.ComponentModel;

namespace Drugs2020.PL.ViewModels
{
    class LogInViewModel : ILogInViewModel, IViewModel
    {

        private LogInModel logInModel;

        private MainWindowViewModel containingVm;
        public LogInCommand LogInUserCommand { get; set; }

        public LogInViewModel(MainWindowViewModel containingVm)
        {
            this.containingVm = containingVm;
            logInModel = new LogInModel();
            LogInUserCommand = new LogInCommand(this);
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


        public void IdentifyUser()
        {
            logInModel.IdentifyUser();
        }
        public bool ValidatePassword()
        {
            return logInModel.ValidatePassword();
        }
        public void LogUserIn()
        {
            if (User is Physician)
                containingVm.ReplaceUC(Screen.SEARCH_PATIENT_SCREEN);
            else
                containingVm.ReplaceUC(Screen.ACTIONS_MENU);
        }
    }
}
