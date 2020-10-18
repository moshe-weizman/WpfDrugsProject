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
        //private PatientDataModel patientDataModel;
        private MainWindowViewModel containingVm;
        public event PropertyChangedEventHandler PropertyChanged;
        public Patient CurrentPatient
        {
            get { return containingVm.MainWindowM.Patient; }
            set//לכאורה זה לא נצרך
            {
                containingVm.MainWindowM.Patient = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentPatient"));
                }
            }
        }
        public PatientDataViewModel(MainWindowViewModel viewModel)
        {
            containingVm = viewModel;
           // patientDataModel = new PatientDataModel();
            //CurrentPatient = containingVm.MainWindowM.Patient;
        }

    }
}
