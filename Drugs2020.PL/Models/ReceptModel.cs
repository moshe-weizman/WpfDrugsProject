using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class ReceptModel
    {
        private IBL bl;
        public Recept Recept { get; set; }
        public List<Drug> DrugList { get; set; }
        public ReceptModel(string id)
        {
            bl = new BLImplementation();
            Recept = new Recept(id);
            DrugList = bl.GetAllDrugs();

        }

        public void AddRecept()
        {
            bl.AddRecept(Recept);
        }

        public bool ReceptAlreadyExists()
        {
            return false;//צריך לממש את זה!!!
        }
    }
}
