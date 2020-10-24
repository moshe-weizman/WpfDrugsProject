using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class UpdateDrugModel
    {
        private IBL bl;
        public Drug Drug { get; set; }

        public UpdateDrugModel()
        {
            this.Drug = new Drug();
            bl = new BLImplementation();
        }

        public void UpdatePatientInDb()
        {
            bl.UpdateDrug(Drug.IdCode, Drug);
        }
    }
}
