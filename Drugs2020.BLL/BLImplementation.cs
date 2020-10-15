using Drugs2020.BLL.BE;
using Drugs2020.DAL;
using System;

namespace Drugs2020.BLL
{
    public class BLImplementation : IBL
    {
        Program program;
       
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

        #region Patient CRUD Functions
        public Patient GetPatient(string ID)
        {
            return program.GetPatient(ID);
        }

        public void AddPatient(Patient patient)
        {
            program.SavePatient(patient);
        }

        public void UpdatePatient(string id, Patient updatedPatient)
        {
            program.UpdataPatient(updatedPatient);
        }

        public void DeletePatient(string id)
        {
            program.DeletePatient(id);
        }
        #endregion

        #region Physician CRUD Functions
        public Physician GetPhysician(string ID)
        {
            return program.GetPhysician(ID);
        }

        public void AddPhysician(Physician physician)
        {
            program.SavePhysician(physician);
        }

        public void UpdatePhysician(string id, Physician updatedPhysician)
        {
            program.UpdataPhysician(updatedPhysician);
        }

        public void DeletePhysician(string id)
        {
            program.DeletePhysician(id);
        }

        #endregion

        #region Drug CRUD Functions
        public Drug GetDrug(string ID)
        {
            return program.GetDrug(ID);
        }

        public void AddDrug(Drug drug)
        {
            program.SaveDrug(drug);
        }

        public void UpdateDrug(string id, Drug updatedDrug)
        {
            program.UpdataDrug(updatedDrug);
        }

        public void DeleteDrug(string id)
        {
            program.DeleteDrug(id);
        }
        #endregion
    }
}