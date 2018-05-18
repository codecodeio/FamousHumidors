using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class LighterModel : ItemModel
    {
        public string Color { get; set; }

        public LighterModel(Item item) : base(item)
        {
            Color = item.acc_color;
        }
    }
}