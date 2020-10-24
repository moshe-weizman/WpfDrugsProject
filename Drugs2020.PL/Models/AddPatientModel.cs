using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Drugs2020.PL.Models
{
    class AddPatientModel
    {
        private IBL bl;
        public Patient Patient { get; set; }

        public AddPatientModel()
        {
            this.Patient = new Patient();

            bl = new BLImplementation();
        }

        public void AddPatientToDb()
        {
            bl.AddPatient(Patient);
        }

        public bool DoesPatientExist()
        {
            if (bl.GetPatient(Patient.ID) != null)
            {
                return true;
            }
            return false;
        }

        public void UpdatePatient()
        {
            bl.UpdatePatient(Patient.ID, Patient);
        }
    }
}
