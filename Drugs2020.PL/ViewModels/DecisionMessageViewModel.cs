using Drugs2020.PL.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class DecisionMessageViewModel : IDecide
    {
        public string Message { get; set; }
        public bool IsMessageShown { get; set; }
        public DecisionCommand DecisionCommand { get; set; }
        private Action action;
        private Action noAction;
        public DecisionMessageViewModel(string message, Action action)
        {
            Message = message;
            DecisionCommand = new DecisionCommand(this);
            IsMessageShown = true;
            this.action = action;
        }
        public DecisionMessageViewModel(string message, Action yesAction, Action noAction)
        {
            Message = message;
            DecisionCommand = new DecisionCommand(this);
            IsMessageShown = true;
            this.action = yesAction;
            this.noAction = noAction;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~`
        public void ExecuteDecision(bool decision)
        {
            if (decision == true)
            {
                action();
            }
            else if (noAction != null)
            {
                noAction();
            }
            IsMessageShown = false;
        }
    }
}
