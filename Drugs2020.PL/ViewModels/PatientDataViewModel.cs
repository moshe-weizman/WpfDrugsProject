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
        

        public PatientDataViewModel()
        {
            patientDataModel = new PatientDataModel();
        }

        public string ID
        {
            get { return patientDataModel.Patient.ID; }
            set { patientDataModel.Patient.ID = value; }
        }

        public string FName
        {
            get { return patientDataModel.Patient.FirstName; }
            set { patientDataModel.Patient.FirstName = value; }
        }

        public string LName
        {
            get { return patientDataModel.Patient.LastName; }
            set { patientDataModel.Patient.LastName = value; }
        }

        public string Phone
        {
            get { return patientDataModel.Patient.Phone; }
            set { patientDataModel.Patient.Phone = value; }
        }

        public string Email
        {
            get { return patientDataModel.Patient.Email; }
            set { patientDataModel.Patient.Email = value; }
        }

        public string Address
        {
            get { return patientDataModel.Patient.Address; }
            set { patientDataModel.Patient.Address = value; }
        }

        public DateTime BirthDate
        {
            get { return patientDataModel.Patient.BirthDate; }
            set { patientDataModel.Patient.BirthDate = value; }
        }

        public Sex SexOfPatient
        {
            get { return patientDataModel.Patient.Sex; }
            set { patientDataModel.Patient.Sex = value; }
        }


    }
}
