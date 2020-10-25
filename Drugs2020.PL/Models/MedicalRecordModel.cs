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

        public MedicalRecordModel(string patientId)
        {
            MedicalRecord = new MedicalRecord(patientId);
            bl = new BLImplementation();

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
