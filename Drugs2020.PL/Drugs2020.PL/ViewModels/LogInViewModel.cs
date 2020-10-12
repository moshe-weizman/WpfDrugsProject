using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class LogInViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private LogInModel logInModel;

        public LogInCommand LogInUserCommand { get; set; }

        public int IdUser {
            get { return logInModel.IdUser; }
            set { logInModel.IdUser = value;
                //if (PropertyChanged != null)//יכול להיות שזה לא נצרך
                //    PropertyChanged(this, new PropertyChangedEventArgs("IdUser"));
            
            } 
        }

        public string Password
        {
            get { return logInModel.Password; }
            set { logInModel.Password = value;
            //    if (PropertyChanged != null)//יכול להיות שזה לא נצרך
            //        PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public LogInViewModel()
        {
            logInModel = new LogInModel();

            LogInUserCommand = new LogInCommand(this);
        }
    }
}
