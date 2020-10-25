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
            
            MedicalFile = bl.GetMedicalFile(patientId);
            if (MedicalFile == null)
                MedicalFile = new MedicalFile(patientId);
            AllRecepts = bl.GetAllReceptsOfPatient(patientId);
        }

        public void AddMedicalFileToDb()
        {
            bl.AddMedicalFileToPatient(MedicalFile);
        }

        public bool MedicalFileAlreadyExists()
        {
            return bl.MedicalFileAlreadyExists(MedicalFile);
        }

        public void UpdateMedicalFile()
        {
            bl.UpdateMedicalFile(MedicalFile.PatientId, MedicalFile);
        }

       
    }
}
