using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class AddReceptModel
    {
        private IBL bl;
        public Recept Recept { get; set; }

        public AddReceptModel(string id)
        {
            bl = new BLImplementation();
            Recept = new Recept(id);
        }

        internal void AddRecept()
        {
            bl.AddRecept(Recept);
        }

        internal bool ReceptAlreadyExists()
        {
            return false;//צריך לממש את זה!!!
        }
    }
}
