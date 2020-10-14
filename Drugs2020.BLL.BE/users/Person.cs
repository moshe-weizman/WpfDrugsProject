using System;
using System.ComponentModel.DataAnnotations;

namespace Drugs2020.BLL.BE
{
    public abstract class Person
    {
        [Key]
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Sex Sex { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }

        public Person(string id, string fNamen, string lName, Sex sex, string phone, string email, string address, DateTime birthDate)
        {
            ID = id;
            FirstName = fNamen;
            LastName = lName;
            Sex = sex;
            Phone = phone;
            Email = email;
            Address = address;
            BirthDate = birthDate;
        }
    }
}

