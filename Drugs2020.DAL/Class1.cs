using Drugs2020.BLL.BE;
using System.Data.Entity;




namespace Drugs2020.DAL
{
    public class Program
    {
        public void SavePatient(Patient patient) {
            using ( var ctx = new PharmacyContext())
            {
                ctx.Patients.Add(patient);
                ctx.SaveChanges();
            }
        }
        public void DeletePatient(string id)
        {
            using (var ctx = new PharmacyContext())
            {
               ctx.Patients.Remove(ctx.Patients.Find(id));
                ctx.SaveChanges();
            }
        }
        public void UpdataPatient(Patient patient)
        {
            using (var ctx = new PharmacyContext())
            {
                ctx.Patients.Remove(ctx.Patients.Find(patient.ID));
                ctx.Patients.Add(patient);
                ctx.SaveChanges();
            }
        }
        public Patient GetPatient(string id)
        {
            using (var ctx = new PharmacyContext())
            {
               return ctx.Patients.Find(id);
            }
        }

        public void SavePhysician(Physician physician)
        {
            using (var ctx = new PharmacyContext())
            {
                ctx.Physicians.Add(physician);
                ctx.SaveChanges();
            }
        }
        public void DeletePhysician(string id)
        {
            using (var ctx = new PharmacyContext())
            {
                ctx.Physicians.Remove(ctx.Physicians.Find(id));
                ctx.SaveChanges();
            }
        }
        public void UpdataPhysician(Physician physician)
        {
            using (var ctx = new PharmacyContext())
            {
                ctx.Physicians.Remove(ctx.Physicians.Find(physician.ID));
                ctx.Physicians.Add(physician);
                ctx.SaveChanges();
            }
        }
        public Physician GetPhysician(string id)
        {
            using (var ctx = new PharmacyContext())
            {
                return ctx.Physicians.Find(id);
            }
        }

        public void SaveDrug(Drug drug)
        {
            using (var ctx = new PharmacyContext())
            {
                ctx.Drugs.Add(drug);
                ctx.SaveChanges();
            }
        }
        public void DeleteDrug(string id)
        {
            using (var ctx = new PharmacyContext())
            {
                ctx.Drugs.Remove(ctx.Drugs.Find(id));
                ctx.SaveChanges();
            }
        }
        public void UpdataDrug(Drug drug)
        {
            using (var ctx = new PharmacyContext())
            {
                ctx.Drugs.Remove(ctx.Drugs.Find(drug.IdCode));
                ctx.Drugs.Add(drug);
                ctx.SaveChanges();
            }
        }
        public Drug GetDrug(string IdCode)
        {
            using (var ctx = new PharmacyContext())
            {
                return ctx.Drugs.Find(IdCode);
            }
        }
    }


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

