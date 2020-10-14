using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Drugs2020.BLL.BE
{
    public class MedicalFile
    {
        [Key]
        public int PatientId { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public List<MedicalRecord> MedicalRecords { get; }
        public List<string> ChronicIllness { get; set; }
        public List<string> DrugAllergy { get; set; }
        public List<Recept> ReceptsHistory { get; set; }
        public MedicalFile(double weight, double height, int age, List<MedicalRecord> medicalRecords, List<string> chronicIllness, List<string> drugAllergy)
        {
            this.Weight = weight;
            this.Height = height;
            this.Age = age;
            this.MedicalRecords = medicalRecords;
            this.ChronicIllness = chronicIllness;
            this.DrugAllergy = drugAllergy;
        }
    }
}