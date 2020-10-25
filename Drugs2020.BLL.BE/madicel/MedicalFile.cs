using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Drugs2020.BLL.BE
{
    public class MedicalFile
    {
        [Key]
        public string PatientId { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public List<MedicalRecord> MedicalRecords { get; set; }
        public string ChronicIllness { get; set; }
        public string DrugAllergy { get; set; }

    //  public List<Recept> ReceptsHistory { get; set; }
        public MedicalFile(string patientId, double weight, double height, List<MedicalRecord> medicalRecords, string chronicIllness, string drugAllergy)
        {
            this.PatientId = patientId;
            this.Weight = weight;
            this.Height = height;
           
            this.MedicalRecords = medicalRecords;
            this.ChronicIllness = chronicIllness;
            this.DrugAllergy = drugAllergy;
        }

        public MedicalFile(string patientId)
        {
            PatientId = patientId;
        }

        public MedicalFile()
        {
        }
    }
}
