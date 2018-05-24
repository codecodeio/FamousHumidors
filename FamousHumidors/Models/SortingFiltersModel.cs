using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class SortingFiltersModel : IEqualityFilters
    {
        public SortingFiltersModel(int id = 1)
        {
            FilterName = "Sort By";
            Filters = DefaultFilters();
            if (id < 1 || id > Filters.Count())
            {
                Id = 1;
            }
            else
            {
                Id = id;
            }
            EqualityValue = Filters[Id].EqualityValue;
            Name = Filters[Id].Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FilterName { get; set; }
        public string EqualityValue { get; set; }
        public Dictionary<int, EqualityFilterModel> Filters { get; set; }

        public Dictionary<int, EqualityFilterModel> DefaultFilters()
        {
            return new Dictionary<int, EqualityFilterModel>()
            {
                { 1, new EqualityFilterModel("Best","best") },
                { 2, new EqualityFilterModel("Price","priceAsc") },
                { 3, new EqualityFilterModel("Price","priceDesc") },
                { 4, new EqualityFilterModel("Name","nameAsc") },
                { 5, new EqualityFilterModel("Name","nameDesc") }
               
            };

        }

        public void Urls(SearchFiltersModel searchFilters, PagingModel paging)
        {
            var url = "";

            for (var i = 1; i <= Filters.Count(); i++)
            {
                //default to search url
                url = Globals.SearchUrl + "?sortID=" + i;

                //add category filter (always set)
                url = url + "&categoryID=" + searchFilters.CategoryFilters.Id;
                //add price filter
                if (searchFilters.PriceFilters.Id != 0)
                {
                    url += "&priceID=" + searchFilters.PriceFilters.Id;
                }
                //add paging filter
                url += "&" + paging.PagingFilters;
                //set url
                Filters[i].Url = url;
            }

        }
    }
}