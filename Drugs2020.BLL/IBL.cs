using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs2020.BLL
{
    public interface IBL
    {
        UserType IdentifyUser(string userID);
        bool AutheticatePassword(string password);
    }
}
