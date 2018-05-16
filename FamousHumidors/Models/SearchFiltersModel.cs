using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class SearchFiltersModel
    {
        public SearchFiltersModel(CategoryFiltersModel categoryFilters)
        {
            CategoryFilters = categoryFilters;
           
        }

        public CategoryFiltersModel CategoryFilters { get; set; }
        
        //private void DefaultFilters()
        //{
        //    CategoryFilters = new Dictionary<int, string>()
        //    {
        //        { 1, "Humidors" },
        //        { 2, "Hygrometers" },
        //        { 3, "Liquids" },
        //        { 4, "Lighters" },
        //        { 5, "Cutters" },
        //        { 6, "Ashtrays" }
        //    };

        //    DbCategoryFilters = new Dictionary<string, string>()
        //    {
        //        { "Humidors", "Humidors" },
        //        { "Hygrometers", "Hygrometers" },
        //        { "Liquids", "Humidifying Liquids" },
        //        { "Lighters", "Lighters" },
        //        { "Cutters", "Cigar Cutters" },
        //        { "Ashtrays", "Ashtrays" }
        //    };

        //    PriceFilters = new Dictionary<int, string>()
        //    {
        //        { 10,"0-10" },
        //        { 25,"11-25" },
        //        { 50,"26-50" },
        //        { 75,"51-75" },
        //        { 100,"76-100" },
        //        { 9999,"101+" }
        //    };
        //}

        //public string DbCategory(int index)
        //{
        //    return DbCategoryFilters[CategoryFilters[index]];
        //}
    }
}