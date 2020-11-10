using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Drugs2020.DAL
{
    public class DalImplementation : IDal
    {
        private ICloudForImage cloud = new GoogleDrive();
        private PharmacyContext ctx = new PharmacyContext();
        const string IMAGES_FILES_EXTENSION = @".png";
        const string PDF_FILES_EXTENSION = @".pdf";
        string receptsStoragePath = Path.GetFullPath(@"..\ApplicationResources\ReceptsPDF");
        string imagesStoragePath = Path.GetFullPath(@"..\ApplicationResources\DrugsImages");
        string defaultImagePath = Path.GetFullPath(@"..\ApplicationResources\DrugsImages\default.png");
        
        public IUser IdentifyUser(string userID)
        {
            try
            {
                IUser User = ctx.Physicians.Find(userID);
                if (User == null)
                    User = ctx.Admins.Find(userID);
                if (User == null)
                    throw new KeyNotFoundException("User Not Found");
                return User;
            }
            catch (KeyNotFoundException ex) { throw; }

        }
        public void SyncWithCloud()
        {
            GetAllDrugs().ForEach(drug =>
            {
                drug.ImageUrl = getImageForDrug(drug);
                UpdateDrug(drug);
            });
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
                throw new Exception("Error adding Patient");
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
                throw new Exception("Error Deleteing Patient");
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
                throw new Exception("Error Updating Patient");
            }
        }
        public Patient GetPatient(string id)
        {
            try
            {
                Patient patient= ctx.Patients.Find(id);
                if(patient==null)
                    throw new KeyNotFoundException(id+"of Patient not found");
                return patient;
            }
            catch (KeyNotFoundException e) { throw; }
            catch (Exception e)
            {
                throw new Exception("Error to Get patient");
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
                throw new Exception("Error to Get List of patient");
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
                throw new Exception("Error adding Patient");
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
                throw new Exception("Error Delteing physician");
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
                throw new Exception("Error Updating physician");
            }
        }
        public Physician GetPhysician(string id)
        {
            try
            {
                Physician physician= ctx.Physicians.Find(id);
                if (physician == null)
                    throw new KeyNotFoundException(id+"of Physician not found");
                return physician;
            }
            catch(KeyNotFoundException e) { throw; }
            catch (Exception ex)
            {
                throw new Exception("Error to Get Physician");
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
                throw new Exception("Error to Get List of Physicians");
            }
        }

        #endregion

        #region Drug
        public void AddDrug(Drug drug)
        {
            try
            {
                if (File.Exists(drug.ImageUrl))
                {
                    drug.ImageUrl = SaveImage(drug);
                }
                else
                {
                    drug.ImageUrl = defaultImagePath;
                }
                ctx.Drugs.Add(drug);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding drug");
            }
        }
        private string SaveImage(Drug drug)
        {
            string drugImageName = drug.IdCode + IMAGES_FILES_EXTENSION;
            drug.ImageUrl = SaveFileLocally(drug.ImageUrl, imagesStoragePath, drugImageName);
            while (cloud.DoesFileExists(drugImageName))
            {
                cloud.Remove(drugImageName);
            }
            cloud.Upload(drug.ImageUrl);
            return drug.ImageUrl;
        }
        private string SaveFileLocally(string filePath, string targetDirectory, string targetFileName)
        {
            Directory.CreateDirectory(targetDirectory);
            string destinaion = Path.Combine(targetDirectory, targetFileName);
            File.Copy(filePath, destinaion, true);
            return destinaion;
        }
        private string getImageForDrug(Drug drug)
        {
            //Drug image exists locally
            if (File.Exists(drug.ImageUrl))
            {
                return drug.ImageUrl;
            }
            //Drug image exists locally
            if (cloud.DoesFileExists(drug.IdCode + IMAGES_FILES_EXTENSION))
            {
                cloud.Download(drug.IdCode + IMAGES_FILES_EXTENSION, imagesStoragePath);
                string path = Path.Combine(imagesStoragePath, drug.IdCode + IMAGES_FILES_EXTENSION);
                return path;
            }
            return defaultImagePath;
        }
        public void DeleteDrug(string id)
        {
            try
            {
                if (cloud.DoesFileExists(id + IMAGES_FILES_EXTENSION))
                {
                    cloud.Remove(id + IMAGES_FILES_EXTENSION);
                }
                ctx.Drugs.Remove(ctx.Drugs.Find(id));
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Deleteing Drug");
            }
        }
        public void UpdateDrug(Drug drug)
        {
            try
            {
                DeleteDrug(drug.IdCode);
                AddDrug(drug);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Updateing Drug ");
            }
        }
        public Drug GetDrug(string IdCode)
        {
            try
            {
                Drug drug = ctx.Drugs.Find(IdCode);
                return drug;
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
                List<Drug> drugs =  ctx.Drugs.
                 Where(s => s.IdCode != null).ToList();
                return drugs;
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
        public void DeleteReceipt(string ReceptId)
        {
            try
            {

                ctx.Recepts.Remove(ctx.Recepts.Find(ReceptId));
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DalImplementation - DeleteReceipt " + ex);
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
