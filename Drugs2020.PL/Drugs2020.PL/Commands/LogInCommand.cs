using Drugs2020.BLL.BE;
using Drugs2020.PL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Drugs2020.PL.Commands
{
    class LogInCommand : ICommand
    {
        private ILogInViewModel logInViewModel;

        public LogInCommand(LogInViewModel logInViewModel)
        {
            this.logInViewModel = logInViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            var result = false;

            var values = (object[])parameter;

            if ((string)values[0] != "" && (string)values[1] != "")
            {
                result = true;
            }

            return result;
        }

        public void Execute(object parameter)
        {
            var values = (object[])parameter;
            var userId = (string)values[0];
            var password = (string)values[1];

            IUser user = logInViewModel.IdentifyUser(userId);
            if (user != null && logInViewModel.ValidatePassword(user, password))
            {
                //new userControl
            }
            else
            {
                //no such user
            }
        }
    }
}
