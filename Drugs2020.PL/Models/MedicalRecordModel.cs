using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class MedicalRecordModel
    {
        IBL bl;
        public MedicalRecord MedicalRecord { get; set; }
        public List<MedicalRecord> MedicalRecordsList { get; set; }
        public MedicalRecordModel(string patientId, Physician physicianUser, MedicalRecord MedicalRecordExists = null)
        {
            bl = new BLImplementation();
            if (MedicalRecordExists == null)
                MedicalRecord = new MedicalRecord(patientId, physicianUser);
            else
                MedicalRecord = MedicalRecordExists;
            MedicalRecordsList = bl.GetAllMedicalRecordsOfPatient(MedicalRecord.PatientID);
            MedicalRecordsList.ForEach(x => x.PhysicianName = bl.GetPhysician(x.PhysicianID).FirstName);
            MedicalRecordsList.Where(x => x.PhysicianID == physicianUser.ID).All(x => x.AbleEdit = true);

        }

        public void AddMedicalRecordToDb()
        {
            try
            {
                bl.AddMediclRecordToPatient(MedicalRecord);
            }
            catch (ArgumentException) { throw; }
            catch (Exception) { throw; }
        }

        public bool MedicalRecordAlreadyExists()
        {
            return bl.DoesMediclRecordExist(MedicalRecord.MedicalRecordID);
        }

        public void UpdateMedicalRecord()
        {
            try
            {
                bl.UpdateMedicalRecord(MedicalRecord.MedicalRecordID, MedicalRecord);
            }
            catch (ArgumentException) { throw; }
            catch (Exception) { throw; }
        }

        public void GetMedicalRecord(string MedicalRecordID)
        {
            try
            {
                MedicalRecord = bl.GetMedicalRecord(MedicalRecordID);
            }
            catch (KeyNotFoundException) { throw; }
            catch (Exception) { throw; }
        }
    }
}
