using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class UpdatePatientModel
    {
        private IBL bl;
        public Patient Patient { get; set; }

        public UpdatePatientModel()
        {
            this.Patient = new Patient();
            bl = new BLImplementation();
        }

        public void UpdatePatientInDb()
        {
            try
            {
                bl.UpdatePatient(Patient.ID, Patient);
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex) { throw; }
        }
    }
}
