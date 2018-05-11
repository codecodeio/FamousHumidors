using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products
{
    public class HumidorModel : AbstractItemBaseModel
    {
        public int Capacity { get; set; }
        public string Color { get; set; }
        public string Dimensions { get; set; }
        public string Material { get; set; }
        public string Size { get; set; }
        public int Trays { get; set; }
        public bool Hygrometer { get; set; }

        public HumidorModel(Item item) : base(item)
        {
            
            Capacity = (int)item.humidor_capacity;
            Color = item.humidor_color;
            Dimensions = String.Format("{0:N1}",item.humidor_width) + "W x " + String.Format("{0:N1}", item.humidor_length) + "H x " + String.Format("{0:N1}", item.humidor_depth) + "D";
            Material = item.humidor_material;
            Size = item.humidor_size;
            Trays = (int)item.humidor_trays;
            if (item.hygrometer_included == 1)
            {
                Hygrometer = true;
            }
            else { 
                Hygrometer = false;
           }
        }
        
    }
}