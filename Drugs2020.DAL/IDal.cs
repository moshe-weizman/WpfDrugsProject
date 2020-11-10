
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;

namespace Drugs2020.DAL
{
    public interface IDal
    {
        IUser IdentifyUser(string userID);

        #region Patient CRUD Functions
        bool DoesPatientExist(string id);
        void AddPatient(Patient patient);
        Patient GetPatient(string id);
        void UpdatePatient(Patient patient);
        void DeletePatient(string id);
        List<Patient> GetAllPatients();
        #endregion

        #region Physician CRUD Functions
        bool DoesPhysicianExist(string id);
        void AddPhysician(Physician physician);
        Physician GetPhysician(string id);
        void UpdatePhysician(Physician physician);
        void DeletePhysician(string id);
        List<Physician> GetAllPhysicians();
        #endregion

        #region Drug CRUD Functions
        bool DoesDrugExist(string IdCode);
        void AddDrug(Drug drug);
        Drug GetDrug(string IdCode);
        void UpdateDrug(Drug drug);
        void DeleteDrug(string id);
        List<Drug> GetAllDrugs();
        #endregion

        #region MedicalFile
        bool DoesMedicalFileExist(string id);
        void AddMedicalFile(MedicalFile medicalFile);
        MedicalFile GetMedicalFile(string patientID);
        void UpdateMedicalFile(string patientId, MedicalFile medicalFile);
        #endregion

        #region Recept
        void AddRecept(Recept recept);
        void DeleteReceipt(string ReceptId);
        List<Recept> GetAllReceptsOfPatient(string id);
        List<Recept> GetAllReceptsByDate(DateTime startDate, DateTime endDate);
        List<Recept> GetAllReceptsByDrug(string drugIdCode);
        List<MedicalRecord> GetAllMedicalRecordsOfPatient(string patientId);

        #endregion

        #region MediclRecord
        bool DoesMediclRecordExist(string id);

        void AddMediclRecordToPatient(MedicalRecord medicalRecord);
        MedicalRecord GetMedicalRecord(string medicalRecordID);
        void UpdateMedicalRecord(string medicalRecordID, MedicalRecord medicalRecord);
        #endregion

        #region ActiveIngredient
        void AddActiveIngredient(ActiveIngredient ingredient);
        List<ActiveIngredient> GetActiveIngredientsOfDrug(string drugIdCode);
        void UpdateActiveIngredient(ActiveIngredient ingredient);
        void DeleteActiveIngredient(ActiveIngredient ingredient);
        #endregion
    }
}

