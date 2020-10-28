using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs2020.BLL.BE
{
    public class Physician : Person, IUser
    {
        //   public int EmployeeID { get; set; }

        public string Password { get; set; }
        public Physician(string id, string fName, string lName, Sex sex, string phone,  string email, string password, string address, DateTime birthDate) : base(id, fName, lName, sex, phone, email, address, birthDate)
        {
            //  EmployeeID = employeeID;
            Password = password;
        }

        public Physician() : base() { }

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public string GetPassword()
        {
            return Password;
        }

        public string GetName()
        {
            return FirstName + " " + LastName;
        }
    }
}