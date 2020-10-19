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
        private AddPhysicianModel AddPhysicianM;

        private MainWindowViewModel containingVm;
        public AddToDbCommand AddToDbCommand { get; set; }

        public BackCommand BackCommand { get; set; }
        public Physician Physician
        {
            get { return AddPhysicianM.Physician; }
            set { AddPhysicianM.Physician = value; }
        }
        public Array SexEnumValues => Enum.GetValues(typeof(Sex));

        public AddPhysicianViewModel(MainWindowViewModel containingVm)
        {
            AddPhysicianM = new AddPhysicianModel();
            this.containingVm = containingVm;
            AddToDbCommand = new AddToDbCommand(this);
            BackCommand = new BackCommand(this);
            Physician = new Physician();
        }

        public void AddItemToDb()
        {
            AddPhysicianM.AddPhysicianToDb();
        }

        public bool ItemAlreadyExists()
        {
            return false;
        }

        public void UpdateExistingItem()
        {
            throw new NotImplementedException();
        }

        public bool UserWantsToReplaceExistingItem()
        {
            throw new NotImplementedException();
        }

        public void GoBack()
        {
            containingVm.ReplaceLeftUC(Screen.ACTIONS_MENU);
        }
    }
}
