using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Drugs2020.BLL.BE
{
    public class Recept
    {
        public int ReceptId { get; set; }
        public string PatientID { get; set; }
        public string PhysicianID { get; set; }

        public DateTime Date { get; set; }
        public string IdCodeOfDrug { get; set; }
        public string DrugGenericName { get; set; }
        public int Quantity { get; set; }
        public int Days { get; set; }

        [NotMapped]
        public DateTime TreatmentEndDate { get
            {
                return Date.AddDays(Days).Date;
            }
        }
        public DateTime ExpirationDate { get;  }

        public Recept(string patientID, Physician physician)
        {
            // לממש את הID 
            PatientID = patientID;
            PhysicianID = physician.ID;
            Date = DateTime.Today;
            ExpirationDate = Date.AddMonths(2);

        }
        public Recept(){
            ExpirationDate = Date.AddMonths(2);

        }

        public Recept(string physicianID, string patientID, int id, string idCodeOfDrug, string drugGenericName, int quantity, int days, DateTime dateTime)
        {
            PhysicianID = physicianID;
            PatientID = patientID;
            ReceptId = id;
            Date = dateTime;
            IdCodeOfDrug = idCodeOfDrug;
            DrugGenericName = drugGenericName;
            Quantity = quantity;
            Days = days;
            ExpirationDate = Date.AddMonths(2);

        }
    }
}