using Drugs2020.BLL.BE;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class VisitTheClinicViewModel
    {
        private PatientModel patientModel;
        private MainWindowViewModel containingVm;

        public VisitTheClinicViewModel(MainWindowViewModel containingVm, PatientModel patientModel)
        {
            this.patientModel = patientModel;
            this.containingVm = containingVm;
        }
    }
}
