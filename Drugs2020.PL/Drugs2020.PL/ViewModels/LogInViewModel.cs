using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System.ComponentModel;

namespace Drugs2020.PL.ViewModels
{
    class LogInViewModel : ILogInViewModel
    {

        private LogInModel logInModel;
        public LogInCommand LogInUserCommand { get; set; }

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

        public LogInViewModel()
        {
            logInModel = new LogInModel();

            LogInUserCommand = new LogInCommand(this);
        }
        public IUser IdentifyUser()
        {
            return logInModel.IdentifyUser();
        }
        public bool ValidatePassword()
        {
            return logInModel.ValidatePassword();
        }
    }
}
