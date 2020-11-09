using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class UpdateDrugViewModel : INotifyPropertyChanged, IUpdateInDb, IGoBackScreenVM, IViewModel, IAddIngrediantToDrug, IBrowse, IDelete
    {
        private UpdateDrugModel updateDrugM;
        public event PropertyChangedEventHandler PropertyChanged;

        private AdminShellViewModel containingVm;
        public UpdateInDbCommand UpdateDbCommand { get; set; }
        public bool IsNewDrug { get; }
        public BackCommand BackCommand { get; set; }
        public AddIngredientToDrugCommand AddIngredientCommand { get; set; }
        public DeleteItemCommand DeleteIngredientCommand { get; set; }
        public OpenFileDialogCommand FileDialogCommand { get; set; }
        public Drug Drug
        {
            get { return updateDrugM.Drug; }
            set { updateDrugM.Drug = value; }
        }
        private string imagUrl;

        public string ImageUrl
        {
            get { return imagUrl; }
            set 
            {
                imagUrl = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ImageUrl"));
            }
        }

        private ActiveIngredient ingredientToAdd;
        public ActiveIngredient IngredientToAdd
        {
            get { return ingredientToAdd; }
            set
            {
                ingredientToAdd = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IngredientToAdd"));
            }
        }
        public ObservableCollection<ActiveIngredient> Ingredients { get; set; }

        public UpdateDrugViewModel(AdminShellViewModel containingVm, Drug drugToUpdate)
        {
            updateDrugM = new UpdateDrugModel(drugToUpdate);
            this.containingVm = containingVm;
            UpdateDbCommand = new UpdateInDbCommand(this);
            IsNewDrug = false;
            BackCommand = new BackCommand(this);
            IngredientToAdd = new ActiveIngredient();
            Ingredients = new ObservableCollection<ActiveIngredient>(updateDrugM.Ingredients);
            AddIngredientCommand = new AddIngredientToDrugCommand(this);
            DeleteIngredientCommand = new DeleteItemCommand(this);
            FileDialogCommand = new OpenFileDialogCommand(this);
            ImageUrl = Drug.ImageUrl;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public async void UpdateInDb()
        {
            containingVm.startProcessing("Updating on database");
            await Task.Run(() =>
            {
                updateDrugM.Drug.ImageUrl = ImageUrl;
                updateDrugM.UpdateDrugInDb();
                containingVm.finishProcessing("Success!");
                GoBack();
            });
        }

        public void GoBack()
        {
            containingVm.ReplaceScreen(Screen.DRUGS_MANAGEMENT);
        }

        public void AddIngredientToDrug()
        {
            Ingredients.Add(IngredientToAdd);
            updateDrugM.AddIngredient(IngredientToAdd);
            IngredientToAdd = new ActiveIngredient();
        }

        public void RemoveItemFromDb(object ingredient)
        {
            ActiveIngredient activeIngredient = ingredient as ActiveIngredient;
            Ingredients.Remove(activeIngredient);
            updateDrugM.RemoveIngredient(activeIngredient);
        }

        public void SavePath(string path)
        {
            ImageUrl = path;
        }

        public void DeleteSelected(object ingredient)
        {
            containingVm.LetUserDecide("Are you sure you want to delete this ingredient from the system?", new Action(() => RemoveItemFromDb(ingredient)));
        }
    }
}
