using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class DrugStatisticsViewModel : IViewModel, INotifyPropertyChanged
    {
        private DrugStatisticsModel drugStatisticsM;
        
        public Dictionary<string, int> ReceptsByDate
        {
            get { return drugStatisticsM.ReceptsByDate; }
            set 
            { 
                drugStatisticsM.ReceptsByDate = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ReceptsByDate"));
            }
        }
        public Dictionary<string, int> ReceptsByDrug
        {
            get { return drugStatisticsM.ReceptsByDrug; }
            set 
            { 
                drugStatisticsM.ReceptsByDrug = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ReceptsByDrug"));
            }
        }
        public DateTime StartDate
        {
            get { return drugStatisticsM.StartDate; }
            set 
            { 
                drugStatisticsM.StartDate = value;
                ReceptsByDate = drugStatisticsM.RefreshReceptsByDateDiagram();
            }
        }
        public DateTime EndDate
        {
            get { return drugStatisticsM.EndDate; }
            set
            {
                drugStatisticsM.EndDate = value;
                ReceptsByDate = drugStatisticsM.RefreshReceptsByDateDiagram();
            }
        }
        public ObservableCollection<Drug> DrugCollection { get; set; }
        private Drug selectedDrug;

        public event PropertyChangedEventHandler PropertyChanged;

        public Drug SelectedDrug
        {
            get { return selectedDrug; }
            set
            {
                drugStatisticsM.SelectedDrug = value.IdCode;
                selectedDrug = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedDrug"));
                ReceptsByDrug = drugStatisticsM.RefreshReceptsByDrugDiagram();
            }
        }
    

        public DrugStatisticsViewModel()
        {
            drugStatisticsM = new DrugStatisticsModel();
            DrugCollection = new ObservableCollection<Drug>( drugStatisticsM.GetDrugs());
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}
