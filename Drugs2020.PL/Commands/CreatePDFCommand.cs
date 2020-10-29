using Drugs2020.PL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Drugs2020.PL.Commands
{
    public class CreatePDFCommand : ICommand
    {
        private ICreatePDFVM operationVM;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public CreatePDFCommand(ICreatePDFVM operationVM)
        {
            this.operationVM = operationVM;
        }
        public bool CanExecute(object parameter)
        {
            return operationVM.IsEnabledPDF;
        }

        public void Execute(object parameter)
        {
            operationVM.DoPDF();
        }
    }
}
