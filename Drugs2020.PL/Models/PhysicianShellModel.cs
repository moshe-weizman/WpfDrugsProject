using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class PhysicianShellModel
    {
        
        private IBL bl;        
        public Patient CurrentPatient { get; set; }
        public MedicalFile MedicalFile { get; set; }
        public Recept Recept { get; set; }

        public PhysicianShellModel(Patient currentPatient)
        {
            bl = new BLImplementation();
            this.CurrentPatient = currentPatient;
        }

        public void GetPatient(string id)
        {
            CurrentPatient= bl.GetPatient(id);
            if (CurrentPatient == null)//exception instead?
            {
                return;
            }
            MedicalFile = bl.GetMedicalFile(id);
            if (MedicalFile == null)
            {
                MedicalFile = new MedicalFile(id);
            }
            Recept = new Recept(id);
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
            //bl.UpdateMedicalFile(PatientId, MedicalFile);
        }

        public bool MedicalFileAlreadyExists()
        {
            //if (bl.GetMedicalFile(PatientId) == null)
            //    return false;
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
