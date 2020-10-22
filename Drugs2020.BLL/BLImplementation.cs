using Drugs2020.BLL.BE;
using Drugs2020.DAL;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Drugs2020.BLL
{
    public class BLImplementation : IBL
    {
        IDal dal = new DalImplementation();

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
            switch (userID)
            {
                case "1234":
                    return new Admin("1234", "Mose", "Weizman", Sex.MALE, "0545678990", @"Moshe@gmail.com", "1234", "Elad", DateTime.Parse("12/10/1985"));
                case "4321":
                    return new Physician("4321", "Mose", "Weizman", Sex.MALE, "0545678990", @"Moshe@gmail.com", "4321", "Elad", DateTime.Parse("12/10/1985"));
            }
            return null;
        }
        public void AddMedicalFileToPatient(MedicalFile medicalFile)
        {

        }

        public MedicalFile GetMedicalFile(string patientID)
        {
            return null;
        }

        public void UpdateMedicalFile(string patientId, MedicalFile medicalFile)
        {
            throw new NotImplementedException();
        }

        public void AddRecept(Recept recept)
        {
            throw new NotImplementedException();
        }

        public Recept GetAllReceptOfPatient(string id)
        {
            throw new NotImplementedException();
        }





        #region Patient CRUD Functions
        public Patient GetPatient(string ID)
        {
            return new Patient("1234", "Dudu", "Cohen", Sex.MALE, "0545678990", @"Moshe@gmail.com", "Elad", DateTime.Parse("12/10/1985"));

            //return dal.GetPatient(ID);
        }
        public List<Patient> GetAllPatients()
        {
            return dal.GetAllPatients();           
        }

        public void AddPatient(Patient patient)
        {
            dal.AddPatient(patient);
        }

        public void UpdatePatient(string id, Patient updatedPatient)
        {
            dal.UpdatePatient(updatedPatient);
        }

        public void DeletePatient(string id)
        {
            dal.DeletePatient(id);
        }
        #endregion

        #region Physician CRUD Functions
        public Physician GetPhysician(string ID)
        {
            return dal.GetPhysician(ID);
        }

        public List<Physician> GetAllPhysicians()
        {
            throw new NotImplementedException();
        }

        public void AddPhysician(Physician physician)
        {
            dal.AddPhysician(physician);
        }

        public void UpdatePhysician(string id, Physician updatedPhysician)
        {
            dal.UpdatePhysician(updatedPhysician);
        }

        public void DeletePhysician(string id)
        {
            dal.DeletePhysician(id);
        }

        #endregion

        #region Drug CRUD Functions
        public Drug GetDrug(string ID)
        {
            return dal.GetDrug(ID);
        }

        public void AddDrug(Drug drug)
        {
            dal.AddDrug(drug);
        }

        public void UpdateDrug(string id, Drug updatedDrug)
        {
            dal.UpdateDrug(updatedDrug);
        }

        public void DeleteDrug(string id)
        {
            dal.DeleteDrug(id);
        }


        public List<Drug> GetAllDrugs()
        {
            return new List<Drug>
            {
                new Drug("1433", "mosheroni", "pakter", "acamoli", new List<ActiveIngredient>(), @"Drugs2020.PL\Images\icons8-pill-90.png"),
                new Drug("44444", "mosheroni", "pakter", "acamoli", new List<ActiveIngredient>(), @"Drugs2020.PL\Images\icons8-pill-90.png"),
                new Drug("88", "mosheroni", "pakter", "acamoli", new List<ActiveIngredient>(), @"Drugs2020.PL\Images\icons8-pill-90.png")
            };
        }

       
        #endregion
    }
}