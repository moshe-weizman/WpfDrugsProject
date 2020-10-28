using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drugs2020.BLL.BE
{
    public class MedicalRecord
    {
        
       // public DateTime Date { get; }
       [Key]
        public string MedicalRecordID { get; set; }
        public string PatientID { get; set; }
        public string PhysicianID { get; set; }
        [NotMapped]
        public string PhysicianName { get; set; }
        [NotMapped]
        public bool AbleEdit { get; set; }
        public string Problem { get; set; }
        public string Diagnose { get; set; }
        public string Treatment { get; set; }
        //public bool DrugGiven { get; set; }
        public string PhysicianNotes { get; set; }
        public DateTime Date { get; set; }

        public MedicalRecord()
        {
            MedicalRecordID = DateTime.Now.ToString();
            Date = DateTime.Today;
        }

        public MedicalRecord(string patientID, Physician physician)
        {
            MedicalRecordID = DateTime.Now.ToString();
            PatientID = patientID;
            PhysicianID = physician.ID;
            Date = DateTime.Today;
        }

        public MedicalRecord(string physicianID, string patientID,  string problem, string diagnose, string treatment, string physicianNotes)
        {
            PatientID = patientID;
            PhysicianID = physicianID;
            Date = DateTime.Today;
            Problem = problem;
            Diagnose = diagnose;
            Treatment = treatment;
            PhysicianNotes = physicianNotes;
        }
    }
}
