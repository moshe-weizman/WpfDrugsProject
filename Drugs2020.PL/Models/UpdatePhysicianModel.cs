using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class UpdatePhysicianModel
    {
        private IBL bl;
        public Physician Physician { get; set; }

        public UpdatePhysicianModel()
        {
            this.Physician = new Physician();
            bl = new BLImplementation();
        }

        public void UpdatePhysicianInDb()
        {
            try
            {
                bl.UpdatePhysician(Physician.ID, Physician);
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex) { throw; }
        }
    }
}
