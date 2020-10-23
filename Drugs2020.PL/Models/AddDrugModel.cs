using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class AddDrugModel
    {
        private IBL bl;
        public Drug Drug { get; set; }

        public AddDrugModel()
        {
            this.Drug = new Drug();

            bl = new BLImplementation();
        }

        public void AddDrugToDb()
        {
            bl.AddDrug(Drug);
        }

        public bool DoesDrugExist()
        {
            if (bl.GetPatient(Drug.IdCode) != null)
            {
                return true;
            }
            return false;
        }

        public void UpdateDrug()
        {
            bl.UpdateDrug(Drug.IdCode, Drug);
        }
    }
}

