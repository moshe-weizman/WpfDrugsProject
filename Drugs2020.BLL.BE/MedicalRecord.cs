using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs2020.BLL.BE
{
    class MedicalRecord
    {
        public DateTime Date { get; }
        public string Problem { get; set; }
        public string Diagnose { get; set; }
        public string Treatment { get; set; }
        //public bool DrugGiven { get; set; }
        public string PhysicianNotes { get; set; }

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
