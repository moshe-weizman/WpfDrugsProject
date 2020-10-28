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
            //לא למחוק את ההערה, משמש לבדיקות קורונה במגזר הצ'רקסי
            //bl.AddDrug(new Drug() { IdCode = "19478", Name = "Rulid", GenericName = "Roxithromycin", Manufacturer = "Sanofi", ImageUrl = @"C:\Users\ronip\OneDrive\Desktop\זגורי\פרויקט\DrugsImages" });
            //Drug drug = bl.GetDrug("19478");
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
