using FamousHumidors.ViewModels;
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

        public int Page { get; set; }
        public int ResultsPerPage { get; set; }
        public int SortID { get; set; }
        public int CategoryID { get; set; }
        public int PriceID { get; set; }
        public int HumidorSizeID { get; set; }
        public int ColorID { get; set; }

        //public SearchFiltersModel SearchFilters { get; set; }
        //public PagingModel Paging { get; set; }
        //public SortingFiltersModel Sorting { get; set; }

        public SearchModel(int page = 1, int resultsPerPage = 8, int sortID = 1, int categoryID = 1, int priceID = 0, int humidorSizeID = 0, int colorID = 0)
        {
            if (page <= 0) throw new ArgumentException("Page must be greater than 0");

            Page = page;
            ResultsPerPage = resultsPerPage;
            SortID = sortID;
            CategoryID = categoryID;
            PriceID = priceID;
            HumidorSizeID = humidorSizeID;
            ColorID = colorID;
        }

        public SearchViewModel Search()
        {
            //category filters
            var categoryFilters = new CategoryFiltersModel(CategoryID);

            //price filters
            var priceFilters = new PriceFiltersModel(PriceID);

            //humidor size filters
            var humidorSizeFilters = new HumidorSizeFiltersModel(HumidorSizeID);

            //color filters
            var colorFilters = new ColorFiltersModel(ColorID);

            //sorting filters
            var sortingFilters = new SortingFiltersModel(SortID);

            //all search filters
            var searchFilters = new SearchFiltersModel(categoryFilters, priceFilters, humidorSizeFilters, colorFilters);

            //category counts
            categoryFilters.Counts(searchFilters);

            //price counts
            priceFilters.Counts(searchFilters);

            //humidor size counts
            if (categoryFilters.Name == "Humidors")
            {
                humidorSizeFilters.Counts(searchFilters);
            }

            //color counts
            if (categoryFilters.Name == "Lighters")
            {
                colorFilters.Counts(searchFilters);
            }

            //number of items
            var numberOfItems = categoryFilters.Filters[categoryFilters.Id].Count;

            //paging
            var paging = new PagingModel(numberOfItems, Page, ResultsPerPage, searchFilters, sortingFilters);

            //category filter urls
            categoryFilters.Urls(searchFilters, paging, sortingFilters);

            //price filter urls
            priceFilters.Urls(searchFilters, paging, sortingFilters);

            //humidor size filter urls
            humidorSizeFilters.Urls(searchFilters, paging, sortingFilters);

            //color filter urls
            colorFilters.Urls(searchFilters, paging, sortingFilters);

            //sorting urls
            sortingFilters.Urls(searchFilters, paging);

            //search
            IQueryable<ItemModel> items = SearchResults(searchFilters, paging, sortingFilters);

            //view model
            var model = new SearchViewModel(items, paging, searchFilters, sortingFilters);

            return model;
        }

        public IQueryable<ItemModel> SearchResults(SearchFiltersModel searchFilters, PagingModel paging, SortingFiltersModel sorting)
        {
            //in case page requested is higher than existing number of pages
            var page = paging.Page;

            //skip calculation
            int skip = paging.ResultsPerPage * (page - 1);

            IQueryable<ItemModel> items;

            //filter by humidor size
            if (searchFilters.CategoryFilters.Name == "Humidors" && searchFilters.HumidorSizeFilters.Id != 0)
            {
                items = itemRepository.AsItemModelByHumidorSize(searchFilters.HumidorSizeFilters.EqualityValue);
            }
            //filter by color
            else if (searchFilters.CategoryFilters.Name == "Lighters" && searchFilters.ColorFilters.Id != 0)
            {
                items = itemRepository.AsItemModelByColor(searchFilters.ColorFilters.EqualityValue);
            }
            //search items
            else
            {
                //IQueryable<ItemModel> items = itemRepository.AsItemModel();
                items = itemRepository.AsItemModel();
            }
            
            //filter by category
            items = itemRepository.ByCategory(items, searchFilters.CategoryFilters.EqualityValue);
            
            //filter by price
            if (searchFilters.PriceFilters.Id != 0)
            {
                items = itemRepository.ByPrice(items, searchFilters.PriceFilters.Min, searchFilters.PriceFilters.Max);
            }

            //order by
            switch (sorting.EqualityValue)
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
            items = items.Skip(skip).Take(paging.ResultsPerPage);

            return items;
        }

    }
}