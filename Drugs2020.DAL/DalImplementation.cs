using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace Drugs2020.DAL
{
    public class DalImplementation : IDal
    {
        private PharmacyContext ctx = new PharmacyContext();

#if false
        //maybe it need asinc in the calling func.
        public async void AddPatientAsync(Patient patient)
        {
            await Task.Run(() =>
            {
                ctx.Patients.Add(patient);
                ctx.SaveChanges();
            });
        }
#endif
#if false
        //maybe it need asinc in the calling func.
        public async Task<bool> AddPatientAsync(Patient patient)
        {           
            bool result =true;
            try {
                await Task.Run(() =>
                    {
                        ctx.Patients.Add(patient);
                        ctx.SaveChanges();
                    }); 
            }
            catch (Exception ex)
            { 
                result = false; 
            }
            return result;
        }
#endif
#if false
         public void AddPatient2(Patient patient)
        {
            ctx.Patients.AddAsync(patient);
            ctx.SaveChangesAsync();
        }
#endif

        #region Patient
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
            ctx.SaveChanges();
            ctx.Patients.Add(patient);
            ctx.SaveChanges();
        }
        public Patient GetPatient(string id)
        {
            return ctx.Patients.Find(id);
        }
        public List<Patient> GetAllPatients() 
        {
           return ctx.Patients.Where(s => s.FirstName != null).ToList();
        }
        #endregion

        #region Physician
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
            ctx.SaveChanges();
            ctx.Physicians.Add(physician);
            ctx.SaveChanges();
        }
        public Physician GetPhysician(string id)
        {
            return ctx.Physicians.Find(id);
        }
        public List<Physician> GetAllPhysicians() { return ctx.Physicians.Where(s => s.FirstName != null).ToList(); }

        #endregion

        #region Drug
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
            ctx.SaveChanges();
            ctx.Drugs.Add(drug);
            ctx.SaveChanges();
        }
        public Drug GetDrug(string IdCode)
        {
            return ctx.Drugs.Find(IdCode);
        }
        public List<Drug> GetAllDrugs()
        {
            return ctx.Drugs.
                 Where(s => s.IdCode != null)
               .Include(s => s.Composition).ToList();
        }
        #endregion
    }

}

