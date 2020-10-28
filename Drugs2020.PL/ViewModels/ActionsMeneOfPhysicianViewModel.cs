using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class ActionsMeneOfPhysicianViewModel: IScreenReplacementVM
    {
        private PhysicianShellViewModel physicianShellVM;

        public ActionsMeneOfPhysicianViewModel(PhysicianShellViewModel physicianShellVM)
        {
            this.physicianShellVM = physicianShellVM;
        }

        public void ReplaceScreen(Screen desiredScreen)
        {
            physicianShellVM.ReplaceUC(desiredScreen);
        }
    }
}
