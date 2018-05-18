using FamousHumidors.Models;
using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.ViewModels
{
    public class DetailViewModel
    {
        public ItemModel BaseItem { get; set; }
        public Dictionary<string,string> DetailItem { get; set; }
       
        public DetailViewModel(ItemModel baseItem, Dictionary<string, string> detailItem)
        {
            BaseItem = baseItem;
            DetailItem = detailItem;
        }
    }
}