using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class PhysicianShellModel
    {
        
        private IBL bl;        
        public Patient CurrentPatient { get; set; }

        public PhysicianShellModel()
        {
            bl = new BLImplementation();
            this.CurrentPatient = new Patient();
        }

        public PhysicianShellModel(string id)
        {
            bl = new BLImplementation();
            this.CurrentPatient = bl.GetPatient(id);
        }

        public void GetPatient(string id)
        {
            CurrentPatient = bl.GetPatient(id);
            if (CurrentPatient == null)//exception instead?
            {
                return;
            }
        }

        public void UpdatePatient()
        {
            bl.UpdatePatient(CurrentPatient.ID, CurrentPatient);
        }

       

       

     
       
    }
}
