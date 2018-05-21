using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class HumidorSizeFiltersModel : IEqualityFilters
    {
        public HumidorSizeFiltersModel(int id = 0)
        {
            FilterName = "Size";
            Filters = DefaultFilters();

            if (id > 0 && id <= Filters.Count())
            {
                Id = id;
                Name = Filters[id].Name;
                EqualityValue = Filters[id].EqualityValue;
            }
            else
            {
                Id = 0;
                Name = "";
                EqualityValue = "";
            }
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
                { 1, new EqualityFilterModel("Large","large") },
                { 2, new EqualityFilterModel("Medium","medium") },
                { 3, new EqualityFilterModel("Small","small") },
                { 4, new EqualityFilterModel("Travel","travel") }
            };

        }

        public void Counts(SearchFiltersModel searchFilters)
        {
            var itemRepository = new ItemRepository();

            for (var i = 1; i <= Filters.Count(); i++)
            {
                var query = itemRepository.ByHumidorSize(Filters[i].EqualityValue);
                query = itemRepository.ByCategory(query, searchFilters.CategoryFilters.Name);
                if (searchFilters.PriceFilters.Id != 0)
                {
                    query = itemRepository.ByPrice(query, searchFilters.PriceFilters.Min, searchFilters.PriceFilters.Max);
                }

                Filters[i].Count = query.Count();
            }
        }

        public void Urls(SearchFiltersModel searchFilters, PagingModel paging, SortingFiltersModel sorting)
        {
            var url = "";

            for (var i = 1; i <= Filters.Count(); i++)
            {
                //default to search url
                url = Globals.SearchUrl;
                //add category filter (always set)
                url +=  "?categoryID=" + searchFilters.CategoryFilters.Id;
                //set humidor size filter when not selected
                if (searchFilters.HumidorSizeFilters.Id != i)
                {
                    url += "&humidorSizeID=" + i;
                }
                //add price filter
                if (searchFilters.PriceFilters.Id != 0)
                {
                    url += "&priceID=" + searchFilters.PriceFilters.Id;
                }
                //add paging filter
                url += "&" + paging.PagingFilters;
                //add sorting filter
                url += "&sortID=" + sorting.Id;
                //set url
                Filters[i].Url = url;
            }

        }
    }
}