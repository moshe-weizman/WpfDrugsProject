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
        void AddRecept(Recept recept, List<string> drugsTakenPatient);
        List<Recept> GetAllReceptsOfPatient(string id);
        List<Recept> GetAllReceptsByDate(DateTime startDate, DateTime endDate);
        List<Recept> GetAllReceptsByDrug(string drugIdCode);
        void CreatePDF(Recept recept);
        #endregion

        #region MedicalFile
        void AddMedicalFileToPatient(MedicalFile medicalFile);
        void UpdateMedicalFile(string patientId, MedicalFile medicalFile);
        MedicalFile GetMedicalFile(string patientID);
        bool MedicalFileAlreadyExists(MedicalFile medicalFile);
        List<MedicalRecord> GetAllMedicalRecordsOfPatient(string patientId);
        #endregion

        #region MedicalRecord
        bool MedicalRecordAlreadyExists(MedicalRecord medicalRecord);
        void UpdateMedicalRecord(string medicalRecordID, MedicalRecord medicalRecord);
        #endregion
        
        #region Patient CRUD Functions
        void AddPatient(Patient patient);
        Patient GetPatient(string id);
        List<Patient> GetAllPatients();
        void UpdatePatient(string id, Patient updatedPatient);
        void DeletePatient(string id);
        #endregion

        #region Physician CRUD Functions
        void AddPhysician(Physician physician);
        Physician GetPhysician(string id);
        List<Physician> GetAllPhysicians();
        void UpdatePhysician(string id, Physician updatedPhysician);
        void DeletePhysician(string id);
        #endregion

        #region Drug
        void AddDrug(Drug drug);
        Drug GetDrug(string id);
        List<Drug> GetAllDrugs();
        List<Drug> GetDrugsTakenPatient(string id);
        List<Drug> GetDrugsPreviouslyTakenPatient(string id);
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