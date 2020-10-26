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
            //var testRoniKingWooYeah = bl.GetDictionaryForReceptsByDate(DateTime.Parse("1/1/2020"), DateTime.Now.Date);
        }

        public void IdentifyUser()
        {
            User = bl.IdentifyUser(UserId);
        }
        public bool ValidatePassword()
        {
            return bl.ValidatePassword(User, Password);
        }

    }
}
