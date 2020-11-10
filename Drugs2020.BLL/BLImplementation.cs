using Drugs2020.BLL.BE;
using Drugs2020.DAL;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;

namespace Drugs2020.BLL
{
    public class BLImplementation : IBL
    {
        IDal dal = new DalImplementation();
        private ICloudForImage cloud = new GoogleDrive();
        const string DEFAULT_IMAGE_PATH = @"..\ApplicationResources\DrugsImages\default.png";
        const string IMAGES_FILES_EXTENSION = @".png";
        const string PDF_FILES_EXTENSION = @".pdf";
        string receptsStoragePath = Path.GetFullPath(@"..\ApplicationResources\ReceptsPDF");
        string imagesStoragePath = Path.GetFullPath(@"..\ApplicationResources\DrugsImages");

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
            try
            {
                return dal.IdentifyUser(userID);
            }
            catch (KeyNotFoundException) { throw; }
            catch (Exception) { throw; }
        }

        #endregion

        #region Medical Record
        public void AddMediclRecordToPatient(MedicalRecord medicalRecord)
        {
            try
            {
                dal.AddMediclRecordToPatient(medicalRecord);
            }
            catch (ArgumentException) { throw; }
            catch (Exception) { throw; }
        }
        public MedicalRecord GetMedicalRecord(string medicalRecordID)
        {
            try
            {
                return dal.GetMedicalRecord(medicalRecordID);
            }
            catch (KeyNotFoundException) { throw; }
            catch (Exception) { throw; }
        }
        public void UpdateMedicalRecord(string medicalRecordID, MedicalRecord medicalRecord)
        {
            try
            {
                dal.UpdateMedicalRecord(medicalRecordID, medicalRecord);
            }
            catch (ArgumentException) { throw; }
            catch (Exception) { throw; }
        }
        public bool DoesMediclRecordExist(string id)
        {
            return dal.DoesMediclRecordExist(id);
        }
        public bool MedicalRecordAlreadyExists(MedicalRecord medicalRecord)//מיותר לכאורה
        {
            try
            {
                if (dal.GetMedicalRecord(medicalRecord.MedicalRecordID) == null)
                    return false;
                return true;
            }
            catch (KeyNotFoundException) { throw; }
            catch (Exception) { throw; }
        }
        #endregion

        #region Medical File Functions
        public bool DoesMedicalFileExist(string id)
        {
            return dal.DoesMedicalFileExist(id);
        }

        public void AddMedicalFileToPatient(MedicalFile medicalFile)
        {
            try
            {
                dal.AddMedicalFile(medicalFile);
            }
            catch (ArgumentException) { throw; }
            catch (Exception) { throw; }
        }

        public bool MedicalFileAlreadyExists(MedicalFile medicalFile)//לכאורה פונקציה לא נצרכת
        {
            try
            {
                if (dal.GetMedicalFile(medicalFile.PatientId) == null)

                    return false;
                return true;
            }
            catch (KeyNotFoundException) { throw; }
            catch (Exception) { throw; }
        }

        public MedicalFile GetMedicalFile(string patientID)
        {
            try
            {
                return dal.GetMedicalFile(patientID);
            }
            catch (KeyNotFoundException) { throw; }
            catch (Exception) { throw; }
        }

        public void UpdateMedicalFile(string patientId, MedicalFile medicalFile)
        {
            try
            {
                dal.UpdateMedicalFile(patientId, medicalFile);
            }
            catch (ArgumentException) { throw; }
            catch (Exception) { throw; }
        }
        #endregion

        #region Recept & Drugs-Taken Functions
        public void AddRecept(Recept recept)
        {
            try
            {
                dal.AddRecept(recept);
            }
            catch (ArgumentException) { throw; }
            catch (Exception) { throw; }
        }


        public void DeleteReceipt(Recept receipt)
        {
            try
            {
                dal.DeleteReceipt(receipt.ReceptId.ToString());
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex) { throw; }
        }



        public List<string> checkConflicts(string IdCodeOfDrug, List<string> drugsTakenPatient)
        {
            try
            {
                DrugConflictTest drugConflictTest = new DrugConflictTest();
                return drugConflictTest.ConflictTest2(IdCodeOfDrug, drugsTakenPatient);
            }
            catch (Exception) { throw; }
        }

        public List<Recept> GetAllReceptsOfPatient(string id)
        {
            try
            {
                return dal.GetAllReceptsOfPatient(id);
            }
            catch (Exception) { throw; }
        }

