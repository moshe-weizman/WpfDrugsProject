using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Drugs2020.BLL.BE
{
    public class ActiveIngredient
    {
        public int ID { get; set; }
        public string DrugIdCode { get; set; }
        public string Ingredient { get; set; }
        public double MgQuantity { get; set; }

        public ActiveIngredient(string drugIdCode, string ingredient, double mgQuantity)
        {
            DrugIdCode = drugIdCode;
            Ingredient = ingredient;
            MgQuantity = mgQuantity;
        }

        public ActiveIngredient() {}
    }
}
