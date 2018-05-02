using FamousHumidors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FamousHumidors.ViewModels
{
    public class HomeViewModel
    {
        public IQueryable<HumidorDisplayModel> NewArrivals { get; set; }
        public IQueryable<HumidorDisplayModel> BestSellers { get; set; }

        public HomeViewModel(IQueryable<HumidorDisplayModel> newArrivals, IQueryable<HumidorDisplayModel> bestSellers)
        {
            NewArrivals = newArrivals;
            BestSellers = bestSellers;
        }
        
    }
}