        public List<Recept> GetAllReceptsByDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                return dal.GetAllReceptsByDate(startDate, endDate);
            }
            catch (Exception) { throw; }
        }

        public List<Recept> GetAllReceptsByDrug(string drugIdCode)
        {
            try
            {
                return dal.GetAllReceptsByDrug(drugIdCode);
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Patient CRUD Functions
        public bool DoesPatientExist(string id)
        {
            return dal.DoesPatientExist(id);
        }

        public Patient GetPatient(string ID)
        {
            try
            {
                return dal.GetPatient(ID);
            }
            catch (KeyNotFoundException e) { throw; }
            catch (Exception e) { throw; }
        }
        public List<Patient> GetAllPatients()
        {
            try
            {
                return dal.GetAllPatients();
            }
            catch (Exception ex) { throw; }
        }

        public void AddPatient(Patient patient)
        {
            try
            {
                dal.AddPatient(patient);
            }
            catch (ArgumentException) { throw; }
            catch (Exception) { throw; }
        }

        public void UpdatePatient(string id, Patient updatedPatient)
        {
            try
            {
                dal.UpdatePatient(updatedPatient);
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex) { throw; }
        }

        public void DeletePatient(string id)
        {
            try
            {
                dal.DeletePatient(id);
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex) { throw; }
        }
        #endregion

        #region Physician CRUD Functions
        public Physician GetPhysician(string ID)
        {
            try
            {
                return dal.GetPhysician(ID);
            }
            catch (KeyNotFoundException e) { throw; }
            catch (Exception ex) { throw; }
        }

        public List<Physician> GetAllPhysicians()
        {
            try
            {
                return dal.GetAllPhysicians();
            }
            catch (Exception ex) { throw; }
        }
        public bool DoesPhysicianExist(string id)
        {
            return dal.DoesPhysicianExist(id);
        }
        public void AddPhysician(Physician physician)
        {
            try
            {
                dal.AddPhysician(physician);
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex) { throw; }
        }

        public void UpdatePhysician(string id, Physician updatedPhysician)
        {
            try
            {
                dal.UpdatePhysician(updatedPhysician);
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex) { throw; }
        }

        public void DeletePhysician(string id)
        {
            try
            {
                dal.DeletePhysician(id);
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex) { throw; }
        }

        #endregion

        #region Drug CRUD Functions
        public bool DoesDrugExist(string IdCode)
        {
            return dal.DoesDrugExist(IdCode);
        }
        public Drug GetDrug(string ID)
        {
            try
            {
                Drug drug = dal.GetDrug(ID);
                if (drug == null)//אפשר למחוק לכאורה בגלל הזריקת חריגה
                {
                    return null;
                }
                if (File.Exists(drug.ImageUrl))
                {
                    return drug;
                }
                if (cloud.DoesFileExists(drug.IdCode + IMAGES_FILES_EXTENSION))
                {
                    cloud.Download(drug.IdCode + IMAGES_FILES_EXTENSION, imagesStoragePath);
                    string path = Path.Combine(imagesStoragePath, drug.IdCode + IMAGES_FILES_EXTENSION);
                    drug.ImageUrl = path;
                    return drug;
                }
                drug.ImageUrl = DEFAULT_IMAGE_PATH;
                return drug;
            }
            catch (KeyNotFoundException) { throw; }
            catch (Exception ex) { throw; }
        }

        public void AddDrug(Drug drug)
        {
            if (File.Exists(drug.ImageUrl))
            {
                SaveImage(drug);
            }
            else
            {
                drug.ImageUrl = DEFAULT_IMAGE_PATH;
            }
            try
            {
                dal.AddDrug(drug);
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex) { throw; }
        }

        private void SaveImage(Drug drug)
        {
            string drugImageName = drug.IdCode + IMAGES_FILES_EXTENSION;
            drug.ImageUrl = SaveFileLocally(drug.ImageUrl, imagesStoragePath, drugImageName);
            while (cloud.DoesFileExists(drugImageName))
            {
                cloud.Remove(drugImageName);
            }
            cloud.Upload(drug.ImageUrl);
        }

        private string SaveFileLocally(string filePath, string targetDirectory, string targetFileName)
        {
            Directory.CreateDirectory(targetDirectory);
            string destinaion = Path.Combine(targetDirectory, targetFileName);
            File.Copy(filePath, destinaion, true);
            return destinaion;
        }

        public void UpdateDrug(string id, Drug updatedDrug)
        {
            try
            {
                dal.UpdateDrug(updatedDrug);
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex) { throw; }
        }

        public void DeleteDrug(string id)
        {
            try
            {
                dal.DeleteDrug(id);
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex) { throw; }
        }


        public List<Drug> GetAllDrugs()
        {
            try
            {
                return dal.GetAllDrugs();
            }
            catch (Exception ex) { throw; }
        }
        #endregion

        #region ActiveIngredient CRUD Functions
        public void AddActiveIngredient(ActiveIngredient ingredient)
        {
            try
            {
                dal.AddActiveIngredient(ingredient);
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex) { throw; }
        }

        public List<ActiveIngredient> GetActiveIngredientsOfDrug(string DrugIdCode)
        {
            try
            {
                return dal.GetActiveIngredientsOfDrug(DrugIdCode);
            }
            catch (Exception ex) { throw; }
        }

        public void UpdateActiveIngredient(ActiveIngredient ingredient)
        {
            try
            {
                dal.UpdateActiveIngredient(ingredient);
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex) { throw; }
        }

        public void DeleteActiveIngredient(ActiveIngredient ingredient)
        {
            try
            {
                dal.DeleteActiveIngredient(ingredient);
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex) { throw; }
        }

        public List<MedicalRecord> GetAllMedicalRecordsOfPatient(string patientId)
        {
            try
            {
                return dal.GetAllMedicalRecordsOfPatient(patientId);
            }
            catch (Exception) { throw; }
        }

        public void CreatePDF(Recept recept)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            //-------------------------------------------//-------------------------------------------

            XFont font = new XFont("Times New Roman", 15, XFontStyle.Bold);
            XTextFormatter tf = new XTextFormatter(gfx);
            var lineColor = XPens.DarkGreen;
            int y = 60;
            //---------------------כותרת----------------

            gfx.DrawString("madicel center ", new XFont("Times New Roman", 15, XFontStyle.Bold)
                , XBrushes.Black, new XRect(page.Width / 2, 5, 5, 0), XStringFormats.TopCenter);

            gfx.DrawString("recept No: " + recept.ReceptId, new XFont("Times New Roman", 15, XFontStyle.Bold)
                , XBrushes.Black, new XRect(page.Width - 25, 5, 5, 0), XStringFormats.TopRight);

            gfx.DrawString(recept.Date.ToString(), new XFont("Times New Roman", 15, XFontStyle.Bold)
                , XBrushes.Black, new XRect(5, 5, 5, 0), XStringFormats.TopLeft);

            gfx.DrawString("Recept", new XFont("Times New Roman", 30, XFontStyle.Bold)
                 , XBrushes.Black, new XRect(0, y, page.Width, 0), XStringFormats.Center);

            //-------------------Physician------------------------
            Physician Dr = GetPhysician(recept.PhysicianID);
            string drName = "Doctor " + Dr.FirstName + " " + Dr.LastName + ".\n" +
                "phone: " + Dr.Phone + "\n" +
                 "email: " + Dr.Email + "\n" +
                  "address: " + Dr.Address;

            //---------------------Patient---------------------- 
            Patient patient = GetPatient(recept.PatientID);
            string patientDetail = patient.Sex == Sex.MALE ? "Mr " : "Miss ";
            patientDetail += patient.FirstName + " " + patient.LastName + ".\n";
            patientDetail += "id: " + patient.ID + "\n" +
            "sex: " + patient.Sex + "      Age: " + patient.Age + "\n" +
            "address: " + patient.Address;

            //----------------------Drug---------------------
            Drug drug = GetDrug(recept.IdCodeOfDrug);
            string receptDetail1 = "Drug name: " + drug.Name + "\n" +
                "generic name: " + drug.GenericName + "\n" +
                "quantity: " + recept.Quantity + " in day for " + recept.Days;
            receptDetail1 += recept.Days > 1 ? " day." : " days.";
            string receptDetail2 = "code: " + drug.IdCode + "\n" +
                           "valid until: " + recept.ExpirationDate;
            //-------------------------------------------

            y += 30;

            gfx.DrawRoundedRectangle(new XPen(XColors.RoyalBlue, Math.PI),
               XBrushes.White, 15, y, 250, 100, 20, 20);

            XRect rect = new XRect(25, y + 15, 200, 100);
            // gfx.DrawRectangle(XBrushes.SeaShell, rect);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString(drName, font, XBrushes.Black, rect, XStringFormats.TopLeft);
            //-------------------------------------------

            gfx.DrawRoundedRectangle(new XPen(XColors.RoyalBlue, Math.PI),
                XBrushes.White, page.Width / 3 + 140 - 15, y, 250, 100, 20, 20);

            rect = new XRect(page.Width / 3 + 140, y + 15, 250, 220);
            // gfx.DrawRectangle(XBrushes.SeaShell, rect);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString(patientDetail, font, XBrushes.Black, rect, XStringFormats.TopLeft);
            //-------------------------------------------


            y += 120;

            gfx.DrawString("Drug: ", new XFont("Times New Roman", 20, XFontStyle.Bold)
                , XBrushes.Black, new XRect(25, y, 5, 0), XStringFormats.TopLeft);

            gfx.DrawRoundedRectangle(new XPen(XColors.RoyalBlue, Math.PI),
                 XBrushes.White, 15, y + 30, 560, 80, 20, 20);

            rect = new XRect(25, y + 40, 420, 100);
            // gfx.DrawRectangle(XBrushes.SeaShell, rect);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString(receptDetail1, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            rect = new XRect(page.Width / 3 + 140, y + 40, 420, 100);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString(receptDetail2, font, XBrushes.Black, rect, XStringFormats.TopLeft);


            //-------------------------------------------
            string filename = "recept.pdf";
            document.Save(filename);
            Process.Start(filename);
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