using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class AddPhysicianModel
    {
        private IBL bl;
        public Physician Physician { get; set; }

        public AddPhysicianModel()
        {
            this.Physician = new Physician();
            bl = new BLImplementation();
        }

        public void AddPhysicianToDb()
        {
            bl.AddPhysician(Physician);
        }
        public bool DoesPhysicianExist()
        {
            if (bl.GetPhysician(Physician.ID) != null)
            {
                return true;
            }
            return false;
        }

        public void UpdatePhysician()
        {
            bl.UpdatePhysician(Physician.ID, Physician);
        }
    }
}
