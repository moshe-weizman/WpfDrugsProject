using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Drugs2020.PL.ViewModels
{
    class ExistingItemDecisionViewModel
    {
        public bool Decision { get; set; }
        public ExistingItemDecisionViewModel(string itemType)
        {
            MessageBoxResult result =  MessageBox.Show(itemType + " with this ID already exists in the system. \nDo you want to override it?", itemType + " already exists", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                Decision = true;
            }
        }
    }
}
