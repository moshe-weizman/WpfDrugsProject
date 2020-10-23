using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs2020.BLL.BE
{
    public class Recept
    {
        public int ReceptId { get; set; }
        public string PatientID { get; set; }
        public DateTime Date { get; set; }
        public string IdCodeOfDrug { get; set; }
        public int Quantity { get; set; }
        public int Days { get; set; }
        public DateTime TreatmentEndDate { get; set; }//לכאורה לא נצרך כי כבר יש שדה של ימים
        public DateTime ExpirationDate { get; set; }

        public Recept(string patientID)
        {
            // לממש את הID 
            PatientID = patientID;
        }

        public Recept(string patientID, int id, string idCodeOfDrug, int quantity, int days, DateTime treatmentEndDate)
        {
            PatientID = patientID;
            ReceptId = id;
            Date = DateTime.Today;
            IdCodeOfDrug = idCodeOfDrug;
            Quantity = quantity;
            Days = days;
            TreatmentEndDate = treatmentEndDate;
            ExpirationDate = Date.AddDays(Days);
        }
    }
}