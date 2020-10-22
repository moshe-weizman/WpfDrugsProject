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
    class PhysicianShellViewModel : INotifyPropertyChanged, IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private PatientDetailsViewModel patientDetailsVM;
        private MedicalFileViewModel medicalFileVM;
        private AddMedicalRecordViewModel addMedicalRecordVM;
        private AddReceptViewModel addReceptVM;
        private PatientSearchViewModel patientSearchVM;



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
        private IViewModel medicalFileTab; 
        public IViewModel MedicalFileTab
        {
            get { return medicalFileTab; }
            set
            {
                medicalFileTab = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("MedicalFileTab"));
            }
        }
        private IViewModel addReceptTab;
        public IViewModel AddReceptTab
        {
            get { return addReceptTab; }
            set
            {
                addReceptTab = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("AddReceptTab"));
            }
        }
        private IViewModel addMedicalRecordTab;
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

        public PhysicianShellViewModel(MainWidowViewModel containingVm, string id)
        {
            patientDetailsVM = new PatientDetailsViewModel(this, id);
            medicalFileVM = new MedicalFileViewModel(this, id);
            addMedicalRecordVM = new AddMedicalRecordViewModel(this, id);
            addReceptVM = new AddReceptViewModel(this, id);
            patientSearchVM = new PatientSearchViewModel(containingVm);

            PersonalDetailsTab = patientDetailsVM;
            AddReceptTab = addReceptVM;
            AddMedicalRecordTab = addMedicalRecordVM;
            MedicalFileTab = medicalFileVM;


        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void ReplaceUC(Screen currentVM)
        {
            switch (currentVM)
            {
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

        //public void GetItem(string id)?
        //{
           
        //}
    }
    
}
