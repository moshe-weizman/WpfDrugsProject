using Drugs2020.PL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Drugs2020.PL.Commands
{
    public class AddToDbCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private IAddToDb addToDbViewModel;

        public AddToDbCommand(IAddToDb addToDbViewModel)
        {
            this.addToDbViewModel = addToDbViewModel;
        }
        public bool CanExecute(object parameter)
        {
            bool result = addToDbViewModel.AllFieldsFilled();           
            return result;
        }

        public void Execute(object parameter)
        {
            if (!addToDbViewModel.ItemAlreadyExists())
            {
                addToDbViewModel.AddItemToDb();
            }
            else if (addToDbViewModel.UserWantsToReplaceExistingItem())
            {
                addToDbViewModel.UpdateExistingItem();
            }
        }
    }
}
