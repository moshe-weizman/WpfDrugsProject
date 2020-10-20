using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class PatientModel
    {
        
        private IBL bl;
        public string PatientId { get; set; }
        public Patient CurrentPatient { get; set; }
        public MedicalFile MedicalFile { get; set; }
        public Recept Recept { get; set; }

        public PatientModel()
        {
            bl = new BLImplementation();   
        }

        public void GetPatient()
        {
            CurrentPatient= bl.GetPatient(PatientId);
            if (CurrentPatient == null)//exception instead?
            {
                return;
            }
            MedicalFile = bl.GetMedicalFile(PatientId);
            if (MedicalFile == null)
            {
                MedicalFile = new MedicalFile(PatientId);
            }
            Recept = new Recept(PatientId);
        }

        public void UpdatePatient()
        {
            bl.UpdatePatient(CurrentPatient.ID, CurrentPatient);
        }

        public void AddMedicalFileToPatient()
        {
            bl.AddMedicalFileToPatient(MedicalFile);
        }

        public void UpdateMedicalFile()
        {
            bl.UpdateMedicalFile(PatientId, MedicalFile);
        }

        public bool MedicalFileAlreadyExists()
        {
            if (bl.GetMedicalFile(PatientId) == null)
                return false;
            return true;
        }
        public void AddRecept()
        {
            bl.AddRecept(Recept);
        }

        public bool ReceptAlreadyExists()
        {
            return false;//חובה לממש את זה!!!!!!!!!!!!!1
        }
    }
}
