using Drugs2020.BLL.BE;




namespace Drugs2020.DAL
{
    public class DalImplementation : IDal
    {
       
        public void AddPatient(Patient patient)
        {
            using (var ctx = new PharmacyContext())
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
        public void UpdatePatient(Patient patient)
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

        public void AddPhysician(Physician physician)
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
        public void UpdatePhysician(Physician physician)
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

        public void AddDrug(Drug drug)
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
        public void UpdateDrug(Drug drug)
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

}

