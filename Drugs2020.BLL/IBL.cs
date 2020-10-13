using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs2020.BLL
{
   public interface IBL
    {
         bool AutheticatePassword(string password);

         UserType IdentifyUser(string userID);
    }
}
