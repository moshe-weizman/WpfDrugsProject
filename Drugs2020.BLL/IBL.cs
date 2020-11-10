using Drugs2020.BLL.BE;
using Drugs2020.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs2020.BLL
{
    public interface IBL
    {
        bool ValidatePassword(IUser user, string password);      
        IUser IdentifyUser(string userID);

        #region Recept
        void AddRecept(Recept recept);
        List<string> checkConflicts(string IdCodeOfDrug, List<string> drugsTakenPatient);
        Dictionary<string, int> GetDictionaryForReceptsByDate(DateTime dateTime, DateTime date);
        List<Recept> GetAllReceptsOfPatient(string id);
        List<Recept> GetAllReceptsByDate(DateTime startDate, DateTime endDate);
        List<Recept> GetAllReceptsByDrug(string drugIdCode);
        void DeleteReceipt(Recept receipt);
        Dictionary<string, int> GetDictionaryForReceptsByDrug(string chosenDrug);
        void CreatePDF(Recept recept);
        #endregion

        #region MedicalFile
        bool DoesMedicalFileExist(string id);
        void AddMedicalFileToPatient(MedicalFile medicalFile);
        void UpdateMedicalFile(string patientId, MedicalFile medicalFile);
        MedicalFile GetMedicalFile(string patientID);
        bool MedicalFileAlreadyExists(MedicalFile medicalFile);
        List<MedicalRecord> GetAllMedicalRecordsOfPatient(string patientId);
        #endregion

        #region MedicalRecord
        bool DoesMediclRecordExist(string id);
        void AddMediclRecordToPatient(MedicalRecord medicalRecord);
        bool MedicalRecordAlreadyExists(MedicalRecord medicalRecord);
        MedicalRecord GetMedicalRecord(string medicalRecordID);
        void UpdateMedicalRecord(string medicalRecordID, MedicalRecord medicalRecord);
        #endregion

        #region Patient CRUD Functions
        bool DoesPatientExist(string id);

        void AddPatient(Patient patient);
        Patient GetPatient(string id);
        List<Patient> GetAllPatients();
        void UpdatePatient(string id, Patient updatedPatient);
        void DeletePatient(string id);
        #endregion

        #region Physician CRUD Functions
        bool DoesPhysicianExist(string id);
        void AddPhysician(Physician physician);
        Physician GetPhysician(string id);
        List<Physician> GetAllPhysicians();
        void UpdatePhysician(string id, Physician updatedPhysician);
        void DeletePhysician(string id);
        #endregion

        #region Drug
        bool DoesDrugExist(string IdCode);
        
            void AddDrug(Drug drug);
        Drug GetDrug(string id);
        List<Drug> GetAllDrugs();
      
        void UpdateDrug(string id, Drug updatedDrug);
        void DeleteDrug(string id);
        #endregion

        #region ActiveIngredient
        void AddActiveIngredient(ActiveIngredient ingredient);
        List<ActiveIngredient> GetActiveIngredientsOfDrug(string DrugIdCode);
        void UpdateActiveIngredient(ActiveIngredient ingredient);
        void DeleteActiveIngredient(ActiveIngredient ingredient);
        #endregion
    }
}