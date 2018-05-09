using FamousHumidors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using FamousHumidors.ViewModels;

namespace FamousHumidors.Controllers
{
    public class SearchController : Controller
    {
        private const string Humidor_Pref = "HU";
        private const string Hygrometer_Pref = "HY";
        private const string Lighter_Pref = "LG";
        private Items db = new Items();

        // GET: Search
        public ActionResult Index(int page = 1, int resultsPerPage = 8, string sort = "best")
        {
            int skip = resultsPerPage * (page - 1);

            var numberOfItems =
                (from r in db.Products
                 orderby r.margin descending
                 where r.pref == Humidor_Pref
                 select r
                ).Count();

            IQueryable<ItemBaseModel> items;
            switch (sort)
            {
                default:
                    items =
                    (from r in db.Products
                     orderby r.margin descending
                     where r.pref == Humidor_Pref
                     select r
                    )
                    .OrderBy(r => r.vote_count)
                    .Skip(skip)
                    .Take(resultsPerPage)
                    .Select(r => new ItemBaseModel
                    {
                        Id = r.ihdnum,
                        Name = r.name_cleaned,
                        Brand = r.brand,
                        BrandGroup = r.brandgroup,
                        Image = r.image_large,
                        Price = (double)r.price_sort,
                        PriceMsrp = (double)r.price_srp,
                        Category = r.category_id,
                        Url = "/" + r.url_detail
                    });
                    break;
                case "priceAsc":
                    items =
                       (from r in db.Products
                        orderby r.margin descending
                        where r.pref == Humidor_Pref
                        select r
                       )
                       .OrderBy(r => r.price_sort)
                       .Skip(skip)
                       .Take(resultsPerPage)
                       .Select(r => new ItemBaseModel
                       {
                           Id = r.ihdnum,
                           Name = r.name_cleaned,
                           Brand = r.brand,
                           BrandGroup = r.brandgroup,
                           Image = r.image_large,
                           Price = (double)r.price_sort,
                           PriceMsrp = (double)r.price_srp,
                           Category = r.category_id,
                           Url = "/" + r.url_detail
                       });
                    break;
                case "priceDesc":
                    items =
                       (from r in db.Products
                        orderby r.margin descending
                        where r.pref == Humidor_Pref
                        select r
                       )
                       .OrderByDescending(r => r.price_sort)
                       .Skip(skip)
                       .Take(resultsPerPage)
                       .Select(r => new ItemBaseModel
                       {
                           Id = r.ihdnum,
                           Name = r.name_cleaned,
                           Brand = r.brand,
                           BrandGroup = r.brandgroup,
                           Image = r.image_large,
                           Price = (double)r.price_sort,
                           PriceMsrp = (double)r.price_srp,
                           Category = r.category_id,
                           Url = "/" + r.url_detail
                       });
                    break;
                case "nameAsc":
                    items =
                       (from r in db.Products
                        orderby r.margin descending
                        where r.pref == Humidor_Pref
                        select r
                       )
                       .OrderBy(r => r.name_cleaned)
                       .Skip(skip)
                       .Take(resultsPerPage)
                       .Select(r => new ItemBaseModel
                       {
                           Id = r.ihdnum,
                           Name = r.name_cleaned,
                           Brand = r.brand,
                           BrandGroup = r.brandgroup,
                           Image = r.image_large,
                           Price = (double)r.price_sort,
                           PriceMsrp = (double)r.price_srp,
                           Category = r.category_id,
                           Url = "/" + r.url_detail
                       });
                    break;
                case "nameDesc":
                    items =
                       (from r in db.Products
                        orderby r.margin descending
                        where r.pref == Humidor_Pref
                        select r
                       )
                       .OrderByDescending(r => r.name_cleaned)
                       .Skip(skip)
                       .Take(resultsPerPage)
                       .Select(r => new ItemBaseModel
                       {
                           Id = r.ihdnum,
                           Name = r.name_cleaned,
                           Brand = r.brand,
                           BrandGroup = r.brandgroup,
                           Image = r.image_large,
                           Price = (double)r.price_sort,
                           PriceMsrp = (double)r.price_srp,
                           Category = r.category_id,
                           Url = "/" + r.url_detail
                       });
                    break;
            }
            //items =
            //    (from r in db.Products
            //     orderby r.margin descending
            //     where r.pref == Humidor_Pref
            //     select r
            //    )
            //    .OrderBy(r => r.price_sort)
            //    .Skip(skip)
            //    .Take(resultsPerPage)
            //    .Select(r => new ItemBaseModel
            //    {
            //        Id = r.ihdnum,
            //        Name = r.name_cleaned,
            //        Brand = r.brand,
            //        BrandGroup = r.brandgroup,
            //        Image = r.image_large,
            //        Price = (double)r.price_sort,
            //        PriceMsrp = (double)r.price_srp,
            //        Category = r.category_id,
            //        Url = "/" + r.url_detail
            //    });

            var baseUrl = "/search";
            var pagingModel = new PagingModel(numberOfItems, page, resultsPerPage, sort, baseUrl);
            var model = new SearchViewModel(items, pagingModel);

            return View(model);
        }
    }
}