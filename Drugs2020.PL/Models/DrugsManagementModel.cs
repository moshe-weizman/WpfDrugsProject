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
            try
            {
                Drugs = bl.GetAllDrugs();
            }
            catch (Exception ex) { throw; }
        }

        internal void RemoveFromDb(Drug drug)
        {
            try
            {
                bl.DeleteDrug(drug.IdCode);
            }
            catch (ArgumentException) { throw; }
            catch (Exception ) { throw; }
            SyncWithDb();
        }
    }
}
