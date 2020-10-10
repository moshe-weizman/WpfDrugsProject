using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs2020.BLL.BE
{
    class Patient : Person
    {
        public MedicalFile MedicalFile { get; set; }
        public Patient(int id, string fNamen, string lName, Sex sex, string phone, string email, string address, DateTime birthDate) : base(id, fNamen, lName, sex, phone, email, address, birthDate)
        {
            
        }
    }
}
