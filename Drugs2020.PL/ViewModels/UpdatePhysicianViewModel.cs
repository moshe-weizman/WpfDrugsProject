using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class UpdatePhysicianViewModel : IUpdateInDb, IGoBackScreenVM, IViewModel
    {
        private UpdatePhysicianModel updatePhysicianM;

        private AdminShellViewModel containingVm;
        public UpdateInDbCommand UpdateDbCommand { get; set; }
        public bool IsNewPhysician { get; }
        public BackCommand BackCommand { get; set; }
        public Physician Physician
        {
            get { return updatePhysicianM.Physician; }
            set { updatePhysicianM.Physician = value; }
        }
        public Array SexEnumValues => Enum.GetValues(typeof(Sex));

        public UpdatePhysicianViewModel(AdminShellViewModel containingVm, Physician physicianToUpdate)
        {
            updatePhysicianM = new UpdatePhysicianModel();
            this.containingVm = containingVm;
            Physician = physicianToUpdate;
            UpdateDbCommand = new UpdateInDbCommand(this);
            IsNewPhysician = false;
            BackCommand = new BackCommand(this);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public void UpdateInDb()
        {
            updatePhysicianM.UpdatePhysicianInDb();
            //containingVm.Items.Remove(containingVm.Items.Single(i => i.ID == Physician.ID));
           // containingVm.Items.Add(Physician);
            GoBack();
        }

        public void GoBack()
        {
            containingVm.ReplaceScreen(Screen.PHYSICIANS_MANAGEMENT);
        }
    }
}
