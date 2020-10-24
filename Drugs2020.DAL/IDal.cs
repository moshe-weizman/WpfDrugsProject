using Drugs2020.BLL.BE;
using System.Collections.Generic;

namespace Drugs2020.DAL
{
    public interface IDal
    {                                                                                       
        #region Patient CRUD Functions
        void AddPatient(Patient patient);
        Patient GetPatient(string id);
        void UpdatePatient(Patient patient);
        void DeletePatient(string id);
        List<Patient> GetAllPatients(); 
        #endregion

        #region Physician CRUD Functions
        void AddPhysician(Physician physician);
        Physician GetPhysician(string id);
        void UpdatePhysician(Physician physician);
        void DeletePhysician(string id);
        List<Physician> GetAllPhysicians();
        #endregion

        #region Drug CRUD Functions
        void AddDrug(Drug drug);
        Drug GetDrug(string IdCode);
        void UpdateDrug(Drug drug);
        void DeleteDrug(string id);
        List<Drug> GetAllDrugs();
        void AddMedicalFile(MedicalFile medicalFile);
        MedicalFile GetMedicalFile(string patientID);
        void UpdateMedicalFile(string patientId, MedicalFile medicalFile);
        void AddRecept(Recept recept);
        List<Recept> GetAllReceptsOfPatient(string id);
        #endregion
    }
}