using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class DrugsManagementModel
    {
        public List<Drug> Drugs { get; set; }
        private IBL bl;
        public DrugsManagementModel()
        {
            bl = new BLImplementation();
            SyncWithDb();
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        internal void SyncWithDb()
        {
            Drugs = bl.GetAllDrugs();
        }

        internal void RemoveFromDb(Drug drug)
        {
            bl.DeleteDrug(drug.IdCode);
            SyncWithDb();
        }
    }
}
