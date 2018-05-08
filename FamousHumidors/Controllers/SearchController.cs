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
            //var model =
            //    (from r in db.Products
            //     orderby r.margin descending
            //     where r.pref == Humidor_Pref
            //     select r
            //    )
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
            //    })
            //    .ToPagedList(page, resultsPerPage);

            Func<ItemBaseModel, Object> orderByFunc = null;
            switch (sort)
            {
                default:
                    orderByFunc = ItemBaseModel => ItemBaseModel.Name;
                    break;
                case "priceAsc":
                    orderByFunc = ItemBaseModel => ItemBaseModel.Price;
                    break;
            }

            int skip = resultsPerPage * (page - 1);

            var numberOfItems =
                (from r in db.Products
                 orderby r.margin descending
                 where r.pref == Humidor_Pref
                 select r
                ).Count();

            var items =
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

            var model = new SearchViewModel(items, numberOfItems, page, resultsPerPage, sort);

            return View(model);
        }
    }
}