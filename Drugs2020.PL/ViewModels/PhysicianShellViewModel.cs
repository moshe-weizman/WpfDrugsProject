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
    class PhysicianShellViewModel : INotifyPropertyChanged, IViewModel, ISearch
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private PatientSearchViewModel patientSearchVM;
        private PatientDetailsViewModel patientDetailsVM;
        private MedicalFileViewModel medicalFileVM;
        private AddMedicalRecordViewModel addMedicalRecordVM;
        private AddReceptViewModel addReceptVM;
        private PhysicianShellModel physicianShellM;

        
        public Patient CurrentPatient
        {
            get
            {
                return physicianShellM.CurrentPatient;
            }
            set
            {
                physicianShellM.CurrentPatient = value;
            }
        }
        public MedicalFile MedicalFile
        {
            get
            {
                return physicianShellM.MedicalFile;
            }
            set
            {
                physicianShellM.MedicalFile = value;
            }
        }
        private IViewModel personalDetailsTab { get; set; }
        public IViewModel PersonalDetailsTab
        {
            get { return personalDetailsTab; }
            set
            {
                personalDetailsTab = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("PersonalDetailsTab"));
            }
        }
        private IViewModel medicalFileTab { get; set; }
        public IViewModel MedicalFileTab
        {
            get { return medicalFileTab; }
            set
            {
                personalDetailsTab = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("MedicalFileTab"));
            }
        }
        private IViewModel addReceptTab { get; set; }
        public IViewModel AddReceptTab
        {
            get { return addReceptTab; }
            set
            {
                personalDetailsTab = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("AddReceptTab"));
            }
        }
        private IViewModel addMedicalRecordTab { get; set; }
        public IViewModel AddMedicalRecordTab
        {
            get { return addMedicalRecordTab; }
            set
            {
                personalDetailsTab = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("AddMedicalRecordTab"));
            }
        }
        public Patient currentPatient
        {
            get { return physicianShellM.CurrentPatient; }
            set { physicianShellM.CurrentPatient = value; }
        }

        public PhysicianShellViewModel()
        {
            currentPatient = new Patient();
            physicianShellM = new PhysicianShellModel(currentPatient);
            //patientSearchVM = new PatientSearchViewModel(this, physicianShellM);
            patientDetailsVM = new PatientDetailsViewModel(this);
            medicalFileVM = new MedicalFileViewModel(this, currentPatient);
            //addMedicalRecordVM = new AddMedicalRecordViewModel(this, physicianShellM);
            //addReceptVM = new AddReceptViewModel(this, physicianShellM);

        }

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void ReplaceUC(Screen currentVM)
        {
            switch (currentVM)
            {
                case Screen.LOGIN_SCREEN:
                    break;
                case Screen.SEARCH_PATIENT_SCREEN:
                    break;
                case Screen.ADD_PATIENT_SCREEN:
                    break;
                case Screen.ACTIONS_MENU:
                    break;
                case Screen.ADD_MEDICAL_FILE:
                    break;
                case Screen.ADD_MEDICAL_RECORD:
                    break;
                case Screen.ADD_RECEPT:
                    break;
                default: break;
            }
        }

        public void GetItem(string id)
        {
           
        }
    }
    
}
