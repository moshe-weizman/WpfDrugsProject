using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class AddPatientViewModel : IAddToDb , IGoBackScreenVM, IViewModel
    {
        private AddPatientModel AddPatientM;

        private MainWindowViewModel containingVm;
        public AddToDbCommand AddToDbCommand { get; set; }

        public BackCommand BackCommand { get; set; }
        public Patient Patient
        {
            get { return AddPatientM.Patient; }
            set { AddPatientM.Patient = value; }
        }
        public Array SexEnumValues => Enum.GetValues(typeof(Sex));

        public AddPatientViewModel(MainWindowViewModel containingVm)
        {
            AddPatientM = new AddPatientModel();
            this.containingVm = containingVm;
            AddToDbCommand = new AddToDbCommand(this);
            BackCommand = new BackCommand(this);
            Patient = new Patient();
        }

        


        //public string ID
        //{
            //get { return AddPatientM.Patient.ID; }
            //set { AddPatientM.Patient.ID = value; }
        //}

        //public string FName
        //{
            //get { return AddPatientM.Patient.FirstName; }
            //set { AddPatientM.Patient.FirstName = value; }
        //}

        //public string LName
        //{
            //get { return AddPatientM.Patient.LastName; }
            //set { AddPatientM.Patient.LastName = value; }
        //}

        //public string Phone
        //{
            //get { return AddPatientM.Patient.Phone; }
            //set { AddPatientM.Patient.Phone = value; }
        //}

        //public string Email
        //{
            //get { return AddPatientM.Patient.Email; }
            //set { AddPatientM.Patient.Email = value; }
        //}

        //public string Address
        //{
            //get { return AddPatientM.Patient.Address; }
            //set { AddPatientM.Patient.Address = value; }
        //}

        //public DateTime BirthDate
        //{
            //get { return AddPatientM.Patient.BirthDate; }
            //set { AddPatientM.Patient.BirthDate = value; }
        //}

        //public Sex SexOfPatient
        //{
            //get { return AddPatientM.Patient.Sex; }
            //set { AddPatientM.Patient.Sex = value; }
        //}

        public void AddItemToDb()
        {
            AddPatientM.AddPatientToDb();
        }

        public bool ItemAlreadyExists()
        {
            Patient patient = Patient;
            return false;
        }

        public void UpdateExistingItem()
        {
            throw new NotImplementedException();
        }

        public bool UserWantsToReplaceExistingItem()
        {
            throw new NotImplementedException();
        }

        public void GoBack()
        {
            containingVm.ReplaceLeftUC(Screen.ACTIONS_MENU);
        }
    }//
}
