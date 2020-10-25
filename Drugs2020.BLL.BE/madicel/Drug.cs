using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Drugs2020.BLL.BE
{
    public class Drug
    {
        [Key]
        public string IdCode { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string GenericName { get; set; }
        public string ImageUrl { get; set; }

        public Drug(string idCode, string name, string manufacturer, string genericName, string imageUrl)
        {
            IdCode = idCode;
            Name = name;
            Manufacturer = manufacturer;
            GenericName = genericName;
            ImageUrl = imageUrl;
        }

        public Drug(){}
    }
}
