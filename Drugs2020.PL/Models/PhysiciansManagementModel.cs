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
            try
            {
                Physicians = bl.GetAllPhysicians();
            }
            catch (Exception ex) { throw; }
        }

        internal void RemoveFromDb(Physician physician)
        {
            try
            {
                bl.DeletePhysician(physician.ID);
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex) { throw; }
            SyncWithDb();
        }
    }
}
