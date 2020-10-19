using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs2020.BLL.BE
{
    public class MedicalFile
    {
        public int PatientId { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public List<MedicalRecord> MedicalRecords { get; set; }
        public List<string> ChronicIllness { get; set; }
        public List<string> DrugAllergy { get; set; }
        public List<Recept> ReceptsHistory { get; set; }
        public MedicalFile(double weight, double height, List<MedicalRecord> medicalRecords, List<string> chronicIllness, List<string> drugAllergy)
        {
            this.Weight = weight;
            this.Height = height;
           
            this.MedicalRecords = medicalRecords;
            this.ChronicIllness = chronicIllness;
            this.DrugAllergy = drugAllergy;
        }

        public MedicalFile()
        {
        }
    }
}
