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

        private AdminShellViewModel containingVm;
        public AddToDbCommand UpdateDbCommand { get; set; }
        public bool IsNewPhysician { get;}
        public BackCommand BackCommand { get; set; }
        public Physician Physician
        {
            get { return addPhysicianM.Physician; }
            set { addPhysicianM.Physician = value; }
        }
        public Array SexEnumValues => Enum.GetValues(typeof(Sex));

        public AddPhysicianViewModel(AdminShellViewModel containingShellVm)
        {
            addPhysicianM = new AddPhysicianModel();
            this.containingVm = containingShellVm;
            UpdateDbCommand = new AddToDbCommand(this);
            IsNewPhysician = true;
            BackCommand = new BackCommand(this);
            Physician = new Physician();
        }

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public async void AddItemToDb()
        {
            containingVm.startProcessing("Adding to database");
            await Task.Run(() =>
            {
                try
                {
                    addPhysicianM.AddPhysicianToDb();
                }
                catch (ArgumentException ex)
                {
                    containingVm.ShowMessage(ex.Message);
                }
                catch (Exception ex)
                {
                    containingVm.ShowMessage(ex.Message);
                }
                containingVm.finishProcessing("Success!");
                GoBack();
            });
        }

        public bool ItemAlreadyExists()
        {
            return addPhysicianM.DoesPhysicianExist();
        }

        public async void UpdateExistingItem()
        {
            containingVm.startProcessing("Updating on database");
            await Task.Run(() =>
            {
                try
                {
                    addPhysicianM.UpdatePhysician();
                    containingVm.finishProcessing("Success!");
                }
                catch (ArgumentException ex) { containingVm.ShowMessage(ex.Message); }
                catch (Exception ex) { containingVm.ShowMessage(ex.Message); }
                
                GoBack();
            });
        }

        public void UserWantsToReplaceExistingItem()
        {
            containingVm.LetUserDecide("A physician with this ID already exists in the system. \nDo you want to override it?", new Action(UpdateExistingItem));
        }

        public void GoBack()
        {
            containingVm.ReplaceScreen(Screen.PHYSICIANS_MANAGEMENT);
        }
    }
}
