using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Drugs2020.PL.ViewModels
{
    class DeleteDecisionViewmodel
    {
        public bool Decision { get; set; }
        public DeleteDecisionViewmodel(string itemType)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this " + itemType + " from the system?", itemType + " Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                Decision = true;
            }
        }
    }
}
