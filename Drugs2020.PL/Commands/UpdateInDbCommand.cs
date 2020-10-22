using Drugs2020.PL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Drugs2020.PL.Commands
{
    class UpdateInDbCommand : ICommand
    {
        private IUpdateInDb viewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public UpdateInDbCommand(IUpdateInDb viewModel)
        {
            this.viewModel = viewModel;
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
            viewModel.UpdateInDb();
        }
    }
}
