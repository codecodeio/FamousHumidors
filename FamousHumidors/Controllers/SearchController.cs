﻿using System;
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
        private Items db = new Items();

        // GET: Search
        public ActionResult Index(int page = 1, int resultsPerPage = 8, string sort = "best", int categoryID = 1, int priceId = 0)
        {
            //category filters
            var categoryFilters = new CategoryFiltersModel(categoryID);

            //price filters
            var priceFilters = new PriceFiltersModel(priceId);

            //category counts
            var cat = "";
            var count = 0;
            var categoryCounts = new Dictionary<int, int>();
            for (var i=1; i <= categoryFilters.Filters.Count(); i++)
            {
                cat = categoryFilters.Filters[i].EqualityValue;
                count = db.Products.Where(r => r.category_id.Equals(cat)).Count();
                categoryCounts.Add(i, count);
            }
            
            //all counts
            var counts = new Dictionary<string, Dictionary<int, int>>()
            {
                {"categoryCounts", categoryCounts}
            };

            //number of items
            var numberOfItems = categoryCounts[categoryID];
            
            //paging
            var baseUrl = "/search";
            var pagingModel = new PagingModel(numberOfItems, page, resultsPerPage, sort, baseUrl);
            //in case page requested is higher than existing number of pages
            page = pagingModel.Page;

            //skip calculation
            int skip = resultsPerPage * (page - 1);

            //select where
            IQueryable<ItemBaseModel> items = db.Products.Select(r => new ItemBaseModel
            {
                Id = r.ihdnum,
                Name = r.name_cleaned,
                Brand = r.brand,
                BrandGroup = r.brandgroup,
                Image = r.image_large,
                Price = (double)r.price_sort,
                PriceMsrp = (double)r.price_srp,
                Category = r.category_id,
                Url = "/" + r.url_detail,
                VoteCount = (int)r.vote_count
            })
            .Where(r => r.Category.Equals(categoryFilters.EqualityValue));

            //order by
            switch (sort)
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
            items = items.Skip(skip).Take(resultsPerPage);

            //all search filters
            var searchFiltersModel = new SearchFiltersModel(categoryFilters,priceFilters);

            //view model
            var model = new SearchViewModel(items, pagingModel, searchFiltersModel, counts);

            return View(model);
        }
    }
}