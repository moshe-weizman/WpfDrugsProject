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
            AllRecepts = bl.GetAllReceptOfPatient(patientId);
        }

        internal void AddMedicalFileToDb()
        {
            bl.AddMedicalFileToPatient(MedicalFile);
        }

        internal bool MedicalFileAlreadyExists()
        {
            throw new NotImplementedException();
        }

        internal void UpdateMedicalFile()
        {
            bl.UpdateMedicalFile(MedicalFile.PatientId, MedicalFile);
        }
    }
}
