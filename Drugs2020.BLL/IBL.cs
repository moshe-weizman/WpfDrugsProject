using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs2020.BLL
{
   public interface IBL
    {
         bool ValidatePassword(IUser user, string password);

         IUser IdentifyUser(string userID);

        Patient GetPatient(string ID);
    }
}
