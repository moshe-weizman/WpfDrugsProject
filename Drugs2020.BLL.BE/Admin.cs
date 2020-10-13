using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs2020.BLL.BE
{
    public class Admin:Person, IUser
    {
        public string Password { get; set; }
        public Admin(int id, string fName, string lName, string phone, Sex sex, string email, string password, string address, DateTime birthDate) : base(id, fName, lName, sex, phone, email, address, birthDate)
        {
            Password = password;
        }

        public string GetPassword()
        {
            return Password;
        }
    }
}
