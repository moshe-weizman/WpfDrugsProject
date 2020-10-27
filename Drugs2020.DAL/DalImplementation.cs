﻿using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace Drugs2020.DAL
{
    public class DalImplementation : IDal
    {
        private PharmacyContext ctx = new PharmacyContext();

        #region Patient
        public void AddPatient(Patient patient)
        {
            ctx.Patients.Add(patient);
            ctx.SaveChanges();
        }
        public void DeletePatient(string id)
        {
            ctx.Patients.Remove(ctx.Patients.Find(id));
            ctx.SaveChanges();
        }
        public void UpdatePatient(Patient patient)
        {
            ctx.Patients.Remove(ctx.Patients.Find(patient.ID));
            ctx.SaveChanges();
            ctx.Patients.Add(patient);
            ctx.SaveChanges();
        }
        public Patient GetPatient(string id)
        {
            return ctx.Patients.Find(id);
        }
        public List<Patient> GetAllPatients()
        {
            return ctx.Patients.Where(s => s.FirstName != null).ToList();
        }
        #endregion

        #region Physician
        public void AddPhysician(Physician physician)
        {
            ctx.Physicians.Add(physician);
            ctx.SaveChanges();
        }
        public void DeletePhysician(string id)
        {
            ctx.Physicians.Remove(ctx.Physicians.Find(id));
            ctx.SaveChanges();
        }
        public void UpdatePhysician(Physician physician)
        {
            ctx.Physicians.Remove(ctx.Physicians.Find(physician.ID));
            ctx.SaveChanges();
            ctx.Physicians.Add(physician);
            ctx.SaveChanges();
        }
        public Physician GetPhysician(string id)
        {
            return ctx.Physicians.Find(id);
        }
        public List<Physician> GetAllPhysicians() { return ctx.Physicians.Where(s => s.FirstName != null).ToList(); }

        #endregion

        #region Drug
        public void AddDrug(Drug drug)
        {
            ctx.Drugs.Add(drug);
            ctx.SaveChanges();
        }
        public void DeleteDrug(string id)
        {
            ctx.Drugs.Remove(ctx.Drugs.Find(id));
            ctx.SaveChanges();
        }
        public void UpdateDrug(Drug drug)
        {
            ctx.Drugs.Remove(ctx.Drugs.Find(drug.IdCode));
            ctx.SaveChanges();
            ctx.Drugs.Add(drug);
            ctx.SaveChanges();
        }
        public Drug GetDrug(string IdCode)
        {
            return ctx.Drugs.Find(IdCode);
        }
        public List<Drug> GetAllDrugs()
        {
            return ctx.Drugs.
                 Where(s => s.IdCode != null).ToList();
        }
        #endregion

        #region MedicalFile  
        public void AddMedicalFile(MedicalFile medicalFile)
        {
            ctx.MedicalFiles.Add(medicalFile);
            ctx.SaveChanges();
        }
        public MedicalFile GetMedicalFile(string patientID)
        {
            return ctx.MedicalFiles.Find(patientID);
        }
        public void UpdateMedicalFile(string patientId, MedicalFile medicalFile)
        {
            ctx.MedicalFiles.Remove(ctx.MedicalFiles.Find(patientId));
            ctx.SaveChanges();
            ctx.MedicalFiles.Add(medicalFile);
            ctx.SaveChanges();
        }
        #endregion

        #region Recept
        public void AddRecept(Recept recept)
        {
            ctx.Recepts.Add(recept);
            ctx.SaveChanges();
        }
        public List<Recept> GetAllReceptsOfPatient(string id)
        {
            return ctx.Recepts.Where(r => r.PatientID == id).ToList();
        }
        public List<Recept> GetAllReceptsByDate(DateTime startDate, DateTime endDate)
        {
            return ctx.Recepts.Where(r => (r.Date >= startDate) && (r.Date <= endDate)).ToList();
        }
        public List<Recept> GetAllReceptsByDrug(string drugIdCode)
        {
            //string name = ctx.Drugs.Find(drugIdCode).Name;
            return ctx.Recepts.Where(r => r.IdCodeOfDrug == drugIdCode).ToList();
        }
        #endregion

        #region MediclRecord
        public void AddMediclRecordToPatient(MedicalRecord medicalRecord)
        {
            ctx.MedicalRecords.Add(medicalRecord);
            ctx.SaveChanges();
        }
        public void UpdateMedicalRecord(string medicalRecordID, MedicalRecord medicalRecord)
        {
            ctx.MedicalRecords.Remove(ctx.MedicalRecords.Find(medicalRecord.MedicalRecordID));
            ctx.SaveChanges();
            ctx.MedicalRecords.Add(medicalRecord);
            ctx.SaveChanges();
        }
        #endregion

        #region ActiveIngredient
        public void AddActiveIngredient(ActiveIngredient ingredient)
        {
            ctx.ActiveIngredients.Add(ingredient);
            ctx.SaveChanges();
        }
        public List<ActiveIngredient> GetActiveIngredientsOfDrug(string drugIdCode)
        {
            return ctx.ActiveIngredients.Where(r => r.DrugIdCode == drugIdCode).ToList();
        }
        public void UpdateActiveIngredient(ActiveIngredient ingredient)
        {
            ctx.ActiveIngredients.Remove(ctx.ActiveIngredients.Find(ingredient));
            ctx.SaveChanges();
            ctx.ActiveIngredients.Add(ingredient);
            ctx.SaveChanges();
        }
        public void DeleteActiveIngredient(ActiveIngredient ingredient)
        {
            ctx.ActiveIngredients.Remove(ctx.ActiveIngredients.Find(ingredient.ID));
            ctx.SaveChanges();
        }

        public List<MedicalRecord> GetAllMedicalRecordsOfPatient(string patientId)
        {
            return ctx.MedicalRecords.Where(s => s.PatientID == patientId).ToList();
        }
        #endregion
    }

}
