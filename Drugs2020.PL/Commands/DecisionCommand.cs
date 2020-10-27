using Drugs2020.PL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Drugs2020.PL.Commands
{
    class DecisionCommand : ICommand
    {
        private IDecide viewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DecisionCommand(IDecide viewModel)
        {
            this.viewModel = viewModel;
        }



        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string param = parameter as string;
            bool decision = (param == "YES") ? true : false;
            viewModel.ExecuteDecision(decision);
        }
    }
}

   