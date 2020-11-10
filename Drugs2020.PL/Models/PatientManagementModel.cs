using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class PatientManagementModel
    {
        public List<Patient> Patients { get; set; }//להחליף את זה לרשימה רגילה!!!
        private IBL bl;
        public PatientManagementModel()
        {
            bl = new BLImplementation();
            SyncWithDb();
        }

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        internal void SyncWithDb()
        {
            try
            {
                Patients = bl.GetAllPatients();
            }
            catch (Exception) { throw; }
        }

        internal void RemoveFromDb(Patient patient)
        {
            try
            {
                bl.DeletePatient(patient.ID);
            }
            catch (ArgumentException) { throw; }
            catch (Exception ) { throw; }
            SyncWithDb();
        }
    }
}
