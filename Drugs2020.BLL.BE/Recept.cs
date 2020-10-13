using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs2020.BLL.BE
{
    public class Recept
    {
        public DateTime Date { get; set; }
        public Drug Drug { get; set; }
        public int Quantity { get; set; }
        public int Days { get; set; }
        public DateTime TreatmentEndDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Recept(DateTime date, Drug drug, int quantity, int days, DateTime treatmentEndDate)
        {
            Date = date;
            Drug = drug;
            Quantity = quantity;
            Days = days;
            TreatmentEndDate = treatmentEndDate;
            ExpirationDate = Date.AddDays(Days);
        }
    }
}
