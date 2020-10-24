using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Drugs2020.BLL.BE
{
    public class ActiveIngredient
    {
        [Key]
        public string Ingredient { get; set; }
        public double MgQuantity { get; set; }

        public ActiveIngredient(string ingredient, double mgQuantity)
        {
            Ingredient = ingredient;
            MgQuantity = mgQuantity;
        }

        public ActiveIngredient()
        {
        }
    }
}
