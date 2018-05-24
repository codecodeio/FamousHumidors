using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class ColorFiltersModel : IEqualityFilters
    {
        public ColorFiltersModel(int id = 0)
        {
            FilterName = "Color";
            Filters = DefaultFilters();
            CreateFilterList();

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
        public List<string> FiltersList { get; set; }
        public Dictionary<int, EqualityFilterModel> DefaultFilters()
        {
            return new Dictionary<int, EqualityFilterModel>()
            {
                { 1, new EqualityFilterModel("Black") },
                { 2, new EqualityFilterModel("Blue") },
                { 3, new EqualityFilterModel("Brown") },
                { 4, new EqualityFilterModel("Clear") },
                { 5, new EqualityFilterModel("Metal") },
                { 6, new EqualityFilterModel("Gray") },
                { 7, new EqualityFilterModel("Green") },
                { 8, new EqualityFilterModel("Orange") },
                { 9, new EqualityFilterModel("Other") },
                { 10, new EqualityFilterModel("Pink") },
                { 11, new EqualityFilterModel("Red") },
                { 12, new EqualityFilterModel("White") },
                { 13, new EqualityFilterModel("Yellow") }
            };

        }
        private List<string> CreateFilterList()
        {
            List<string> filtersList = new List<string>();

            for (var i=1; i<=Filters.Count(); i++)
            {
                filtersList.Add(Filters[i].EqualityValue);
            }

            return filtersList;
        }

        public void Counts(SearchFiltersModel searchFilters)
        {
            var itemRepository = new ItemRepository();

            for (var i = 1; i <= Filters.Count(); i++)
            {
                var query = itemRepository.ByColor(Filters[i].EqualityValue);
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
                url += "?categoryID=" + searchFilters.CategoryFilters.Id;
                //set color filter when not selected
                if (searchFilters.ColorFilters.Id != i)
                {
                    url += "&colorID=" + i;
                }
                //add humidor size filter
                if (searchFilters.HumidorSizeFilters.Id != 0)
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