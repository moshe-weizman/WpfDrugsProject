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
    class PatientSelectionCommand : ICommand
    {

        private IPatientSearchViewModel patientSearchVm;

        public PatientSelectionCommand(IPatientSearchViewModel patientSelectionVM)
        {
            this.patientSearchVm = patientSelectionVM;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            bool result=false;

            if (parameter as string != "")
                result = true;

            return result;
        }

        public void Execute(object parameter)
        {
            patientSearchVm.GetPatient();
            if (patientSearchVm.PatientFound != null)
            {

            }
            else
            {
                MessageBox.Show("no patient found");
            }         
        }
    }
}
