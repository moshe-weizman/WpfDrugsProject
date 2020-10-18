using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using Drugs2020.PL.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class MainWindowModel
    {
        private IBL bl;
        public MainWindowModel()
        {
            bl = new BLImplementation();
        }

        public IUser User { get; set; }
        public Patient Patient { get; set; }

        public void UpdatePatient()
        {
            bl.UpdatePatient(Patient.ID, Patient);
        }

        public void UpdateUser()
        {
            if (User is Physician) {//אולי לשנות ואלי לעשות CURD שמתאים לIUSER
                Physician physician = (Physician)User;
                bl.UpdatePhysician(physician.ID, physician);
            }
            else
            {
              
            }
        }
    }
}
