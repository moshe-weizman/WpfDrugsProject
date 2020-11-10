using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    public class MedicalFileModel
    {
        private IBL bl;

        public MedicalFile MedicalFile { get; set; }
        public List<Recept> AllRecepts { get; set; }
        public MedicalFileModel(string patientId)
        {
            bl = new BLImplementation();
            if (bl.DoesMedicalFileExist(patientId))
                MedicalFile = bl.GetMedicalFile(patientId);
            else
                MedicalFile = new MedicalFile(patientId);
            AllRecepts = bl.GetAllReceptsOfPatient(patientId);
        }

        public void AddMedicalFileToDb()
        {
            try
            {
                bl.AddMedicalFileToPatient(MedicalFile);
            }
            catch (ArgumentException) { throw; }
            catch (Exception) { throw; }
        }

        public bool MedicalFileAlreadyExists()
        {
            return bl.DoesMedicalFileExist(MedicalFile.PatientId);
        }

        public void UpdateMedicalFile()
        {
            try
            {
                bl.UpdateMedicalFile(MedicalFile.PatientId, MedicalFile);
            }
            catch (ArgumentException) { throw; }
            catch (Exception) { throw; }
        }

        public void RemoveReceiptFromDb(Recept receipt)
        {
            try
            {
                bl.DeleteReceipt(receipt);
            }
            catch (ArgumentException) { throw; }
            catch (Exception ) { throw; }
        }


    }
}
