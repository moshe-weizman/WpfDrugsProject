using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class PatientSelectionModel
    {

        private IBL bl;
        public string PatientID { get; set; }

        public PatientSelectionModel()
        {
            this.bl = new BLImplementation();
        }

        public Patient GetPatient()
        {
            return bl.GetPatient(PatientID);
        }
    }
}
