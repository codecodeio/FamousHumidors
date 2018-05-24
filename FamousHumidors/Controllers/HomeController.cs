using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using FamousHumidors.Models;
using FamousHumidors.ViewModels;
using Products;

namespace FamousHumidors.Controllers
{
    public class HomeController : Controller
    {
        private const string Humidor_Pref = "HU";
        private const string Hygrometer_Pref = "HY";
        private const string Lighter_Pref = "LG";
        private Items db = new Items();

        [OutputCache(CacheProfile = Globals.CacheDuration, Location = OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            var humidors =
               (from r in db.Products
                orderby r.margin descending
                where r.pref == Humidor_Pref
                select r
               )
               .Select(r => new ItemModel
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
               })
               .Take(5);

            var hygrometers =
               (from r in db.Products
                orderby r.ihdnum descending
                where r.pref == Hygrometer_Pref
                select r
               )
               .Select(r => new ItemModel
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
               })
               .Take(5);

            var lighters =
               (from r in db.Products
                orderby r.margin descending
                where r.pref == Lighter_Pref
                select r
               )
               .Select(r => new ItemModel
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
               })
               .Take(5);

            var newArrivals = humidors.Union(hygrometers).Union(lighters);

            var bestSellers =
              (from r in db.Products
               where (r.pref == Humidor_Pref || r.pref == Hygrometer_Pref || r.pref == Lighter_Pref) && r.avg_rating > 80
               orderby r.vote_count descending
               select r
              )
              .Select(r => new ItemModel
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
              })
              .Take(10);

            var homeViewModel = new HomeViewModel(newArrivals, bestSellers);

            //var homeViewModel = new HomeViewModel
            //{
            //    NewArrivals = newArrivals,
            //    BestSellers = bestSellers
            //};

            //homeViewModel.NewArrivals = newArrivals;
            //homeViewModel.BestSellers = bestSellers;

            return View(homeViewModel);
        }

        [OutputCache(CacheProfile = Globals.CacheDuration, Location = OutputCacheLocation.Server)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [OutputCache(CacheProfile = Globals.CacheDuration, Location = OutputCacheLocation.Server)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}