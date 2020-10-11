using System;
using System.Collections.Generic;
using System.Text;
using Drugs2020.BLL.BE;

namespace Drugs2020.BLL
{
    public interface IBL
    {
        UserType IdentifyUser(string userId);
        bool AutheticatePassward(string password);
    }
}
