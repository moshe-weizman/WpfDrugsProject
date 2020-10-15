using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class AddPatientViewModel : IAddToDb
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Sex Sex { get; set; }
        public string Phone { get {return } set { } }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        

        public void AddItemToDb()
        {
            throw new NotImplementedException();
        }

        public bool AllFieldsFilled()
        {
            throw new NotImplementedException();
        }

        public bool ItemAlreadyExists()
        {
            throw new NotImplementedException();
        }

        public void UpdateExistingItem()
        {
            throw new NotImplementedException();
        }

        public bool UserWantsToReplaceExistingItem()
        {
            throw new NotImplementedException();
        }
    }
}
