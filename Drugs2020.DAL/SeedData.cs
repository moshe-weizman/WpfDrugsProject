using System.Collections.Generic;
using System.Data.Entity;
using Drugs2020.BLL.BE;

namespace Drugs2020.DAL
{
    class SeedData : DropCreateDatabaseAlways<PharmacyContext>
    {
            protected override void Seed(PharmacyContext context)
            {

            #region Drug   
            
            IList<Drug> defaultSDrugs = new List<Drug>();
            defaultSDrugs.Add(new Drug() {/*add drug here*/ });
            defaultSDrugs.Add(new Drug() { });
            context.Drugs.AddRange(defaultSDrugs);

            #endregion

            #region Patient   

            IList<Patient> defaultSPatient = new List<Patient>();
            defaultSPatient.Add(new Patient() { /*add Patient here*/ });
            defaultSPatient.Add(new Patient() { });
            context.Patients.AddRange(defaultSPatient);

            #endregion
            base.Seed(context);
            }
        }

    }

