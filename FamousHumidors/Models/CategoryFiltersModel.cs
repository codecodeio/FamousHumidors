using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class CategoryFiltersModel : IEqualityFilters
    {
        public CategoryFiltersModel(int id = 1)
        {
            FilterName = "Category";
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
                { 1, new EqualityFilterModel("Humidors") },
                { 2, new EqualityFilterModel("Hygrometers") },
                { 3, new EqualityFilterModel("Liquids","Humidifying Liquids") },
                { 4, new EqualityFilterModel("Lighters") },
                { 5, new EqualityFilterModel("Cutters","Cigar Cutters") },
                { 6, new EqualityFilterModel("Ashtrays") }
            };
            
        }

        public void Counts(SearchFiltersModel searchFilters)
        {
            var itemRepository = new ItemRepository();

            for (var i = 1; i <= Filters.Count(); i++)
            {
                IQueryable<Item> query;
                if (Filters[i].Name == "Humidors" && searchFilters.HumidorSizeFilters.Id != 0)
                {
                    query = itemRepository.ByHumidorSize(searchFilters.HumidorSizeFilters.EqualityValue);
                    query = itemRepository.ByCategory(query, Filters[i].EqualityValue);
                }
                else if (Filters[i].Name == "Lighters" && searchFilters.ColorFilters.Id != 0)
                {
                    query = itemRepository.ByColor(searchFilters.ColorFilters.EqualityValue);
                    query = itemRepository.ByCategory(query, Filters[i].EqualityValue);
                }
                else
                {
                    query = itemRepository.ByCategory(Filters[i].EqualityValue);
                }
                
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
                url = url + "?categoryID=" + i;
                //add price filter
                if (searchFilters.PriceFilters.Id != 0)
                {
                    url += "&priceID=" + searchFilters.PriceFilters.Id;
                }
                //add humidor size filter
                if (Filters[i].Name == "Humidors" && searchFilters.HumidorSizeFilters.Id != 0)
                {
                    url += "&humidorSizeID=" + searchFilters.HumidorSizeFilters.Id;
                }
                //add paging filter
                url += "&" + paging.PagingFilters;
                //add sorting filters
                url += "&sortID=" + sorting.Id;
                //set url
                Filters[i].Url = url;
            }
            
        }
    }
}