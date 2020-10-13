using Drugs2020.PL.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged, IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IViewModel _CurrentVm;

        public IViewModel CurrentVm
        {
            get { return _CurrentVm; }
            set 
            { 
                _CurrentVm = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentVm"));
            }
        }

        public MainWindowViewModel()
        {
            CurrentVm = new LogInViewModel();
        }
    }
}
