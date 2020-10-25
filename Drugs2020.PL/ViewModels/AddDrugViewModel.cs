﻿using Drugs2020.BLL.BE;
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
    class AddDrugViewModel : INotifyPropertyChanged, IAddToDb, IGoBackScreenVM, IViewModel, IAddIngrediantToDrug, IDelete
    {
        private AddDrugModel addDrugM;

        private DrugsManagementViewModel containingVm;
        public event PropertyChangedEventHandler PropertyChanged;
        public AddToDbCommand UpdateDbCommand { get; set; }
        
        public bool IsNewDrug { get; }
        public BackCommand BackCommand { get; set; }
        public AddIngredientToDrugCommand AddIngredientCommand { get; set; }
        public DeleteItemCommand DeleteIngredientCommand { get; set; }
        public Drug Drug
        {
            get { return addDrugM.Drug; }
            set { addDrugM.Drug = value; }
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

        public AddDrugViewModel(DrugsManagementViewModel containingVm)
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
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public void AddIngredientToDrug()
        {
            Ingredients.Add(IngredientToAdd);
            Drug.Composition.Add(IngredientToAdd);
            IngredientToAdd = new ActiveIngredient();
        }
        public void AddItemToDb()
        {
            addDrugM.AddDrugToDb();
            containingVm.Items.Add(Drug);
            GoBack();
        }

        public bool ItemAlreadyExists()
        {
            return addDrugM.DoesDrugExist();
        }

        public void UpdateExistingItem()
        {
            containingVm.Items.Remove(containingVm.Items.Single(i => i.IdCode == Drug.IdCode));
            containingVm.Items.Add(Drug);
           
            addDrugM.UpdateDrug();
            GoBack();
        }

        public bool UserWantsToReplaceExistingItem()
        {
            ExistingItemDecisionViewModel existingItemDecision = new ExistingItemDecisionViewModel("Patient");
            return existingItemDecision.Decision;
        }

        public void GoBack()
        {
            containingVm.ReturnToContaining();
        }

        public void RemoveItemFromDb(object ingredient)
        {
            ActiveIngredient activeIngredient = ingredient as ActiveIngredient;
            Ingredients.Remove(activeIngredient);
            Drug.Composition.Remove(activeIngredient);
        }

        public bool IsUserSureToDelete()
        {
            return new DeleteDecisionViewmodel("active ingredient").Decision;
        }
    }
}