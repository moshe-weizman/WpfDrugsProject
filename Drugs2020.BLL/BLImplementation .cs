using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs2020.BLL
{
    public class BLImplementation : IBL
    {
        ///
        public bool ValidatePassword(IUser user, string password)
        {
            bool result = false;
            if (user.GetPassword() == password)
            {
                result = true;
            }
            return result;
        }

        public IUser IdentifyUser(string userID)
        {

            return new Physician("1234", "Mose", "Weizman", "0545678990", Sex.MALE, @"Moshe@gmail.com", "1234", "Elad", DateTime.Parse("12/10/1985"), SpecializationType.FAMILY_PHYSICIAN);
        }
    }
}
