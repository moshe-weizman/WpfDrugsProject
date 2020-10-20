using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class PatientModel
    {
        
        private IBL bl;
        public string PatientId { get; set; }
        public Patient CurrentPatient { get; set; }
      
        public PatientModel()
        {
            bl = new BLImplementation();
            CurrentPatient = new Patient();
        }

        public Patient GetPatient()
        {
            return bl.GetPatient(PatientId);
        }

        public void UpdatePatient()
        {
            bl.UpdatePatient(CurrentPatient.ID, CurrentPatient);
        }

    }
}
