using System.Collections.Generic;
using System.Data.Entity;
using Drugs2020.BLL.BE;

//https://www.entityframeworktutorial.net/code-first/seed-database-in-code-first.aspx

namespace Drugs2020.DAL
{
    class SeedData : DropCreateDatabaseAlways<PharmacyContext>
    {
        protected override void Seed(PharmacyContext context)
        {
            #region user
            #region Patient   

            IList<Patient> defaultSPatient = new List<Patient>();
            defaultSPatient.Add(new Patient() { /*add Patient here*/ });
            defaultSPatient.Add(new Patient() { });
            context.Patients.AddRange(defaultSPatient);

            #endregion

            #region Physician
            IList<Physician> defaultSPhysician = new List<Physician>();
            defaultSPhysician.Add(new Physician() { /*add Patient here*/ });
            defaultSPhysician.Add(new Physician() { });
            context.Physicians.AddRange(defaultSPhysician);

            #endregion
            #endregion


            #region madicel 
            #region Drug   
            IList<Drug> defaultSDrugs = new List<Drug>();
            defaultSDrugs.Add(new Drug() {/*add drug here*/ });
            defaultSDrugs.Add(new Drug() { });
            context.Drugs.AddRange(defaultSDrugs);
            #endregion

            #region MedicalFile   
            IList<MedicalFile> defaultSMedicalFile = new List<MedicalFile>();
            defaultSMedicalFile.Add(new MedicalFile() {/*add drug here*/ });
            defaultSMedicalFile.Add(new MedicalFile() { });
            context.MedicalFiles.AddRange(defaultSMedicalFile);

            #endregion

            #region Recept   
            IList<Recept> defaultSRecept = new List<Recept>();
            defaultSRecept.Add(new Recept() {/*add drug here*/ });
            defaultSRecept.Add(new Recept() { });
            context.Recepts.AddRange(defaultSRecept);

            #endregion
            #region MedicalRecord   
            IList<MedicalRecord> defaultSMedicalRecord = new List<MedicalRecord>();
            defaultSMedicalRecord.Add(new MedicalRecord() {/*add drug here*/ });
            defaultSMedicalRecord.Add(new MedicalRecord() { });
            context.MedicalRecords.AddRange(defaultSMedicalRecord);

            #endregion 
            #region ActiveIngredient   
            IList<ActiveIngredient> defaultSActiveIngredient = new List<ActiveIngredient>();
            defaultSActiveIngredient.Add(new ActiveIngredient() {/*add drug here*/ });
            defaultSActiveIngredient.Add(new ActiveIngredient() { });
            context.ActiveIngredients.AddRange(defaultSActiveIngredient);

            #endregion
            #endregion
            base.Seed(context);
        }
    }
}

