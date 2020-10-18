using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class AddMedicalFileViewModel: IViewModel, IAddToDb , IGoBackScreenVM
    {
        private MainWindowViewModel containingVm;
        public BackCommand BackCommand { get; set; }
        public AddToDbCommand AddToDbCommand { get; set; }
        public Patient CurrentPatient { 
            get { return containingVm.MainWindowM.Patient; } 
            set { containingVm.MainWindowM.Patient = value; } 
        }
        public AddMedicalFileViewModel(MainWindowViewModel containingVm)
        {
            this.containingVm = containingVm;
            AddToDbCommand = new AddToDbCommand(this);
            BackCommand = new BackCommand(this);
        }

        public void AddItemToDb()
        {
            throw new NotImplementedException();
        }

        public bool ItemAlreadyExists()
        {
            return true;//האם צריך לעשות בדיקה למשהו שלכאורה אם הגענו עד לשלב הזה צריך להית קיים. אני חושב שכן מריך לעשות כרגע לא עשיתי.
        }

        public bool UserWantsToReplaceExistingItem()
        {
            return true;
        }

        public void UpdateExistingItem()
        {
            containingVm.MainWindowM.UpdatePatient();
        }

        public void GoBack()
        {
            containingVm.ReplaceLeftUC(Screen.SEARCH_PATIENT_SCREEN);
        }
    }
}
