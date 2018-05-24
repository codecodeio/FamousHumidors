using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class SearchFiltersModel
    {
        public SearchFiltersModel(CategoryFiltersModel categoryFilters, PriceFiltersModel priceFilters, HumidorSizeFiltersModel humidorSizeFilters, ColorFiltersModel colorFilters)
        {
            CategoryFilters = categoryFilters;
            PriceFilters = priceFilters;
            HumidorSizeFilters = humidorSizeFilters;
            ColorFilters = colorFilters;
            
            CalculateFiltersUrl();
        }

        public CategoryFiltersModel CategoryFilters { get; set; }
        public PriceFiltersModel PriceFilters { get; set; }
        public HumidorSizeFiltersModel HumidorSizeFilters { get; set; }
        public ColorFiltersModel ColorFilters { get; set; }
        public string FiltersUrl { get; set; }

        private void CalculateFiltersUrl()
        {
            FiltersUrl = "";

            FiltersUrl = "categoryID=" + CategoryFilters.Id;
            
            if (PriceFilters.Id != 0)
            {
                FiltersUrl += "&priceID=" + PriceFilters.Id;
            }

            if (CategoryFilters.Name == "Humidors" && HumidorSizeFilters.Id != 0)
            {
                FiltersUrl += "&humidorSizeID=" + HumidorSizeFilters.Id;
            }

            if (ColorFilters.Id != 0)
            {
                FiltersUrl += "&colorID=" + ColorFilters.Id;
            }
        }
    }
}