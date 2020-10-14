using Drugs2020.BLL.BE;
using System.Data.Entity;

namespace Drugs2020.DAL
{
    public class Program
    {
        public void SaveToReM(Patient patient) {

            using ( var ctx = new PharmacyContext())
            {
                ctx.Patients.Add(patient);
                ctx.SaveChanges();
            }
        }
    }


    public class PharmacyContext : DbContext
    {
        public PharmacyContext() : base("test_05")
        {
                               
        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Physician> Physicians { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }

}

