using Drugs2020.BLL.BE;
using System.Data.Entity;




namespace Drugs2020.DAL
{
    public class PharmacyContext : DbContext
    {
        public PharmacyContext() : base("test_06")
        {
                               
        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Physician> Physicians { get; set; }
        public DbSet<Drug> Drugs { get; set; }
    }

}

