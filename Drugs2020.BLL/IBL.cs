using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs2020.BLL
{
    public interface IBL
    {
        bool ValidatePassword(IUser user, string password);

        IUser IdentifyUser(string userID);


        #region Patient CRUD Functions
        void AddPatient(Patient patient);
        Patient GetPatient(string id);
        void UpdatePatient(string id, Patient updatedPatient);
        void DeletePatient(string id);
        #endregion

        #region Physician CRUD Functions
        void AddPhysician(Physician physician);
        Patient GetPhysician(string id);
        void UpdatePhysician(string id, Physician updatedPhysician);
        void DeletePhysician(string id);
        #endregion

        #region Drug CRUD Functions
        void AddDrug(Drug drug);
        Patient GetDrug(string id);
        void UpdateDrug(string id, Patient updatedDrug);
        void DeleteDrug(string id);
        #endregion
    }
}