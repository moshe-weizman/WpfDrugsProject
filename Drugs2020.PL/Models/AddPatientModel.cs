using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class AddPatientModel
    {
        private IBL bl;
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Sex Sex { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public void AddPatientToDb()
        {
            bl = new BLImplementation();
        }
    }
}
