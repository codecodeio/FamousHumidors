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
        public IQueryable<ItemBaseModel> NewArrivals { get; set; }
        public IQueryable<ItemBaseModel> BestSellers { get; set; }

        public HomeViewModel(IQueryable<ItemBaseModel> newArrivals, IQueryable<ItemBaseModel> bestSellers)
        {
            NewArrivals = newArrivals;
            BestSellers = bestSellers;
        }
        
    }
}