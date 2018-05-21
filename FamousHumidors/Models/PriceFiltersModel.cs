using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class PriceFiltersModel : IMinMaxFilters
    {
        public PriceFiltersModel(int id = 0)
        {
            FilterName = "Price";
            Filters = DefaultFilters();
            if (id > 0 && id <= Filters.Count())
            {
                Id = id;
                Name = Filters[id].Name;
                Min = Filters[id].Min;
                Max = Filters[id].Max;
            }
            else
            {
                Id = 0;
                Name = "";
                Min = 0;
                Max = 0;
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FilterName { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public Dictionary<int, MinMaxFilterModel> Filters { get; set; }
        
        public Dictionary<int, MinMaxFilterModel> DefaultFilters()
        {
            return new Dictionary<int, MinMaxFilterModel>()
            {
                { 1, new MinMaxFilterModel("0 - 10",0,10) },
                { 2, new MinMaxFilterModel("11 - 25",11,25) },
                { 3, new MinMaxFilterModel("26 - 50",26,50) },
                { 4, new MinMaxFilterModel("51 - 75",51,75) },
                { 5, new MinMaxFilterModel("76 - 100",76,100) },
                { 6, new MinMaxFilterModel("101+",101,9999) }
            };
        }

        public void Counts(SearchFiltersModel searchFilters)
        {
            var itemRepository = new ItemRepository();
            for (var i = 1; i <= Filters.Count(); i++)
            {
                var query = itemRepository.ByPrice(Filters[i].Min, Filters[i].Max);
                query = itemRepository.ByCategory(query, searchFilters.CategoryFilters.EqualityValue);

                Filters[i].Count = query.Count();
            }
        }

        public void Urls(SearchFiltersModel searchFilters, PagingModel paging)
        {
            var url = "";
            
            for (var i = 1; i <= Filters.Count(); i++)
            {
                //default to search url
                url = Globals.SearchUrl;
                //set price filiter when not selected
                if (searchFilters.PriceFilters.Id != i)
                {
                    url = url + "?priceID=" + i;
                }
                //add category filter
                if (searchFilters.CategoryFilters.Id != 0)
                {
                    if (url == Globals.SearchUrl)
                    {
                        url += "?categoryID=" + searchFilters.CategoryFilters.Id;
                    }
                    else
                    {
                        url += "&categoryID=" + searchFilters.CategoryFilters.Id;
                    }
                    
                }
                //add paging filters
                if (url == Globals.SearchUrl)
                {
                    url += "?" + paging.PagingFilters;
                }
                else
                {
                    url += "&" + paging.PagingFilters;
                }
                //set url
                Filters[i].Url = url;
            }

        }
    }
}