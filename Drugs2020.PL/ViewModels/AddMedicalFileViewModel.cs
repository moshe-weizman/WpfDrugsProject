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
    class AddMedicalFileViewModel: IViewModel, IAddToDb , IGoBackScreenVM
    {
        private PatientModel patientModel;
        private MainWindowViewModel containingVm;
        public BackCommand BackCommand { get; set; }
        public AddToDbCommand AddToDbCommand { get; set; }
        public MedicalFile MedicalFile
        {
            get;
            set; 
        }
        public AddMedicalFileViewModel(MainWindowViewModel containingVm, PatientModel patientModel)
        {
            this.containingVm = containingVm;
            this.patientModel = patientModel;
            AddToDbCommand = new AddToDbCommand(this);
            BackCommand = new BackCommand(this);
            MedicalFile = new MedicalFile();


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
            patientModel.CurrentPatient.MedicalFile = MedicalFile;
            patientModel.UpdatePatient();
        }

        public void GoBack()
        {
            containingVm.ReplaceUC(Screen.SEARCH_PATIENT_SCREEN);
        }
    }
}
