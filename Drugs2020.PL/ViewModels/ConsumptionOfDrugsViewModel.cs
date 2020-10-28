using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Drugs2020.PL.ViewModels
{
    class ConsumptionOfDrugsViewModel: IViewModel, IGoBackScreenVM
    {
        private MedicalFileModel medicalFileModel;
        public ObservableCollection<Recept> DrugsPreviouslyTaken { get; }
        public ObservableCollection<Recept> DrugsTake { get; set; }
        public BackCommand BackCommand { get; set; }

        private PhysicianShellViewModel containingVm;
        public ConsumptionOfDrugsViewModel(PhysicianShellViewModel containingVm, string patientId)
        {
            medicalFileModel = new MedicalFileModel(patientId);
            this.containingVm = containingVm;
            DrugsPreviouslyTaken = new ObservableCollection<Recept>(medicalFileModel.AllRecepts.Where(x=> x.TreatmentEndDate < DateTime.Now));
            DrugsTake = new ObservableCollection<Recept>(medicalFileModel.AllRecepts.Where(x => x.TreatmentEndDate >= DateTime.Now));
            BackCommand = new BackCommand(this);
        }

        public void GoBack()
        {
            containingVm.ReplaceScreen(Screen.ADD_MEDICAL_FILE);
        }
    }
}
