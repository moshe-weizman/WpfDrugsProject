using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class DrugModel
    {
        public List<Drug> DrugList { get; set; }
        private IBL bl;

        public DrugModel()
        {
            bl = new BLImplementation();
            DrugList = bl.GetAllDrugs();
        }
    }
}
