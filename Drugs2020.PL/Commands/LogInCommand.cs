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
            var result = false;
            var values = (object[])parameter;

            if (values[0] as string != "" && values[1] as string != "")
                result = true;

            return result;
        }

        public void Execute(object parameter)
        {         
            logInViewModel.IdentifyUser();                 
            if (logInViewModel.User != null && logInViewModel.ValidatePassword()) //צריך להשתמש בתפסית חריגה במקום
            {              
                logInViewModel.LogUserIn();
            }
            else
            {
                MessageBox.Show("invalid user name or password");
            }
        }
    }
}
