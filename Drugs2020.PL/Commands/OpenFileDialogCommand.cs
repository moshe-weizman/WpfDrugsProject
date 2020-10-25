using Drugs2020.PL.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Drugs2020.PL.Commands
{
    class OpenFileDialogCommand : ICommand
    {
        private IBrowse viewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public OpenFileDialogCommand(IBrowse viewModel)
        {
            this.viewModel = viewModel;
        }



        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string path = new OpenFileDialog().FileName;
            viewModel.SavePath(path);
        }
    }
}
