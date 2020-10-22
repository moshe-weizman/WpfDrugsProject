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

        private PatientsManagementViewModel containingVm;
        public UpdateInDbCommand UpdateDbCommand { get; set; }

        public BackCommand BackCommand { get; set; }
        public Patient Patient
        {
            get { return updatePatientM.Patient; }
            set { updatePatientM.Patient = value; }
        }
        public Array SexEnumValues => Enum.GetValues(typeof(Sex));

        public UpdatePatientViewModel(PatientsManagementViewModel containingVm, Patient patientToUpdate)
        {
            updatePatientM = new UpdatePatientModel();
            this.containingVm = containingVm;
            Patient = patientToUpdate;
            UpdateDbCommand = new UpdateInDbCommand(this);
            BackCommand = new BackCommand(this);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public void UpdateInDb()
        {
            updatePatientM.UpdatePatientInDb();
            containingVm.Items.Remove(containingVm.Items.Single(i => i.ID == Patient.ID));
            containingVm.Items.Add(Patient);
            GoBack();
        }

        public void GoBack()
        {
            containingVm.ReturnToContaining();
        }
    }
}
