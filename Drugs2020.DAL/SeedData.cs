using System;
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
            defaultSPatient.Add(new Patient() { FirstName = "Roni", LastName = "Packter", Address = "Yehoodah Hanassi 118, Elad", BirthDate = DateTime.Parse("22/4/1990"), Email = "ronipakter@gmail.com", ID = "123456789", Phone = "0547488565", Sex = Sex.MALE});
            defaultSPatient.Add(new Patient() { FirstName = "Moshe", LastName = "Weizman", Address = "Shmaya 8, Elad", BirthDate = DateTime.Parse("17/3/1960"), Email = "mosheweizman@gmail.com", ID = "987654321", Phone = "0547488565", Sex = Sex.MALE });
            defaultSPatient.Add(new Patient() { FirstName = "Ishayaho", LastName = "Pewzner", Address = "Ritva 38, Kfar Saba", BirthDate = DateTime.Parse("7/7/1997"), Email = "shaia@gmail.com", ID = "111111111", Phone = "0526655890", Sex = Sex.MALE });
            defaultSPatient.Add(new Patient() { FirstName = "Sara", LastName = "Levi", Address = "kalanit 79, Jerusalem", BirthDate = DateTime.Parse("17/3/1955"), Email = "levi3@gmail.com", ID = "222222222", Phone = "0547481115", Sex = Sex.FEMALE});
            context.Patients.AddRange(defaultSPatient);

            #endregion

            #region Admin   
            IList<Admin> defaultSAdmin = new List<Admin>();
            defaultSAdmin.Add(new Admin() { FirstName = "Admin", LastName = "Adminovski", Address = "Yehoodah Hanassi 118, Elad", BirthDate = DateTime.Parse("22/4/1990"), Email = "admin1@gmail.com", ID = "1234", Phone = "0547488565", Sex = Sex.MALE, Password = "1234" });
            context.Admins.AddRange(defaultSAdmin);
            #endregion
            #region Physician
            IList<Physician> defaultSPhysician = new List<Physician>();
            defaultSPhysician.Add(new Physician() { FirstName = "Asher", LastName = "Bardugo", Address = "Yehoodah Hanassi 40, Bney Brak", BirthDate = DateTime.Parse("22/4/1980"), Email = "asher@gmail.com", ID = "333333333", Phone = "0507228588", Sex = Sex.MALE, Password = "3"});
            defaultSPhysician.Add(new Physician() { FirstName = "Yossi", LastName = "Zaguri", Address = "HaMaapilim 6, Beytar", BirthDate = DateTime.Parse("1/11/1995"), Email = "zaguri_wpf@gmail.com", ID = "444444444", Phone = "0525293488", Sex = Sex.MALE, Password ="4" });
            context.Physicians.AddRange(defaultSPhysician);

            #endregion
            #endregion


            #region madicel 
            #region Drug   
            IList<Drug> defaultSDrugs = new List<Drug>();
            defaultSDrugs.Add(new Drug() { IdCode = "9478", Name = "Rulid", GenericName = "Roxithromycin", Manufacturer = "Sanofi", ImageUrl = ""});
            defaultSDrugs.Add(new Drug() { IdCode = "235743", Name = "Glucophage Caplets", GenericName = "Metformin Hydrochloride", Manufacturer = "Teva", ImageUrl = "" });
            defaultSDrugs.Add(new Drug() { IdCode = "212446", Name = "Azenil Capsules", GenericName = "Azithromycin", Manufacturer = "Pfizer", ImageUrl = "" });
            defaultSDrugs.Add(new Drug() { IdCode = "206812", Name = "Etopan", GenericName = "Etodolac", Manufacturer = "Taro", ImageUrl = "" });
            defaultSDrugs.Add(new Drug() { IdCode = "1111639", Name = "Copaxone", GenericName = "Glatiramer Acetate", Manufacturer = "Teva", ImageUrl = "" });
            defaultSDrugs.Add(new Drug() { IdCode = "979093", Name = "Plaquenil", GenericName = "Hydroxychloroquine Sulphate", Manufacturer = "Sanofi", ImageUrl = "" });
            defaultSDrugs.Add(new Drug() { IdCode = "1091142", Name = "Ritalin", GenericName = "Methylphenidate Hydrochloride", Manufacturer = "Novartis", ImageUrl = "" });
            defaultSDrugs.Add(new Drug() { IdCode = "731532", Name = "Advil Forte 400", GenericName = "Ibuprofen", Manufacturer = "Wyeth Lederle", ImageUrl = "" });
            defaultSDrugs.Add(new Drug() { IdCode = "314209", Name = "Rizalt Tablets", GenericName = "Rizatriptan", Manufacturer = "MSD", ImageUrl = "" });
            context.Drugs.AddRange(defaultSDrugs);
            #endregion

            #region MedicalFile   
            IList<MedicalFile> defaultSMedicalFile = new List<MedicalFile>();
            //defaultSMedicalFile.Add(new MedicalFile());
            //defaultSMedicalFile.Add(new MedicalFile());
            context.MedicalFiles.AddRange(defaultSMedicalFile);

            #endregion

            #region Recept   
            IList<Recept> defaultSRecept = new List<Recept>();
            //defaultSRecept.Add(new Recept() {/*add drug here*/ });
            //defaultSRecept.Add(new Recept() { });
            context.Recepts.AddRange(defaultSRecept);

            #endregion
            #region MedicalRecord   
            IList<MedicalRecord> defaultSMedicalRecord = new List<MedicalRecord>();
            //defaultSMedicalRecord.Add(new MedicalRecord() {/*add drug here*/ });
            //defaultSMedicalRecord.Add(new MedicalRecord() { });
            context.MedicalRecords.AddRange(defaultSMedicalRecord);

            #endregion 
            #region ActiveIngredient   
            IList<ActiveIngredient> defaultSActiveIngredient = new List<ActiveIngredient>();
            defaultSActiveIngredient.Add(new ActiveIngredient() { DrugIdCode= "9478", Ingredient= "Roxithromycin", MgQuantity = 150 });
            defaultSActiveIngredient.Add(new ActiveIngredient() { DrugIdCode = "235743", Ingredient = "Metformin Hydrochloride", MgQuantity = 850 });
            defaultSActiveIngredient.Add(new ActiveIngredient() { DrugIdCode = "212446", Ingredient = "Azithromycin", MgQuantity = 250 });
            defaultSActiveIngredient.Add(new ActiveIngredient() { DrugIdCode = "206812", Ingredient = "Etodolac", MgQuantity = 400 });
            defaultSActiveIngredient.Add(new ActiveIngredient() { DrugIdCode = "1111639", Ingredient = "Glatiramer Acetate", MgQuantity = 20 });
            defaultSActiveIngredient.Add(new ActiveIngredient() { DrugIdCode = "979093", Ingredient = "Hydroxychloroquine Sulphate", MgQuantity = 200 });
            defaultSActiveIngredient.Add(new ActiveIngredient() { DrugIdCode = "1091142", Ingredient = "Methylphenidate Hydrochloride", MgQuantity = 10 });
            defaultSActiveIngredient.Add(new ActiveIngredient() { DrugIdCode = "731532", Ingredient = "Ibuprofen", MgQuantity = 400 });
            defaultSActiveIngredient.Add(new ActiveIngredient() { DrugIdCode = "314209", Ingredient = "Rizatriptan", MgQuantity = 10 });
            context.ActiveIngredients.AddRange(defaultSActiveIngredient);

            #endregion
            #endregion
            base.Seed(context);
        }
    }
}

