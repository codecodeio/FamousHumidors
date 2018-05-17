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
        }

        public CategoryFiltersModel CategoryFilters { get; set; }
        public PriceFiltersModel PriceFilters { get; set; }
    }
}