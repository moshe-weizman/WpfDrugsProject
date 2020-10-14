using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs2020.BLL
{
    public class BLImplementation : IBL
    {

        public bool ValidatePassword(IUser user, string password)
        {
            bool result = false;
            if (user.GetPassword() == password)
            {
                result = true;
            }
            return result;
        }

        public IUser IdentifyUser(string userID)
        {

            return new Physician("1234", "Mose", "Weizman", "0545678990", Sex.MALE, @"Moshe@gmail.com", "1234", "Elad", DateTime.Parse("12/10/1985"));
        }

        public Patient GetPatient(string ID)
        {
            return new Patient("12", "Dudu", "Cohen", Sex.MALE, "0501234567", "d@gmail.com", "tel aviv", DateTime.Parse("12/10/1985"));
        }

        #region Patient CRUD Functions
        public void AddPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public void UpdatePatient(string id, Patient updatedPatient)
        {
            throw new NotImplementedException();
        }

        public void DeletePatient(string id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Physician CRUD Functions
        public void AddPhysician(Physician physician)
        {
            throw new NotImplementedException();
        }

        public Patient GetPhysician(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePhysician(string id, Physician updatedPhysician)
        {
            throw new NotImplementedException();
        }

        public void DeletePhysician(string id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Drug CRUD Functions
        public void AddDrug(Drug drug)
        {
            throw new NotImplementedException();
        }

        public Patient GetDrug(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateDrug(string id, Patient updatedDrug)
        {
            throw new NotImplementedException();
        }

        public void DeleteDrug(string id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}