using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class LogInModel
    {       
        public Physician PhysicianUser { get; set; }
        public Admin AdminUser { get; set; } 
        private IBL bl;

        public LogInModel()
        {
            bl = new BLImplementation();
        }
        public IUser IdentifyUser(string userId)
        {
            return bl.IdentifyUser(userId);
        }
        public bool ValidatePassword(IUser user, string password)
        {
            return bl.ValidatePassword(user, password);
        }
    }
}
