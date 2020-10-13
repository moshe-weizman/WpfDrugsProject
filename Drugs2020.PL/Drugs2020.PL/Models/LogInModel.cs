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
        private IBL bl;
        public string UserId { get; set; }
        public string Password { get; set; }
        public IUser User { get; set; }

        public LogInModel()
        {
            bl = new BLImplementation();
        }
        public IUser IdentifyUser()
        {
            return bl.IdentifyUser(UserId);
        }
        public bool ValidatePassword()
        {
            return bl.ValidatePassword(User, Password);
        }
    }
}
