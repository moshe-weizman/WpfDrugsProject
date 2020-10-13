using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs2020.BLL.BE
{
    public class ActiveIngredient
    {
        public string Ingredient { get; set; }
        public double MgQuantity { get; set; }

        public ActiveIngredient(string ingredient, double mgQuantity)
        {
            Ingredient = ingredient;
            MgQuantity = mgQuantity;
        }
    }
}
