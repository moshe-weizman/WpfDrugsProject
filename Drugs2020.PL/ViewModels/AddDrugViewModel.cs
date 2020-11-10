using Drugs2020.BLL.BE;
using Drugs2020.PL.Commands;
using Drugs2020.PL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    class AddDrugViewModel : INotifyPropertyChanged, IAddToDb, IGoBackScreenVM, IViewModel, IAddIngrediantToDrug, IDelete, IBrowse
    {
        private AddDrugModel addDrugM;

        private AdminShellViewModel containingVm;
        public event PropertyChangedEventHandler PropertyChanged;
        public AddToDbCommand UpdateDbCommand { get; set; }
        public OpenFileDialogCommand FileDialogCommand { get; set; }
        public bool IsNewDrug { get; }
        public BackCommand BackCommand { get; set; }
        public AddIngredientToDrugCommand AddIngredientCommand { get; set; }
        public DeleteItemCommand DeleteIngredientCommand { get; set; }
        public Drug Drug
        {
            get { return addDrugM.Drug; }
            set { addDrugM.Drug = value; }
        }
        private string imageUrl;

        public string ImageUrl
        {
            get { return imageUrl; }
            set
            {
                imageUrl = value;
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

        public AddDrugViewModel(AdminShellViewModel containingVm)
        {
            addDrugM = new AddDrugModel();
            this.containingVm = containingVm;
            UpdateDbCommand = new AddToDbCommand(this);
            IsNewDrug = true;
            BackCommand = new BackCommand(this);
            IngredientToAdd = new ActiveIngredient();
            Ingredients = new ObservableCollection<ActiveIngredient>();
            AddIngredientCommand = new AddIngredientToDrugCommand(this);
            DeleteIngredientCommand = new DeleteItemCommand(this);
            FileDialogCommand = new OpenFileDialogCommand(this);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public void AddIngredientToDrug()
        {
            IngredientToAdd.DrugIdCode = Drug.IdCode;
            Ingredients.Add(IngredientToAdd);

            addDrugM.Ingredients.Add(IngredientToAdd);
            IngredientToAdd = new ActiveIngredient();
        }
        public async void AddItemToDb()
        {
            addDrugM.Drug.ImageUrl = ImageUrl;
            containingVm.startProcessing("Adding to database");
            await Task.Run(() =>
            {
                try
                {
                    addDrugM.AddDrugToDb();
                }
                catch (ArgumentException ex)
                {
                    containingVm.ShowMessage(ex.Message);
                }
                catch (Exception ex) { containingVm.ShowMessage(ex.Message); }
                containingVm.finishProcessing("Success!");
                GoBack();
            });

        }
        public bool ItemAlreadyExists()
        {
            return addDrugM.DoesDrugExist();
        }

        public async void UpdateExistingItem()
        {
            containingVm.startProcessing("Updating on database");
            await Task.Run(() =>
            {
                try
                {
                    addDrugM.UpdateDrug();
                    containingVm.finishProcessing("Success!");
                }
                catch (ArgumentException ex)  {  containingVm.ShowMessage(ex.Message);}
                catch (Exception ex) { containingVm.ShowMessage(ex.Message); }
                
                GoBack();
            });
        }

        public void UserWantsToReplaceExistingItem()
        {
            containingVm.LetUserDecide("A drug with this ID code already exists in the system. \nDo you want to override it?", new Action(UpdateExistingItem));
        }

        public void GoBack()
        {
            containingVm.ReplaceScreen(Screen.DRUGS_MANAGEMENT);
        }

        public void RemoveItemFromDb(object ingredient)
        {
            ActiveIngredient activeIngredient = ingredient as ActiveIngredient;
            Ingredients.Remove(activeIngredient);
            addDrugM.Ingredients.Remove(activeIngredient);
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
