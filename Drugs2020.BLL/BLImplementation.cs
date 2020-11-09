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
        const string LOCAL_STORAGE_PATH = @"..\ApplicationResources";
        const string IMAGES_STORAGE_DIRECTORY = @"\DrugsImages";
        const string IMAGES_FILES_EXTENSION = @".png";
        const string DEFAULT_IMAGE_PATH = @"..\ApplicationResources\DrugsImages\default.png";
        const string RECEPTS_PDF_STORAGE_DIRECTORY = @"\ReceptsPDF";
        const string PDF_FILES_EXTENSION = @".pdf";
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
            return dal.IdentifyUser(userID);
            //switch (userID)
            //{
            //    case "1234":
            //        return new Admin("1234", "Mose", "Weizman", Sex.MALE, "0545678990", @"Moshe@gmail.com", "1234", "Elad", DateTime.Parse("12/10/1985"));
            //    case "4321":
            //        return new Physician("4321", "Mose", "Weizman", Sex.MALE, "0545678990", @"Moshe@gmail.com", "4321", "Elad", DateTime.Parse("12/10/1985"));
            //}
            //return null;
        }

        #endregion

        #region Medical Record
        public void AddMediclRecordToPatient(MedicalRecord medicalRecord)
        {
            dal.AddMediclRecordToPatient(medicalRecord);
        }
        public MedicalRecord GetMedicalRecord(string medicalRecordID)
        {
            return dal.GetMedicalRecord(medicalRecordID);
        }
        public void UpdateMedicalRecord(string medicalRecordID, MedicalRecord medicalRecord)
        {
            dal.UpdateMedicalRecord(medicalRecordID, medicalRecord);
        }
        public bool MedicalRecordAlreadyExists(MedicalRecord medicalRecord)
        {
            if (dal.GetMedicalRecord(medicalRecord.MedicalRecordID) == null)
                return false;
            return true;
        }
        #endregion

        #region Medical File Functions
        public void AddMedicalFileToPatient(MedicalFile medicalFile)
        {
            dal.AddMedicalFile(medicalFile);
        }

        public bool MedicalFileAlreadyExists(MedicalFile medicalFile)
        {
            if (dal.GetMedicalFile(medicalFile.PatientId) == null)
                return false;
            return true;
        }

        public MedicalFile GetMedicalFile(string patientID)
        {
            return dal.GetMedicalFile(patientID); 
        }

        public void UpdateMedicalFile(string patientId, MedicalFile medicalFile)
        {
            dal.UpdateMedicalFile(patientId, medicalFile);
        }
        #endregion

        #region Recept & Drugs-Taken Functions
        public void AddRecept(Recept recept)
        {
                dal.AddRecept(recept);
        }

       
        public void DeleteReceipt(Recept receipt)
        {
            dal.DeleteReceipt(receipt.ReceptId);
        }



        public List<string> checkConflicts(string IdCodeOfDrug, List<string> drugsTakenPatient)
        {
            DrugConflictTest drugConflictTest = new DrugConflictTest();
            return drugConflictTest.ConflictTest2(IdCodeOfDrug, drugsTakenPatient);
        }

        public List<Recept> GetAllReceptsOfPatient(string id)
        {
             return dal.GetAllReceptsOfPatient(id);
            //return new List<Recept>() { new Recept("123", 12, "er12", "acmol", 12, 10, DateTime.Now), new Recept("123", 12, "op2", "advil", 12, 10, DateTime.Now) };
        }

        public List<Recept> GetAllReceptsByDate(DateTime startDate, DateTime endDate)
        {
            return dal.GetAllReceptsByDate(startDate, endDate);
        }

        public List<Recept> GetAllReceptsByDrug(string drugIdCode)
        {
            return dal.GetAllReceptsByDrug(drugIdCode);
        }
        #endregion

        #region Patient CRUD Functions
        public Patient GetPatient(string ID)
        {
             return dal.GetPatient(ID);
           // return new Patient("1", "mor", "cohen", Sex.FEMALE, "0500000000", "email", "elad", DateTime.Now);
        }
        public List<Patient> GetAllPatients()
        {
            return dal.GetAllPatients();           
        }

        public void AddPatient(Patient patient)
        {
            dal.AddPatient(patient);
        }

        public void UpdatePatient(string id, Patient updatedPatient)
        {
            dal.UpdatePatient(updatedPatient);
        }

        public void DeletePatient(string id)
        {
            dal.DeletePatient(id);
        }
        #endregion

        #region Physician CRUD Functions
        public Physician GetPhysician(string ID)
        {
            return dal.GetPhysician(ID);
        }

        public List<Physician> GetAllPhysicians()
        {
            return dal.GetAllPhysicians();
        }

        public void AddPhysician(Physician physician)
        {
            dal.AddPhysician(physician);
        }

        public void UpdatePhysician(string id, Physician updatedPhysician)
        {
            dal.UpdatePhysician(updatedPhysician);
        }

        public void DeletePhysician(string id)
        {
            dal.DeletePhysician(id);
        }

        #endregion

        #region Drug CRUD Functions
        public Drug GetDrug(string ID)
        {
            Drug drug = dal.GetDrug(ID);
            if (File.Exists(drug.ImageUrl))
            {
                return drug;
            }
            if (cloud.DoesFileExists(drug.IdCode + IMAGES_FILES_EXTENSION))
            {
                cloud.Download(drug.IdCode + IMAGES_FILES_EXTENSION, LOCAL_STORAGE_PATH + IMAGES_STORAGE_DIRECTORY);
                string path = Path.Combine(LOCAL_STORAGE_PATH, IMAGES_STORAGE_DIRECTORY, drug.IdCode + IMAGES_FILES_EXTENSION);
                drug.ImageUrl = path;
                return drug;
            }
            drug.ImageUrl = DEFAULT_IMAGE_PATH;
            return drug;
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
            dal.AddDrug(drug);
        }

        private void SaveImage(Drug drug)
        {
            string drugImageName = drug.IdCode + IMAGES_FILES_EXTENSION;
            drug.ImageUrl = SaveFileLocally(drug.ImageUrl, IMAGES_STORAGE_DIRECTORY, drugImageName);
            while (cloud.DoesFileExists(drugImageName))
            {
                cloud.Remove(drugImageName);
            }
            cloud.Upload(drug.ImageUrl);
        }

        private string SaveFileLocally(string filePath, string targetDirectoryName, string targetFileName)
        {
            string targetDirectory = LOCAL_STORAGE_PATH + targetDirectoryName;
            Directory.CreateDirectory(targetDirectory);
            string destinaion = Path.Combine(targetDirectory, targetFileName);
            File.Copy(filePath, destinaion, true);
            return destinaion;
        }

        public void UpdateDrug(string id, Drug updatedDrug)
        {
            dal.UpdateDrug(updatedDrug);
        }

        public void DeleteDrug(string id)
        {
            dal.DeleteDrug(id);
        }


        public List<Drug> GetAllDrugs()
        {
            return dal.GetAllDrugs();
        }
        #endregion

        #region ActiveIngredient CRUD Functions
        public void AddActiveIngredient(ActiveIngredient ingredient)
        {
            dal.AddActiveIngredient( ingredient);
        }

        public List<ActiveIngredient> GetActiveIngredientsOfDrug(string DrugIdCode)
        {
            return dal.GetActiveIngredientsOfDrug(DrugIdCode);
        }

        public void UpdateActiveIngredient(ActiveIngredient ingredient)
        {
            dal.UpdateActiveIngredient(ingredient);
        }

        public void DeleteActiveIngredient(ActiveIngredient ingredient)
        {
            dal.DeleteActiveIngredient(ingredient);
        }

        public List<MedicalRecord> GetAllMedicalRecordsOfPatient(string patientId)
        {
            return dal.GetAllMedicalRecordsOfPatient(patientId);
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

            gfx.DrawString("recept", new XFont("Times New Roman", 30, XFontStyle.Bold)
                 , XBrushes.Black, new XRect(0, y, page.Width, 0), XStringFormats.Center);

            //-------------------Physician------------------------
            Physician Dr = GetPhysician(recept.PhysicianID);
            string drName = "doctor " + Dr.FirstName + " " + Dr.LastName + ".\n" +
                "phone: " + Dr.Phone + "\n" +
                 "email: " + Dr.Email + "\n" +
                  "address: " + Dr.Address;

            //---------------------Patient---------------------- 
            Patient patient = GetPatient(recept.PatientID);
            string patientDetail = patient.Sex == Sex.MALE ? "Mr " : "Miss ";
            patientDetail += patient.FirstName + " " + patient.LastName + ".\n";
            patientDetail += "id: " + patient.ID + "\n" +
            "sex: " + patient.Sex + "  Age: " + patient.Age + "\n" +
            "address: " + patient.Address;

            //----------------------Drug---------------------
            Drug drug = GetDrug(recept.IdCodeOfDrug);
            string receptDetail1 = "drug name: " + drug.Name + "\n" +
                "generic name: " + drug.GenericName + "\n" +
                "quantity: " + recept.Quantity + " in day for " + recept.Days;
            receptDetail1 += recept.Days > 1 ? " day." : " days.";
            string receptDetail2 = "code: " + drug.IdCode +
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
                 XBrushes.White, 15, y + 30, 450, 80, 20, 20);

            rect = new XRect(25, y + 40, 420, 100);
            // gfx.DrawRectangle(XBrushes.SeaShell, rect);
            tf.Alignment = XParagraphAlignment.Left;
            tf.DrawString(receptDetail1, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            tf.Alignment = XParagraphAlignment.Right;
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