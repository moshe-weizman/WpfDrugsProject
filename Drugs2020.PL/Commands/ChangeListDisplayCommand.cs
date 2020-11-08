using Drugs2020.PL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Drugs2020.PL.Commands
{
    public class ChangeListDisplayCommand : ICommand
    {
        private IChangeListDisplayVM changeListDisplayVM;

        public ChangeListDisplayCommand(IChangeListDisplayVM changeListDisplayVM)
        {
            this.changeListDisplayVM = changeListDisplayVM;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            changeListDisplayVM.ChangeListDisplay((ListsTypes)Enum.Parse(typeof(ListsTypes), parameter.ToString()));
        }
    }
}
