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
        private PhysicianShellViewModel containingShellVm;//לכאורה לא נצרך
        public event PropertyChangedEventHandler PropertyChanged;
        public PhysicianShellModel physicianShellModel { get; set; }

        public PatientDetailsViewModel(PhysicianShellViewModel viewModel, string patientId)
        {
            containingShellVm = viewModel;
            physicianShellModel = new PhysicianShellModel(patientId);
        }
        public Patient CurrentPatient
        {
            get { return physicianShellModel.CurrentPatient; }
           
        }
       

    }
}
