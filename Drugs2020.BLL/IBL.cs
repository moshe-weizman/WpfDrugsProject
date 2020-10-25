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
        List<Drug> GetDrugsTakenPatient(string id);

        List<Drug> GetDrugsPreviouslyTakenPatient(string id);
        IUser IdentifyUser(string userID);

        void AddMedicalFileToPatient(MedicalFile medicalFile);
        void UpdateMedicalFile(string patientId, MedicalFile medicalFile);
        void AddRecept(Recept recept);
        void AddMediclRecordToPatient(MedicalRecord medicalRecord);
        List<MedicalRecord> GetAllMedicalRecordsOfPatient(string patientId);
        List<Recept> GetAllReceptsOfPatient(string id);
        bool MedicalRecordAlreadyExists(MedicalRecord medicalRecord);
        void CreatePDF(Recept recept);
        List<Recept> GetAllReceptsByDate(DateTime startDate, DateTime endDate);
        List<Recept> GetAllReceptsByDrug(string drugIdCode);
        bool MedicalFileAlreadyExists(MedicalFile medicalFile);
        void UpdateMedicalRecord(string medicalRecordID, MedicalRecord medicalRecord);
        MedicalFile GetMedicalFile(string patientID);
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

        #region Drug CRUD Functions
        void AddDrug(Drug drug);
        Drug GetDrug(string id);
        List<Drug> GetAllDrugs();
        void UpdateDrug(string id, Drug updatedDrug);
        void DeleteDrug(string id);
        #endregion
    }
}