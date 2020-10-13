using Drugs2020.PL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Drugs2020.PL.Commands
{
    class PatientSelectionCommand : ICommand
    {

        private PatientSearchViewModel patientSelectionVM;

        public PatientSelectionCommand(PatientSearchViewModel patientSelectionVM)
        {
            this.patientSelectionVM = patientSelectionVM;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            bool result=false;

            if (parameter != null)
                result = true;

            return result;
        }

        public void Execute(object parameter)
        {
            patientSelectionVM.GetPatient();
        }
    }
}
