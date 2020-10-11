using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs2020.BLL.BE
{
    class Admin:Person
    {
        public string Password { get; set; }
        public Admin(int id, string fName, string lName, string phone, Sex sex, string email, string password, string address, DateTime birthDate) : base(id, fName, lName, sex, phone, email, address, birthDate)
        {
            Password = password;
        }
    }
}
