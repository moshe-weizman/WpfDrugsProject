using Drugs2020.BLL;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class DrugStatisticsViewModel : IViewModel
    {
        private DrugStatisticsModel drugStatisticsM;
        public string ChosenDrug
        {
            get { return drugStatisticsM.ChosenDrug; }
            set { drugStatisticsM.ChosenDrug = value; }
        }
        public Dictionary<string, int> ReceptsByDate
        {
            get { return drugStatisticsM.ReceptsByDate; }
            set { drugStatisticsM.ReceptsByDate = value; }
        }
        public Dictionary<string, int> ReceptsByDrug
        {
            get { return drugStatisticsM.ReceptsByDrug; }
            set { drugStatisticsM.ReceptsByDrug = value; }
        }
        //public Dictionary<string, int> ReceptsByDate
        //{
        //    get { return drugStatisticsM.ReceptsByDate; }
        //    set { drugStatisticsM.ReceptsByDate = value; }
        //}

        public DrugStatisticsViewModel()
        {
            drugStatisticsM = new DrugStatisticsModel();
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}
