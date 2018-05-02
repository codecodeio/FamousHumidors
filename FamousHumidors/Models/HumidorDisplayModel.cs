using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class HumidorDisplayModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string BrandGroup { get; set; }
        public string Image { get; set; }
        public double Price { get; set;  }
        //public double DollarsOff { get; set; }
        public double PriceMsrp { get; set; }
        public string Category { get; set; }
    }
}