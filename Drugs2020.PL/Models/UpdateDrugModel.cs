using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class UpdateDrugModel
    {
        private IBL bl;
        public Drug Drug { get; set; }
        public List<ActiveIngredient> Ingredients { get; set; }

        public UpdateDrugModel(Drug drugToUpdate)
        {
            bl = new BLImplementation();
            this.Drug = drugToUpdate;
            this.Ingredients = bl.GetActiveIngredientsOfDrug(drugToUpdate.IdCode);
            
        }

        public void UpdateDrugInDb()
        {
            bl.UpdateDrug(Drug.IdCode, Drug);
        }

        internal void AddIngredient(ActiveIngredient ingredientToAdd)
        {
            bl.AddActiveIngredient(ingredientToAdd);
        }

        internal void RemoveIngredient(ActiveIngredient activeIngredient)
        {
            bl.DeleteActiveIngredient(activeIngredient);
        }
    }
}
