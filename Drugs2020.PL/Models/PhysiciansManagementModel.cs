using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class PhysiciansManagementModel
    {
        public List<Physician> Physicians { get; set; }
        private IBL bl;
        public PhysiciansManagementModel()
        {
            bl = new BLImplementation();
            SyncWithDb();
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        internal void SyncWithDb()
        {
            Physicians = bl.GetAllPhysicians();
        }

        internal void RemoveFromDb(Physician physician)
        {
            bl.DeletePhysician(physician.ID);
            SyncWithDb();
        }
    }
}
