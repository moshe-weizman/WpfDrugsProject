using Drugs2020.BLL.BE;
using System.Data.Entity;

namespace Drugs2020.DAL
{
    public class PharmacyContext : DbContext
    {
        public PharmacyContext() : base("test_29")
        {
          //Database.SetInitializer(new SeedData());
           
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Physician> Physicians { get; set; }
        public DbSet<Admin> Admins { get; set; }


        public DbSet<Drug> Drugs { get; set; }
        public DbSet<MedicalFile> MedicalFiles { get; set; }
        public DbSet<Recept> Recepts { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<ActiveIngredient> ActiveIngredients { get; set; }
    }
}

