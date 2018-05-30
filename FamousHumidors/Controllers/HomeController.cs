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
        [OutputCache(CacheProfile = Globals.CacheDuration, Location = OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            ItemRepository itemRepository = new ItemRepository();
            var newArrivals = itemRepository.NewArrivals();
            var bestSellers = itemRepository.BestSellers();

            var homeViewModel = new HomeViewModel(newArrivals, bestSellers);

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