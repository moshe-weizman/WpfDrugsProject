using Drugs2020.PL.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class ActionsMenuViewModel : IViewModel, IScreenReplacementVM
    {
        private MainWindowViewModel mainWindowVM;

        public ScreenReplacementCommand ScreenReplacementCommand { get; set; }
        public ActionsMenuViewModel(MainWindowViewModel mainWindowVM)
        {
            this.mainWindowVM = mainWindowVM;

            this.ScreenReplacementCommand = new ScreenReplacementCommand(this);
        }

        public void ReplaceScreen(Screen desiredScreen)
        {
            mainWindowVM.ReplaceScreen(desiredScreen);
        }
    }
}
