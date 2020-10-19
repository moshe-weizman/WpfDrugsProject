using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class AddPhysicianViewModel : IAddToDb, IGoBackScreenVM, IViewModel
    {
        private AddPhysicianModel addPhysicianM;

        private MainWindowViewModel containingVm;
        public AddToDbCommand AddToDbCommand { get; set; }

        public BackCommand BackCommand { get; set; }
        public Physician Physician
        {
            get { return addPhysicianM.Physician; }
            set { addPhysicianM.Physician = value; }
        }
        public Array SexEnumValues => Enum.GetValues(typeof(Sex));

        public AddPhysicianViewModel(MainWindowViewModel containingVm)
        {
            addPhysicianM = new AddPhysicianModel();
            this.containingVm = containingVm;
            AddToDbCommand = new AddToDbCommand(this);
            BackCommand = new BackCommand(this);
            Physician = new Physician();
        }

        public void AddItemToDb()
        {
            addPhysicianM.AddPhysicianToDb();
        }

        public bool ItemAlreadyExists()
        {
            return addPhysicianM.DoesPhysicianExist();
        }

        public void UpdateExistingItem()
        {
            addPhysicianM.UpdatePhysician();
        }

        public bool UserWantsToReplaceExistingItem()
        {
            ExistingItemDecisionViewModel existingItemDecision = new ExistingItemDecisionViewModel("Physician");
            return existingItemDecision.Decision;
        }

        public void GoBack()
        {
            containingVm.ReplaceUC(Screen.ACTIONS_MENU);
        }
    }
}
