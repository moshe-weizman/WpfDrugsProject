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
    class PatientDetailsViewModel : INotifyPropertyChanged, IViewModel
    {        
        private PhysicianShellViewModel containingShellVm;
        public event PropertyChangedEventHandler PropertyChanged;       


        public PatientDetailsViewModel(PhysicianShellViewModel viewModel)
        {
            containingShellVm = viewModel;
        }
        public Patient CurrentPatient
        {
            get { return containingShellVm.CurrentPatient; }
            set//לכאורה זה לא נצרך
            {
                containingShellVm.CurrentPatient = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentPatient"));
                }
            }
        }
       

    }
}
