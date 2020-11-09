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
    class UpdatePatientViewModel : IUpdateInDb , IGoBackScreenVM, IViewModel
    {
        private UpdatePatientModel updatePatientM;

        private AdminShellViewModel containingVm;
        public UpdateInDbCommand UpdateDbCommand { get; set; }
        public bool IsNewPatient { get; }
        public BackCommand BackCommand { get; set; }
        public Patient Patient
        {
            get { return updatePatientM.Patient; }
            set { updatePatientM.Patient = value; }
        }
        public Array SexEnumValues => Enum.GetValues(typeof(Sex));

        public UpdatePatientViewModel(AdminShellViewModel containingVm, Patient patientToUpdate)
        {
            updatePatientM = new UpdatePatientModel();
            this.containingVm = containingVm;
            Patient = patientToUpdate;
            UpdateDbCommand = new UpdateInDbCommand(this);
            IsNewPatient = false;
            BackCommand = new BackCommand(this);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public async void UpdateInDb()
        {
            containingVm.startProcessing("Updating on database");
            await Task.Run(() =>
            {
                updatePatientM.UpdatePatientInDb();
                containingVm.finishProcessing("Success!");
                GoBack();
            });
        }

        public void GoBack()
        {
            containingVm.ReplaceScreen(Screen.PATIENTS_MANAGEMENT);
        }
    }
}
