using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Drugs2020.BLL.BE
{
    public class MedicalRecord
    {
        
       // public DateTime Date { get; }
       [Key]
        public string MedicalRecordID { get; set; }
        public string PatientID { get; set; }
        public string Problem { get; set; }
        public string Diagnose { get; set; }
        public string Treatment { get; set; }
        //public bool DrugGiven { get; set; }
        public string PhysicianNotes { get; set; }
        public DateTime Date { get; set; }

        public MedicalRecord()
        {
            Date = DateTime.Today;
        }

        public MedicalRecord(string patientID)
        {
            PatientID = patientID;
            Date = DateTime.Today;
        }

        public MedicalRecord(string problem, string diagnose, string treatment, string physicianNotes)
        {
            Date = DateTime.Today;
            Problem = problem;
            Diagnose = diagnose;
            Treatment = treatment;
            PhysicianNotes = physicianNotes;
        }
    }
}
