using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class DrugStatisticsModel
    {
        private IBL bl;
        public string SelectedDrug { get; set; }
        public Dictionary<string, int> ReceptsByDate { get; set; }
        public Dictionary<string, int> ReceptsByDrug { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public DrugStatisticsModel()
        { 
            bl = new BLImplementation();
            StartDate = DateTime.Parse("1/1/2020");
            EndDate = DateTime.Now;
             ReceptsByDate = bl.GetDictionaryForReceptsByDate(StartDate, EndDate);
            SelectedDrug = "";
            ReceptsByDrug = bl.GetDictionaryForReceptsByDrug(SelectedDrug);

        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public List<Drug> GetDrugs()
        {
            return bl.GetAllDrugs();
        }
        public void RefreshReceptsByDateDiagram()
        {
            ReceptsByDate = bl.GetDictionaryForReceptsByDate(StartDate, EndDate);
        }
        public void RefreshReceptsByDrugDiagram()
        {
            ReceptsByDrug = bl.GetDictionaryForReceptsByDrug(SelectedDrug);
        }
    }
}
