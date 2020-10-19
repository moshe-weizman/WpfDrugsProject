using Drugs2020.BLL.BE;




namespace Drugs2020.DAL
{
    public class DalImplementation : IDal
    {
        private PharmacyContext ctx = new PharmacyContext();

        public void AddPatient(Patient patient)
        {
            ctx.Patients.Add(patient);
            ctx.SaveChanges();
        }
        public void DeletePatient(string id)
        {
            ctx.Patients.Remove(ctx.Patients.Find(id));
            ctx.SaveChanges();
        }
        public void UpdatePatient(Patient patient)
        {
            ctx.Patients.Remove(ctx.Patients.Find(patient.ID));
            ctx.Patients.Add(patient);
            ctx.SaveChanges();
        }
        public Patient GetPatient(string id)
        {
            return ctx.Patients.Find(id);
        }

        public void AddPhysician(Physician physician)
        {
            ctx.Physicians.Add(physician);
            ctx.SaveChanges();
        }
        public void DeletePhysician(string id)
        {
            ctx.Physicians.Remove(ctx.Physicians.Find(id));
            ctx.SaveChanges();
        }
        public void UpdatePhysician(Physician physician)
        {
            ctx.Physicians.Remove(ctx.Physicians.Find(physician.ID));
            ctx.Physicians.Add(physician);
            ctx.SaveChanges();
        }
        public Physician GetPhysician(string id)
        {
            return ctx.Physicians.Find(id);
        }

        public void AddDrug(Drug drug)
        {
            ctx.Drugs.Add(drug);
            ctx.SaveChanges();
        }
        public void DeleteDrug(string id)
        {
            ctx.Drugs.Remove(ctx.Drugs.Find(id));
            ctx.SaveChanges();
        }
        public void UpdateDrug(Drug drug)
        {
            ctx.Drugs.Remove(ctx.Drugs.Find(drug.IdCode));
            ctx.Drugs.Add(drug);
            ctx.SaveChanges();
        }
        public Drug GetDrug(string IdCode)
        {
            return ctx.Drugs.Find(IdCode);
        }
    }

}

