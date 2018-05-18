using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class SearchModel
    {
        private ItemRepository itemRepository = new ItemRepository();

        public SearchFiltersModel SearchFilters { get; set; }
        public PagingModel Paging { get; set; }

        public SearchModel(SearchFiltersModel searchFilters, PagingModel paging)
        {
            SearchFilters = searchFilters;
            Paging = paging;
        }

        public IQueryable<ItemModel> Search()
        {
            //in case page requested is higher than existing number of pages
            var page = Paging.Page;

            //skip calculation
            int skip = Paging.ResultsPerPage * (page - 1);

            //search items
            IQueryable<ItemModel> items = itemRepository.AsItemModel();

            //filter by category
            items = itemRepository.ByCategory(items, SearchFilters.CategoryFilters.EqualityValue);
            
            //filter by price
            if (SearchFilters.PriceFilters.Id != 0)
            {
                items = itemRepository.ByPrice(items, SearchFilters.PriceFilters.Min, SearchFilters.PriceFilters.Max);
            }

            //order by
            switch (Paging.Sort)
            {
                case "priceAsc":
                    items = items.OrderBy(r => r.Price).ThenBy(r => r.Name);
                    break;
                case "priceDesc":
                    items = items.OrderByDescending(r => r.Price).ThenBy(r => r.Name);
                    break;
                case "nameAsc":
                    items = items.OrderBy(r => r.Name).ThenBy(r => r.Price);
                    break;
                case "nameDesc":
                    items = items.OrderByDescending(r => r.Name).ThenBy(r => r.Price);
                    break;
                default:
                    items = items.OrderByDescending(r => r.VoteCount).ThenBy(r => r.Name);
                    break;
            }

            //skip, take
            items = items.Skip(skip).Take(Paging.ResultsPerPage);

            return items;
        }

    }
}