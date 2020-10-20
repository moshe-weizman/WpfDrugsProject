using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs2020.BLL.BE
{
    public class Patient : Person
    {
       // public MedicalFile MedicalFile { get; set; }
        public Patient(string id, string fNamen, string lName, Sex sex, string phone, string email, string address, DateTime birthDate) : base(id, fNamen, lName, sex, phone, email, address, birthDate)
        {
        }
        public Patient() : base()
        {
        }
    }
}
    
