using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs2020.BLL.BE
{
    public class Physician : Person, IUser
    {
      //   public int EmployeeID { get; set; }
      
        public string Password { get; set; }
        public Physician(string id, string fName, string lName, string phone, Sex sex, string email,/* int employeeID,*/ string password, string address, DateTime birthDate) : base( id,  fName,  lName, sex, phone,  email, address, birthDate)
        {
          //  EmployeeID = employeeID;
            Password = password;
        }
        public string GetPassword()
        {
            return Password;
        }

    }
}
