using Drugs2020.BLL.BE;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class PatientDataViewModel : INotifyPropertyChanged, IViewModel
    {
        private PatientModel patientModel;
        private MainWindowViewModel containingVm;
        public event PropertyChangedEventHandler PropertyChanged;

        public PatientDataViewModel(MainWindowViewModel viewModel, PatientModel patientModel)
        {
            containingVm = viewModel;
            this.patientModel = patientModel;
        }
        public Patient CurrentPatient
        {
            get { return patientModel.CurrentPatient; }
            set//לכאורה זה לא נצרך
            {
                patientModel.CurrentPatient = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentPatient"));
                }
            }
        }
       

    }
}
