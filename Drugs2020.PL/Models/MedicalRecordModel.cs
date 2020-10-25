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
        public MedicalRecordModel(string patientId,string physicianId)
        {
            bl = new BLImplementation();
            MedicalRecord = new MedicalRecord(patientId, physicianId);
            MedicalRecordsList = bl.GetAllMedicalRecordsOfPatient(patientId);

        }

        public void AddMedicalRecordToDb()
        {
          //  bl.AddMediclRecordToPatient(MedicalRecord);
        }

        public bool MedicalRecordAlreadyExists()
        {
            return bl.MedicalRecordAlreadyExists(MedicalRecord);
        }

        public void UpdateMedicalRecord()
        {
            bl.UpdateMedicalRecord(MedicalRecord.MedicalRecordID, MedicalRecord);
        }
    }
}
