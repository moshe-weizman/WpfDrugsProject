using Drugs2020.BLL.BE;
using Drugs2020.PL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Drugs2020.PL.Commands
{
    class LogInCommand : ICommand
    {
        private ILogInViewModel logInViewModel;

        public LogInCommand(ILogInViewModel logInViewModel)
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
            bool result = false;
            if (parameter != null)
            {
                result = (bool)parameter;
            }
            return result;
        }

        public void Execute(object parameter)
        {         
            logInViewModel.IdentifyUser();                 
            if (logInViewModel.User != null && logInViewModel.ValidatePassword()) //צריך להשתמש בתפסית חריגה במקום
            {              
                logInViewModel.LogUserIn(parameter as string);
            }
            else
            {
                MessageBox.Show("invalid user name or password");
            }
        }
    }
}
