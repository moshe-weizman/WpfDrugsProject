using Drugs2020.BLL.BE;
using Drugs2020.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Drugs2020.BLL
{
    public class BLImplementation : IBL
    {
        IDal dal = new DalImplementation();
        IPDF PDF = new SaveAsPDF();
        public Dictionary<string, int> GetDictionaryForReceptsByDate(DateTime startDate, DateTime endDate)
        {
            List<Recept> recepts = GetAllReceptsByDate(startDate, endDate);
            Dictionary<string, int> result = recepts
                .GroupBy(x => x.DrugGenericName)
                .ToDictionary(group => group.Key,
                group => group.Count());
            return result;
        }
        public Dictionary<string, int> GetDictionaryForReceptsByDrug(string chosenDrug)
        {
            List<Recept> recepts = GetAllReceptsByDrug(chosenDrug);
            Dictionary<string, int> result = recepts
                .GroupBy(x => x.Date.ToShortDateString())
                .ToDictionary(group => group.Key,
                group => group.Count());
            return result;
        }


        #region Login
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

        #endregion

        #region Medical Record
        public void AddMediclRecordToPatient(MedicalRecord medicalRecord)
        {
            dal.AddMediclRecordToPatient(medicalRecord);
        }

        public void UpdateMedicalRecord(string medicalRecordID, MedicalRecord medicalRecord)
        {
            dal.UpdateMedicalRecord(medicalRecordID, medicalRecord);
        }
        public bool MedicalRecordAlreadyExists(MedicalRecord medicalRecord)//לכאורה צריך לא לממש אותה
        {
            return false;
        }
        #endregion

        #region Medical File Functions
        public void AddMedicalFileToPatient(MedicalFile medicalFile)
        {
            dal.AddMedicalFile(medicalFile);
        }

        public bool MedicalFileAlreadyExists(MedicalFile medicalFile)
        {
            if (dal.GetMedicalFile(medicalFile.PatientId) == null)
                return false;
            return true;
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

        public string checkConflicts(string IdCodeOfDrug, List<string> drugsTakenPatient)
        {
            DrugConflictTest drugConflictTest = new DrugConflictTest();
            string result = drugConflictTest.ConflictTest(IdCodeOfDrug, drugsTakenPatient);
            return result;
        }

        public List<Recept> GetAllReceptsOfPatient(string id)
        {
             return dal.GetAllReceptsOfPatient(id);
            //return new List<Recept>() { new Recept("123", 12, "er12", "acmol", 12, 10, DateTime.Now), new Recept("123", 12, "op2", "advil", 12, 10, DateTime.Now) };
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
            return dal.GetAllDrugs();
        }
        #endregion

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

        public List<MedicalRecord> GetAllMedicalRecordsOfPatient(string patientId)
        {
            return dal.GetAllMedicalRecordsOfPatient(patientId);
        }

        public void CreatePDF(Recept recept)
        {
            PDF.SavaPDF(recept.ToString());
        }
        #endregion

        #region Utility
        private int CalcAge(DateTime birth)
        {
            return 770;
        }
        #endregion
    }
}