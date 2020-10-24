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
        public DateTime Date { get; set; }
        public string IdCodeOfDrug { get; set; }
        public string DrugGenericName { get; set; }
        public int Quantity { get; set; }
        public int Days { get; set; }
        [NotMapped]
        public DateTime TreatmentEndDate { get
            {
                return Date.AddDays(Days);
            }
        }
        public DateTime ExpirationDate { get; set; }

        public Recept(string patientID)
        {
            // לממש את הID 
            PatientID = patientID;
        }

        public Recept(string patientID, int id, string idCodeOfDrug, string drugGenericName, int quantity, int days, DateTime treatmentEndDate)
        {
            PatientID = patientID;
            ReceptId = id;
            Date = DateTime.Today;
            IdCodeOfDrug = idCodeOfDrug;
            DrugGenericName = drugGenericName;
            Quantity = quantity;
            Days = days;
            TreatmentEndDate = treatmentEndDate;
            ExpirationDate = Date.AddDays(Days);
        }
    }
}