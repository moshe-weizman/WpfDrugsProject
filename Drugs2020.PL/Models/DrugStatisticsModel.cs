﻿using Drugs2020.BLL;
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
        public Dictionary<string, int> ReceptsByDate { get; set; }

        public DrugStatisticsModel()
        {
            ReceptsByDate = bl.GetDictionaryForReceptsByDate(DateTime.Parse("1/1/2020"), DateTime.Now.Date);
        }
    }
}