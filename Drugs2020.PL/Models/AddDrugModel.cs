using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class AddDrugModel
    {
        private IBL bl;
        public Drug Drug { get; set; }
        public List<ActiveIngredient> Ingredients { get; set; }

        public AddDrugModel()
        {
            this.Drug = new Drug();
            Ingredients = new List<ActiveIngredient>();
            bl = new BLImplementation();
        }

        public void AddDrugToDb()
        {
            try
            {
                Ingredients.ForEach(i => bl.AddActiveIngredient(i));
                bl.AddDrug(Drug);
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex) { throw; }
        }

        public bool DoesDrugExist()
        {
            return bl.DoesDrugExist(Drug.IdCode);
            
        }

        public void UpdateDrug()
        {
            try
            {
                bl.UpdateDrug(Drug.IdCode, Drug);
            }
            catch (ArgumentException) { throw; }
            catch (Exception ) { throw; }
        }
    }
}

