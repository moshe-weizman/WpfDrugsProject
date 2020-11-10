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
        public DalImplementation()
        {
            //initDatabaseSamples();
        }
        private void initDatabaseSamples()
        {
            string imagesSamplesSourcePath = Path.GetFullPath(@"..\Drugs2020.PL\Images\");
            AddPatient(new Patient() { FirstName = "Roni", LastName = "Packter", Address = "Yehoodah Hanassi 118, Elad", BirthDate = DateTime.Parse("22/4/1990"), Email = "ronipakter@gmail.com", ID = "123456789", Phone = "0547488565", Sex = Sex.MALE});
            AddPatient(new Patient() { FirstName = "Moshe", LastName = "Weizman", Address = "Shmaya 8, Elad", BirthDate = DateTime.Parse("17/3/1960"), Email = "mosheweizman@gmail.com", ID = "987654321", Phone = "0547488565", Sex = Sex.MALE });
            AddPatient(new Patient() { FirstName = "Ishayaho", LastName = "Pewzner", Address = "Ritva 38, Kfar Saba", BirthDate = DateTime.Parse("7/7/1997"), Email = "shaia@gmail.com", ID = "111111111", Phone = "0526655890", Sex = Sex.MALE });
            AddPatient(new Patient() { FirstName = "Sara", LastName = "Levi", Address = "kalanit 79, Jerusalem", BirthDate = DateTime.Parse("17/3/1955"), Email = "levi3@gmail.com", ID = "222222222", Phone = "0547481115", Sex = Sex.FEMALE });
            //==================================================================================================================================================================================
            ctx.Admins.Add(new Admin() { FirstName = "Admin", LastName = "Adminovski", Address = "Yehoodah Hanassi 118, Elad", BirthDate = DateTime.Parse("22/4/1990"), Email = "admin1@gmail.com", ID = "1234", Phone = "0547488565", Sex = Sex.MALE, Password = "1234" });
            //==================================================================================================================================================================================
            AddPhysician(new Physician() { FirstName = "Asher", LastName = "Bardugo", Address = "Yehoodah Hanassi 40, Bney Brak", BirthDate = DateTime.Parse("22/4/1980"), Email = "asher@gmail.com", ID = "333333333", Phone = "0507228588", Sex = Sex.MALE, Password = "3"});
            AddPhysician(new Physician() { FirstName = "Yossi", LastName = "Zaguri", Address = "HaMaapilim 6, Beytar", BirthDate = DateTime.Parse("1/11/1995"), Email = "zaguri_wpf@gmail.com", ID = "444444444", Phone = "0525293488", Sex = Sex.MALE, Password = "4" });
            //==================================================================================================================================================================================
            AddDrug(new Drug() { IdCode = "9478", Name = "Rulid", GenericName = "Roxithromycin", Manufacturer = "Sanofi", ImageUrl = ""});
            AddDrug(new Drug() { IdCode = "235743", Name = "Glucophage Caplets", GenericName = "Metformin Hydrochloride", Manufacturer = "Teva", ImageUrl = "" });
            AddDrug(new Drug() { IdCode = "212446", Name = "Azenil Capsules", GenericName = "Azithromycin", Manufacturer = "Pfizer", ImageUrl = "" });
            AddDrug(new Drug() { IdCode = "206812", Name = "Etopan", GenericName = "Etodolac", Manufacturer = "Taro", ImageUrl = "" });
            AddDrug(new Drug() { IdCode = "1111639", Name = "Copaxone", GenericName = "Glatiramer Acetate", Manufacturer = "Teva", ImageUrl = "" });
            AddDrug(new Drug() { IdCode = "979093", Name = "Plaquenil", GenericName = "Hydroxychloroquine Sulphate", Manufacturer = "Sanofi", ImageUrl = "" });
            AddDrug(new Drug() { IdCode = "1091142", Name = "Ritalin", GenericName = "Methylphenidate Hydrochloride", Manufacturer = "Novartis", ImageUrl = "" });
            AddDrug(new Drug() { IdCode = "731532", Name = "Advil Forte 400", GenericName = "Ibuprofen", Manufacturer = "Wyeth Lederle", ImageUrl = "" });
            AddDrug(new Drug() { IdCode = "314209", Name = "Rizalt Tablets", GenericName = "Rizatriptan", Manufacturer = "MSD", ImageUrl = "" });
            //==================================================================================================================================================================================
            AddActiveIngredient(new ActiveIngredient() { DrugIdCode= "9478", Ingredient= "Roxithromycin", MgQuantity = 150 });
            AddActiveIngredient(new ActiveIngredient() { DrugIdCode = "235743", Ingredient = "Metformin Hydrochloride", MgQuantity = 850 });
            AddActiveIngredient(new ActiveIngredient() { DrugIdCode = "212446", Ingredient = "Azithromycin", MgQuantity = 250 });
            AddActiveIngredient(new ActiveIngredient() { DrugIdCode = "206812", Ingredient = "Etodolac", MgQuantity = 400 });
            AddActiveIngredient(new ActiveIngredient() { DrugIdCode = "1111639", Ingredient = "Glatiramer Acetate", MgQuantity = 20 });
            AddActiveIngredient(new ActiveIngredient() { DrugIdCode = "979093", Ingredient = "Hydroxychloroquine Sulphate", MgQuantity = 200 });
            AddActiveIngredient(new ActiveIngredient() { DrugIdCode = "1091142", Ingredient = "Methylphenidate Hydrochloride", MgQuantity = 10 });
            AddActiveIngredient(new ActiveIngredient() { DrugIdCode = "731532", Ingredient = "Ibuprofen", MgQuantity = 400 });
            AddActiveIngredient(new ActiveIngredient() { DrugIdCode = "314209", Ingredient = "Rizatriptan", MgQuantity = 10 });
            //==================================================================================================================================================================================
            AddRecept(new Recept() { IdCodeOfDrug = "1111639", DrugGenericName = "Glatiramer Acetate", PatientID = "111111111", Days = 5, Date = DateTime.Now, PhysicianID = "444444444", Quantity = 8, ReceptId = "1" });
            AddRecept(new Recept() { IdCodeOfDrug = "731532", DrugGenericName = "Ibuprofen", PatientID = "111111111", Days = 5, Date = DateTime.Now, PhysicianID = "444444444", Quantity = 8, ReceptId = "11" });
            AddRecept(new Recept() { IdCodeOfDrug = "1091142", DrugGenericName = "Methylphenidate Hydrochloride", PatientID = "111111111", Days = 5, Date = DateTime.Now, PhysicianID = "444444444", Quantity = 8, ReceptId = "111" });
            AddRecept(new Recept() { IdCodeOfDrug = "206812", DrugGenericName = "Etodolac", PatientID = "123456789", Days = 5, Date = DateTime.Now, PhysicianID = "444444444", Quantity = 8, ReceptId = "1111" });
            AddRecept(new Recept() { IdCodeOfDrug = "206812", DrugGenericName = "Etodolac", PatientID = "111111111", Days = 5, Date = DateTime.Now, PhysicianID = "444444444", Quantity = 8, ReceptId = "12" });
            AddRecept(new Recept() { IdCodeOfDrug = "206812", DrugGenericName = "Etodolac", PatientID = "111111111", Days = 5, Date = DateTime.Now, PhysicianID = "444444444", Quantity = 8, ReceptId = "122" });
            AddRecept(new Recept() { IdCodeOfDrug = "206812", DrugGenericName = "Etodolac", PatientID = "111111111", Days = 5, Date = DateTime.Now, PhysicianID = "444444444", Quantity = 8, ReceptId = "1222" });
            AddRecept(new Recept() { IdCodeOfDrug = "731532", DrugGenericName = "Ibuprofen", PatientID = "123456789", Days = 5, Date = DateTime.Now, PhysicianID = "444444444", Quantity = 8, ReceptId = "13" });
            AddRecept(new Recept() { IdCodeOfDrug = "1111639", DrugGenericName = "Glatiramer Acetate", PatientID = "111111111", Days = 5, Date = DateTime.Now, PhysicianID = "444444444", Quantity = 8, ReceptId = "133" });
            AddRecept(new Recept() { IdCodeOfDrug = "1111639", DrugGenericName = "Glatiramer Acetate", PatientID = "123456789", Days = 5, Date = DateTime.Now, PhysicianID = "444444444", Quantity = 8, ReceptId = "1333" });
            AddRecept(new Recept() { IdCodeOfDrug = "1111639", DrugGenericName = "Glatiramer Acetate", PatientID = "111111111", Days = 5, Date = DateTime.Now, PhysicianID = "444444444", Quantity = 8, ReceptId = "14" });
            AddRecept(new Recept() { IdCodeOfDrug = "1111639", DrugGenericName = "Glatiramer Acetate", PatientID = "222222222", Days = 5, Date = DateTime.Now, PhysicianID = "444444444", Quantity = 8, ReceptId = "144" });
            AddRecept(new Recept() { IdCodeOfDrug = "1111639", DrugGenericName = "Glatiramer Acetate", PatientID = "987654321", Days = 5, Date = DateTime.Now, PhysicianID = "444444444", Quantity = 8, ReceptId = "1444" });
            AddRecept(new Recept() { IdCodeOfDrug = "1091142", DrugGenericName = "Methylphenidate Hydrochloride", PatientID = "222222222", Days = 5, Date = DateTime.Now, PhysicianID = "444444444", Quantity = 8, ReceptId = "15" });
            AddRecept(new Recept() { IdCodeOfDrug = "731532", DrugGenericName = "Ibuprofen", PatientID = "222222222", Days = 5, Date = DateTime.Now, PhysicianID = "444444444", Quantity = 8, ReceptId = "155" });
        }
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
        public bool DoesPatientExist(string id)
        {
            if (ctx.Patients.Find(id) != null)
                return true;
            return false;
        }
        public void AddPatient(Patient patient)
        {
            try
            {
                if (ctx.Patients.Find(patient.ID) != null)
                    throw new ArgumentException("id Already exists");
                ctx.Patients.Add(patient);
                ctx.SaveChanges();
            }
            catch (ArgumentException) { throw; }
            catch (Exception)
            {
                throw new Exception("Error adding Patient");
            }
        }
        public void DeletePatient(string id)
        {
            try
            {
                if (ctx.Patients.Find(id) == null)
                    throw new ArgumentException("id not exists");
                ctx.Patients.Remove(ctx.Patients.Find(id));
                ctx.SaveChanges();
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex)
            {
                throw new Exception("Error Deleteing Patient");
            }
        }
        public void UpdatePatient(Patient patient)
        {
            try
            {
                Patient oldPatient = ctx.Patients.Find(patient.ID);
                if (oldPatient == null)
                    throw new ArgumentException("id not exists");
                ctx.Patients.Remove(oldPatient);
                ctx.SaveChanges();
                ctx.Patients.Add(patient);
                ctx.SaveChanges();
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex)
            {
                throw new Exception("Error Updating Patient");
            }
        }
        public Patient GetPatient(string id)
        {
            try
            {
                Patient patient = ctx.Patients.Find(id);
                if (patient == null)
                    throw new KeyNotFoundException(id + "of Patient not found");
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
        public bool DoesPhysicianExist(string id)
        {
            if (ctx.Physicians.Find(id) != null)
                return true;
            return false;
        }
        public void AddPhysician(Physician physician)
        {
            try
            {
                if (ctx.Physicians.Find(physician.ID) != null)
                    throw new ArgumentException("Id Already exists");
                ctx.Physicians.Add(physician);
                ctx.SaveChanges();
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex)
            {
                throw new Exception("Error adding Patient");
            }
        }
        public void DeletePhysician(string id)
        {
            try
            {
                if (ctx.Physicians.Find(id) == null)
                    throw new ArgumentException("physician not exists");
                ctx.Physicians.Remove(ctx.Physicians.Find(id));
                ctx.SaveChanges();
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex)
            {
                throw new Exception("Error Delteing physician");
            }
        }
        public void UpdatePhysician(Physician physician)
        {
            try
            {
                if (ctx.Physicians.Find(physician.ID) == null)
                    throw new ArgumentException("physician not exists");
                ctx.Physicians.Remove(ctx.Physicians.Find(physician.ID));
                ctx.SaveChanges();
                ctx.Physicians.Add(physician);
                ctx.SaveChanges();
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex)
            {
                throw new Exception("Error Updating physician");
            }
        }
        public Physician GetPhysician(string id)
        {
            try
            {
                Physician physician = ctx.Physicians.Find(id);
                if (physician == null)
                    throw new KeyNotFoundException(id + "of Physician not found");
                return physician;
            }
            catch (KeyNotFoundException e) { throw; }
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
        public bool DoesDrugExist(string IdCode)
        {
            if (ctx.Drugs.Find(IdCode) != null)
                return true;
            return false;
        }
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

                if (ctx.Drugs.Find(drug.IdCode) != null)
                    throw new ArgumentException("Id Already exists");
                ctx.Drugs.Add(drug);
                ctx.SaveChanges();
            }
            catch (ArgumentException) { throw; }
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
                if (ctx.Drugs.Find(id) == null)
                    throw new ArgumentException("Id not exists");
                ctx.Drugs.Remove(ctx.Drugs.Find(id));
                ctx.SaveChanges();
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex)
            {
                throw new Exception("Error Deleteing Drug");
            }
        }
        public void UpdateDrug(Drug drug)
        {
            try
            {
                if (ctx.Drugs.Find(drug.IdCode) == null)
                    throw new ArgumentException("Id not exists");
                DeleteDrug(drug.IdCode);
                AddDrug(drug);
                
                
            }
            catch (ArgumentException) { throw; }
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
                if (drug == null)
                    throw new KeyNotFoundException("Drug not found");
                return drug;
            }
            catch (KeyNotFoundException) { throw; }
            catch (Exception ex)
            {
                throw new Exception("Error to Get Drug");
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
                throw new Exception("Error to Get List of Drugs");
            }
        }
        #endregion

        #region MedicalFile  
        public bool DoesMedicalFileExist(string id)
        {
            if (ctx.MedicalFiles.Find(id) != null)
                return true;
            return false;
        }

        public void AddMedicalFile(MedicalFile medicalFile)
        {
            try
            {
                if (ctx.MedicalFiles.Find(medicalFile.PatientId) != null)
                    throw new ArgumentException("medica File Already exists");
                ctx.MedicalFiles.Add(medicalFile);
                ctx.SaveChanges();
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex)
            {
                throw new Exception("Error adding Medica lFile");
            }
        }
        public MedicalFile GetMedicalFile(string patientID)
        {
            try
            {

                MedicalFile medicalFile = ctx.MedicalFiles.Find(patientID);
                if (medicalFile == null)
                    throw new KeyNotFoundException("Not found Medical File");
                return medicalFile;
            }
            catch (KeyNotFoundException) { throw; }
            catch (Exception ex)
            {
                throw new Exception("Error to Get Medical File");
            }
        }
        public void UpdateMedicalFile(string patientId, MedicalFile medicalFile)
        {
            try
            {
                if (ctx.MedicalFiles.Find(patientId) == null)
                    throw new ArgumentException("medicalFile not exists");
                ctx.MedicalFiles.Remove(ctx.MedicalFiles.Find(patientId));
                ctx.SaveChanges();
                ctx.MedicalFiles.Add(medicalFile);
                ctx.SaveChanges();
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex)
            {
                throw new Exception("Error updateing Medical File");
            }
        }
        #endregion

        #region Recept
        public void AddRecept(Recept recept)
        {
            try
            {
                if (ctx.Recepts.Find(recept.ReceptId) != null)
                    throw new ArgumentException("Recept Already exists");
                ctx.Recepts.Add(recept);
                ctx.SaveChanges();
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex)
            {
                throw new Exception("Error Adding Recept");
            }
        }
        public void DeleteReceipt(string ReceptId)
        {
            try
            {
                if (ctx.Recepts.Find(ReceptId) == null)
                    throw new ArgumentException("Recept not exists");
                ctx.Recepts.Remove(ctx.Recepts.Find(ReceptId));
                ctx.SaveChanges();
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex)
            {
                throw new Exception("Error Deleting Recept");
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
                throw new Exception("Error to Get List of Recepts");
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
                throw new Exception("Error to Get List of Recepts By Date");
            }
        }
        public List<Recept> GetAllReceptsByDrug(string drugIdCode)
        {
            try
            {
                return ctx.Recepts.Where(r => r.IdCodeOfDrug == drugIdCode).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error to Get List of Recepts By Drug");
            }
        }
        #endregion

        #region MediclRecord
        public bool DoesMediclRecordExist(string id)
        {
            if (ctx.MedicalRecords.Find(id) != null)
                return true;
            return false;
        }
        public void AddMediclRecordToPatient(MedicalRecord medicalRecord)
        {
            try
            {
                if (ctx.MedicalRecords.Find(medicalRecord.MedicalRecordID) != null)
                    throw new ArgumentException("Medical Record Already exists");
                ctx.MedicalRecords.Add(medicalRecord);
                ctx.SaveChanges();
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex)
            {
                throw new Exception("Error adding MedicalRecord");
            }
        }
        public MedicalRecord GetMedicalRecord(string medicalRecordID)
        {
            try
            {
                MedicalRecord medicalRecord = ctx.MedicalRecords.Find(medicalRecordID);
                if (medicalRecord == null)
                    throw new KeyNotFoundException("Not found Medical Record");
                return medicalRecord;
            }
            catch (KeyNotFoundException) { throw; }
            catch (Exception ex)
            {
                throw new Exception("Error Get Medical Record");
            }
        }

        public void UpdateMedicalRecord(string medicalRecordID, MedicalRecord medicalRecord)
        {
            try
            {
                if (ctx.MedicalRecords.Find(medicalRecordID) == null)
                    throw new ArgumentException("Medical Record not exists");
                ctx.MedicalRecords.Remove(ctx.MedicalRecords.Find(medicalRecord.MedicalRecordID));
                ctx.SaveChanges();
                ctx.MedicalRecords.Add(medicalRecord);
                ctx.SaveChanges();
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex)
            {
                throw new Exception("Error update Medical Record ");
            }
        }
        #endregion

        #region ActiveIngredient
        public void AddActiveIngredient(ActiveIngredient ingredient)
        {
            try
            {
                if (ctx.ActiveIngredients.Find(ingredient.ID) != null)
                    throw new ArgumentException("Active Ingredient Already exists");
                ctx.ActiveIngredients.Add(ingredient);
                ctx.SaveChanges();
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex)
            {
                throw new Exception("Error add Active Ingredient");
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
                throw new Exception("Error Get Active Ingredients Of Drug ");
            }
        }
        public void UpdateActiveIngredient(ActiveIngredient ingredient)
        {
            try
            {
                if (ctx.ActiveIngredients.Find(ingredient.ID) == null)
                    throw new ArgumentException("Active Ingredient not exists");
                ctx.ActiveIngredients.Remove(ctx.ActiveIngredients.Find(ingredient));
                ctx.SaveChanges();
                ctx.ActiveIngredients.Add(ingredient);
                ctx.SaveChanges();
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex)
            {
                throw new Exception("Error - Update Active Ingredient ");
            }
        }
        public void DeleteActiveIngredient(ActiveIngredient ingredient)
        {
            try
            {
                if (ctx.ActiveIngredients.Find(ingredient.ID) == null)
                    throw new ArgumentException("Active Ingredient not exists");
                ctx.ActiveIngredients.Remove(ctx.ActiveIngredients.Find(ingredient.ID));
                ctx.SaveChanges();
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex)
            {
                throw new Exception("Error - Delete Active Ingredient ");
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
                throw new Exception("Error - Get All Medical Records Of Patient ");
            }
        }

        #endregion
    }
}
