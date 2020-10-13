using Drugs2020.PL.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class MainWindowModel
    {
        private PatientSearch patientSearchUC;

        private Login loginUC;

        public MainWindowModel()
        {
            this.patientSearchUC = new PatientSearch();
            this.loginUC =new Login();
        }


    }
}
