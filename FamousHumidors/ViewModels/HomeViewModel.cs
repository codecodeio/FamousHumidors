using FamousHumidors.Models;
using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FamousHumidors.ViewModels
{
    public class HomeViewModel
    {
        public IQueryable<ItemModel> NewArrivals { get; set; }
        public IQueryable<ItemModel> BestSellers { get; set; }

        public HomeViewModel(IQueryable<ItemModel> newArrivals, IQueryable<ItemModel> bestSellers)
        {
            NewArrivals = newArrivals;
            BestSellers = bestSellers;
        }
        
    }
}