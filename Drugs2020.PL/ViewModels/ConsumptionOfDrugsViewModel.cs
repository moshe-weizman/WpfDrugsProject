using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class ConsumptionOfDrugsViewModel: IViewModel, IGoBackScreenVM
    {
        private MedicalFileModel medicalFileModel;
        public ObservableCollection<Drug> DrugsPreviouslyTaken { get; }
        public ObservableCollection<Drug> DrugsTake { get; set; }
        public BackCommand BackCommand { get; set; }

        private IContainingVm containingVm;
        public ConsumptionOfDrugsViewModel(IContainingVm containingVm, string patientId)
        {
            medicalFileModel = new MedicalFileModel(patientId);
            this.containingVm = containingVm;
            DrugsPreviouslyTaken = new ObservableCollection<Drug>(medicalFileModel.DrugsPreviouslyTaken);
            DrugsTake = new ObservableCollection<Drug>(medicalFileModel.DrugsTake);
            BackCommand = new BackCommand(this);
        }

        public void GoBack()
        {
                containingVm.ReturnToContaining();
        }
    }
}
