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
    class PatientDataViewModel : INotifyPropertyChanged
    {
        private PatientDataModel patientDataModel;
        public event PropertyChangedEventHandler PropertyChanged;
        public Patient Patient
        {
            get { return patientDataModel.Patient; }
            set
            {
                patientDataModel.Patient = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Patient"));
                }
            }
        }
        public PatientDataViewModel()
        {
            patientDataModel = new PatientDataModel();
        }

    }
}
