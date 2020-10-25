using Drugs2020.BLL.BE;
using Drugs2020.DAL;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

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
        
        public void AddMediclRecordToPatient(MedicalRecord medicalRecord)
        {
            dal.AddMediclRecordToPatient(medicalRecord);
        }

        public void UpdateMedicalRecord(string medicalRecordID, MedicalRecord medicalRecord)
        {
            dal.UpdateMedicalRecord( medicalRecordID,  medicalRecord);
        }
        public bool MedicalRecordAlreadyExists(MedicalRecord medicalRecord)
        {
            throw new NotImplementedException();
        }




        #region Medical File Functions
        public void AddMedicalFileToPatient(MedicalFile medicalFile)
        {
            dal.AddMedicalFile(medicalFile);
        }

        public bool MedicalFileAlreadyExists(MedicalFile medicalFile)
        {
            throw new NotImplementedException();
        }

        public MedicalFile GetMedicalFile(string patientID)
        {
            return dal.GetMedicalFile(patientID); 
        }

        public void UpdateMedicalFile(string patientId, MedicalFile medicalFile)
        {
            dal.UpdateMedicalFile(patientId, medicalFile);
        }
        #endregion

        #region Recept & Drugs-Taken Functions
        public void AddRecept(Recept recept)
        {
            dal.AddRecept(recept);
        }

        public List<Recept> GetAllReceptsOfPatient(string id)
        {
             return dal.GetAllReceptsOfPatient(id);
            //return new List<Recept>() { new Recept("123", 12, "er12", "acmol", 12, 10, DateTime.Now), new Recept("123", 12, "op2", "advil", 12, 10, DateTime.Now) };
        }

        public List<Drug> GetDrugsTakenPatient(string id)//לממש את הפונקציה!!
        {
            return new List<Drug>()
           {
              new Drug("1433", "mosheroni", "pakter", "acamoli",  @"Drugs2020.PL\Images\icons8-pill-90.png"),
                new Drug("44444", "mosheroni", "pakter", "acamoli", @"Drugs2020.PL\Images\icons8-pill-90.png"),
                new Drug("88", "mosheroni", "pakter", "acamoli", @"Drugs2020.PL\Images\icons8-pill-90.png")

           };
        }

       public List<Drug> GetDrugsPreviouslyTakenPatient(string id)//לממש את הפונקציה!!
        {
            return new List<Drug>()
           {
             new Drug("88", "mosheroni", "pakter", "acamoli", @"Drugs2020.PL\Images\icons8-pill-90.png")

           };
        }
        public List<Recept> GetAllReceptsByDate(DateTime startDate, DateTime endDate)
        {
            return dal.GetAllReceptsByDate(startDate, endDate);
        }

        public List<Recept> GetAllReceptsByDrug(string drugIdCode)
        {
            return dal.GetAllReceptsByDrug(drugIdCode);
        }
        #endregion

        #region Patient CRUD Functions
        public Patient GetPatient(string ID)
        {
             return dal.GetPatient(ID);
           // return new Patient("1", "mor", "cohen", Sex.FEMALE, "0500000000", "email", "elad", DateTime.Now);
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
            return dal.GetAllPhysicians();
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
            //return new List<Drug>
            //{
            //    new Drug("1433", "mosheroni", "pakter", "acamoli", new List<ActiveIngredient>(), @"Drugs2020.PL\Images\icons8-pill-90.png"),
            //    new Drug("44444", "mosheroni", "pakter", "acamoli", new List<ActiveIngredient>(), @"Drugs2020.PL\Images\icons8-pill-90.png"),
            //    new Drug("88", "mosheroni", "pakter", "acamoli", new List<ActiveIngredient>(), @"Drugs2020.PL\Images\icons8-pill-90.png")
            //};
            return dal.GetAllDrugs();
        }
       
        
        #region ActiveIngredient CRUD Functions
        public void AddActiveIngredient(ActiveIngredient ingredient)
        {
            dal.AddActiveIngredient( ingredient);
        }

        public List<ActiveIngredient> GetActiveIngredientsOfDrug(string DrugIdCode)
        {
            return dal.GetActiveIngredientsOfDrug(DrugIdCode);
        }

        public void UpdateActiveIngredient(ActiveIngredient ingredient)
        {
            dal.UpdateActiveIngredient(ingredient);
        }

        public void DeleteActiveIngredient(ActiveIngredient ingredient)
        {
            dal.DeleteActiveIngredient(ingredient);
        }



        #endregion
    }
}