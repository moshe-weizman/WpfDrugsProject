using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System.ComponentModel;

namespace Drugs2020.PL.ViewModels
{
    class LogInViewModel : INotifyPropertyChanged, ILogInViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private LogInModel logInModel;
        public LogInCommand LogInUserCommand { get; set; }

        //public string UserId {
        //    get { return logInModel.UserId; }
        //    set { logInModel.UserId = value;} 
        //}
        //
        //public string Password
        //{
        //    get { return logInModel.Password; }
        //    set { logInModel.Password = value;}
        //}

        public LogInViewModel()
        {
            logInModel = new LogInModel();

            LogInUserCommand = new LogInCommand(this);
        }
        public IUser IdentifyUser(string userId)
        {
            return logInModel.IdentifyUser(userId);
        }
        public bool ValidatePassword(IUser user, string password)
        {
            return logInModel.ValidatePassword(user, password);
        }
    }
}
