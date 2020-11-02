using Drugs2020.BLL.BE;
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
        public IUser IdentifyUser(string userID)
        {     
            IUser User= ctx.Physicians.Find(userID);
            if (User == null)
               // ctx.Admins.Add(new Admin("1234", "or", "or", Sex.MALE, "05000000", "no", "1234", "elad", DateTime.Today));
                User = ctx.Admins.Find(userID);
            return User;

        }

        #region Patient
        public void AddPatient(Patient patient)
        {
            try
            {
                ctx.Patients.Add(patient);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - AddPatient " + ex);
            }
        }
        public void DeletePatient(string id)
        {
            try
            {
                ctx.Patients.Remove(ctx.Patients.Find(id));
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - DeletePatient " + ex);
            }
        }
        public void UpdatePatient(Patient patient)
        {
            try
            {
                ctx.Patients.Remove(ctx.Patients.Find(patient.ID));
                ctx.SaveChanges();
                ctx.Patients.Add(patient);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - UpdatePatient " + ex);
            }
        }
        public Patient GetPatient(string id)
        {
            try
            {
                return ctx.Patients.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - GetPatient " + ex);
            }
        }
        public List<Patient> GetAllPatients()
        {
            try
            {
                return ctx.Patients.Where(s => s.FirstName != null).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - GetAllPatients " + ex);
            }
        }
        #endregion

        #region Physician
        public void AddPhysician(Physician physician)
        {
            try
            {
                ctx.Physicians.Add(physician);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - AddPhysician " + ex);
            }
        }
        public void DeletePhysician(string id)
        {
            try
            {

                ctx.Physicians.Remove(ctx.Physicians.Find(id));
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - DeletePhysician " + ex);
            }
        }
        public void UpdatePhysician(Physician physician)
        {
            try
            {
                ctx.Physicians.Remove(ctx.Physicians.Find(physician.ID));
                ctx.SaveChanges();
                ctx.Physicians.Add(physician);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - UpdatePhysician " + ex);
            }
        }
        public Physician GetPhysician(string id)
        {
            try
            {
                return ctx.Physicians.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - GetPhysician " + ex);
            }
        }
        public List<Physician> GetAllPhysicians()
        {
            try
            {
                return ctx.Physicians.Where(s => s.FirstName != null).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - GetAllPhysicians " + ex);
            }
        }

        #endregion

        #region Drug
        public void AddDrug(Drug drug)
        {
            try
            {
                ctx.Drugs.Add(drug);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - AddDrug " + ex);
            }
        }
        public void DeleteDrug(string id)
        {
            try
            {

                ctx.Drugs.Remove(ctx.Drugs.Find(id));
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - DeleteDrug " + ex);
            }
        }
        public void UpdateDrug(Drug drug)
        {
            try
            {
                ctx.Drugs.Remove(ctx.Drugs.Find(drug.IdCode));
                ctx.SaveChanges();
                ctx.Drugs.Add(drug);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - UpdateDrug " + ex);
            }
        }
        public Drug GetDrug(string IdCode)
        {
            try
            {
                return ctx.Drugs.Find(IdCode);
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - GetDrug " + ex);
            }
        }
        public List<Drug> GetAllDrugs()
        {
            try
            {
                return ctx.Drugs.
                 Where(s => s.IdCode != null).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - GetAllDrugs " + ex);
            }
        }
        #endregion

        #region MedicalFile  
        public void AddMedicalFile(MedicalFile medicalFile)
        {
            try
            {
                ctx.MedicalFiles.Add(medicalFile);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - AddMedicalFile " + ex);
            }
        }
        public MedicalFile GetMedicalFile(string patientID)
        {
            try
            {

                return ctx.MedicalFiles.Find(patientID);
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - GetMedicalFile " + ex);
            }
        }
        public void UpdateMedicalFile(string patientId, MedicalFile medicalFile)
        {
            try
            {
                ctx.MedicalFiles.Remove(ctx.MedicalFiles.Find(patientId));
                ctx.SaveChanges();
                ctx.MedicalFiles.Add(medicalFile);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - UpdateMedicalFile " + ex);
            }
        }
        #endregion

        #region Recept
        public void AddRecept(Recept recept)
        {
            try
            {
                ctx.Recepts.Add(recept);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - AddRecept " + ex);
            }
        }
        public List<Recept> GetAllReceptsOfPatient(string id)
        {
            try
            {
                return ctx.Recepts.Where(r => r.PatientID == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - GetAllReceptsOfPatient " + ex);
            }
        }
        public List<Recept> GetAllReceptsByDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                return ctx.Recepts.Where(r => (r.Date >= startDate) && (r.Date <= endDate)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - GetAllReceptsByDate " + ex);
            }
        }
        public List<Recept> GetAllReceptsByDrug(string drugIdCode)
        {
            try
            {
                //string name = ctx.Drugs.Find(drugIdCode).Name;
                return ctx.Recepts.Where(r => r.IdCodeOfDrug == drugIdCode).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - GetAllReceptsByDrug " + ex);
            }
        }
        #endregion

        #region MediclRecord
        public void AddMediclRecordToPatient(MedicalRecord medicalRecord)
        {
            try
            {
                ctx.MedicalRecords.Add(medicalRecord);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - AddMediclRecordToPatient " + ex);
            }
        }
        public MedicalRecord GetMedicalRecord(string medicalRecordID)
        {
            try
            {

                return ctx.MedicalRecords.Find(medicalRecordID);
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - getMedicalRecord " + ex);
            }
        }

        public void UpdateMedicalRecord(string medicalRecordID, MedicalRecord medicalRecord)
        {
            try
            {
                ctx.MedicalRecords.Remove(ctx.MedicalRecords.Find(medicalRecord.MedicalRecordID));
                ctx.SaveChanges();
                ctx.MedicalRecords.Add(medicalRecord);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - UpdateMedicalRecord " + ex);
            }
        }
        #endregion

        #region ActiveIngredient
        public void AddActiveIngredient(ActiveIngredient ingredient)
        {
            try
            {
                ctx.ActiveIngredients.Add(ingredient);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - AddActiveIngredient " + ex);
            }
        }
        public List<ActiveIngredient> GetActiveIngredientsOfDrug(string drugIdCode)
        {
            try
            {
                return ctx.ActiveIngredients.Where(r => r.DrugIdCode == drugIdCode).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - GetActiveIngredientsOfDrug " + ex);
            }
        }
        public void UpdateActiveIngredient(ActiveIngredient ingredient)
        {
            try
            {
                ctx.ActiveIngredients.Remove(ctx.ActiveIngredients.Find(ingredient));
                ctx.SaveChanges();
                ctx.ActiveIngredients.Add(ingredient);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - UpdateActiveIngredient " + ex);
            }
        }
        public void DeleteActiveIngredient(ActiveIngredient ingredient)
        {
            try
            {
                ctx.ActiveIngredients.Remove(ctx.ActiveIngredients.Find(ingredient.ID));
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - DeleteActiveIngredient " + ex);
            }
        }
        public List<MedicalRecord> GetAllMedicalRecordsOfPatient(string patientId)
        {
            try
            {
                return ctx.MedicalRecords.Where(s => s.PatientID == patientId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - GetAllMedicalRecordsOfPatient " + ex);
            }
        }

       
        #endregion
    }
}
