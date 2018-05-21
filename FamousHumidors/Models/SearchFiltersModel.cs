using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class SearchFiltersModel
    {
        public SearchFiltersModel(CategoryFiltersModel categoryFilters, PriceFiltersModel priceFilters)
        {
            CategoryFilters = categoryFilters;
            PriceFilters = priceFilters;
            
            CalculateFiltersUrl();
        }

        public CategoryFiltersModel CategoryFilters { get; set; }
        public PriceFiltersModel PriceFilters { get; set; }
        public string FiltersUrl { get; set; }

        private void CalculateFiltersUrl()
        {
            FiltersUrl = "";

            FiltersUrl = "categoryID=" + CategoryFilters.Id;
            
            if (PriceFilters.Id != 0)
            {
                if(FiltersUrl != "")
                {
                    FiltersUrl += "&priceID=" + PriceFilters.Id;
                }
                else
                {
                    FiltersUrl += "priceID=" + PriceFilters.Id;
                }
            }
        }
    }
}