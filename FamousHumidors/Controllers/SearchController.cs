using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using FamousHumidors.ViewModels;
using Products;
using FamousHumidors.Models;

namespace FamousHumidors.Controllers
{
    public class SearchController : Controller
    {
        private ItemRepository itemRepository = new ItemRepository();
       
        // GET: Search
        public ActionResult Index(int page = 1, int resultsPerPage = 8, int sortID = 1, int categoryID = 1, int priceID = 0)
        {
            //category filters
            var categoryFilters = new CategoryFiltersModel(categoryID);

            //price filters
            var priceFilters = new PriceFiltersModel(priceID);

            //sorting filters
            var sortingFilters = new SortingFiltersModel(sortID);

            //all search filters
            var searchFilters = new SearchFiltersModel(categoryFilters, priceFilters);

            //category counts
            categoryFilters.Counts(searchFilters);
           
            //price counts
            priceFilters.Counts(searchFilters);

            //number of items
            var numberOfItems = categoryFilters.Filters[categoryFilters.Id].Count;

            //paging
            var paging = new PagingModel(numberOfItems, page, resultsPerPage, searchFilters);
            
            //category filter urls
            categoryFilters.Urls(searchFilters, paging, sortingFilters);

            //price filter urls
            priceFilters.Urls(searchFilters, paging, sortingFilters);

            //sorting urls
            sortingFilters.Urls(searchFilters, paging);

            //search
            IQueryable<ItemModel> items = new SearchModel(searchFilters,paging,sortingFilters).Search();

            //view model
            var model = new SearchViewModel(items, paging, searchFilters, sortingFilters);

            return View(model);
        }
    }
}