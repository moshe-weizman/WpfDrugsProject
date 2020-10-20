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
        public string Problem { get; set; }
        public string Diagnose { get; set; }
        public string Treatment { get; set; }
        //public bool DrugGiven { get; set; }
        public string PhysicianNotes { get; set; }

        public MedicalRecord()
        {
        }

        public MedicalRecord(string problem, string diagnose, string treatment, string physicianNotes)
        {
         //   Date = DateTime.Today;
            Problem = problem;
            Diagnose = diagnose;
            Treatment = treatment;
            PhysicianNotes = physicianNotes;
        }
    }
}
