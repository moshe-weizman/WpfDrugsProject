﻿using Drugs2020.BLL.BE;
using Drugs2020.PL.Models;
using Drugs2020.PL.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class MainWidowViewModel : INotifyPropertyChanged, IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IViewModel _LeftCurrentVm;
        private IViewModel _RightCurrentVm;

        private LogInViewModel logInVM;
        private PatientSearchViewModel patientSearchVM;
        private AddPatientViewModel addPatientVM;
        private ActionsMenuViewModel actionsMenuVM;
        private PatientDetailsViewModel patientDataVM;
        private MedicalFileViewModel addMedicalFileVM;
        private AddMedicalRecordViewModel AddMedicalRecordVM;
        private AddReceptViewModel addReceptVM;
        private AdminShellViewModel adminShellVM;
       

        private PhysicianShellModel patientModel;
        public MainWidowViewModel()
        {
            
            MainWindowM = new MainWindowModel();
            logInVM = new LogInViewModel(this);
            patientSearchVM = new PatientSearchViewModel(this, patientModel);
            //addPatientVM = new AddPatientViewModel(this);
            actionsMenuVM = new ActionsMenuViewModel(this);
            //patientDataVM = new PatientDetailsViewModel(this, patientModel);
            //addMedicalFileVM = new MedicalFileViewModel(this, patientModel);
            AddMedicalRecordVM = new AddMedicalRecordViewModel(this, patientModel);
            addReceptVM = new AddReceptViewModel(this, patientModel);
            adminShellVM = new AdminShellViewModel();
            LeftCurrentVm = logInVM;
        }
        public MainWindowModel MainWindowM { get; set; }
        public IViewModel RightCurrentVm 
        {
            get { return _RightCurrentVm; }
            set { _RightCurrentVm = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("RightCurrentVm"));
            }
        }

        public IViewModel LeftCurrentVm
        {
            get { return _LeftCurrentVm; }
            set 
            { 
                _LeftCurrentVm = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("LeftCurrentVm"));
            }
        }

        public void ReplaceUC(Screen currentVM)
        {
            switch (currentVM)
            {
                case Screen.LOGIN_SCREEN:
                    LeftCurrentVm = logInVM;
                    break;
                case Screen.SEARCH_PATIENT_SCREEN:
                    LeftCurrentVm = patientSearchVM;
                    RightCurrentVm = null;
                    break;
                case Screen.ADD_PATIENT_SCREEN:
                     LeftCurrentVm = addPatientVM;
                    break;
                case Screen.ACTIONS_MENU:
                    LeftCurrentVm = actionsMenuVM;
                    break;
                case Screen.ADD_MEDICAL_FILE:
                    LeftCurrentVm = addMedicalFileVM;
                    RightCurrentVm = patientDataVM;
                    break;
                case Screen.ADD_MEDICAL_RECORD:
                    LeftCurrentVm = AddMedicalRecordVM;
                    RightCurrentVm = patientDataVM;
                    break;
                case Screen.ADD_RECEPT:
                    LeftCurrentVm = addReceptVM;
                    break;
                default: break;
            }
        }
    }
}