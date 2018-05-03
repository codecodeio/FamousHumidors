using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace FamousHumidors.Models
{
    public class ItemBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string BrandGroup { get; set; }
        public string Image { get; set; }
        public double Price { get; set;  }
        public double PriceMsrp { get; set; }
        public string Category { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int AverageRating { get; set; }

        public ItemBaseModel()
        {

        }
        public ItemBaseModel(Item item)
        {
            Id = item.ihdnum;
            Name = item.name_cleaned;
            Brand = item.brand;
            BrandGroup = item.brandgroup;
            Image = item.image_large;
            Price = (double)item.price_sort;
            PriceMsrp = (double)item.price_srp;
            Category = item.category_id;
            Url = "/" + item.url_detail;
            Description = item.description_item;
            if(item.avg_rating != null)
            {
                AverageRating = (int)item.avg_rating;
            }
            else
            {
                AverageRating = 0;
            }
           
        }

        public Dictionary<string, string> ToDictionary()
        {
            var detailItem = new Dictionary<string, string>();
            PropertyInfo[] infos = GetType().GetProperties();

            foreach (PropertyInfo info in infos)
            {
                detailItem.Add(info.Name, info.GetValue(this, null).ToString());
            }
            return detailItem;
        }
    }
}