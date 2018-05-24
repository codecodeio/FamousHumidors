using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using FamousHumidors.ViewModels;
using Products;
using FamousHumidors.Models;
using System.Web.UI;

namespace FamousHumidors.Controllers
{
    public class SearchController : Controller
    {
        //private ItemRepository itemRepository = new ItemRepository();

        // GET: Search
        [OutputCache(CacheProfile = Globals.CacheDuration, VaryByParam = "page;resultsPerPage;sortID;categoryID;priceID;humidorSizeID;colorID", Location = OutputCacheLocation.Server)]
        public ActionResult Index(int page = 1, int resultsPerPage = 8, int sortID = 1, int categoryID = 1, int priceID = 0, int humidorSizeID = 0, int colorID = 0)
        {
            SearchModel searchModel;
            SearchViewModel model;
            ViewBag.ErrorMessage = "";

            try
            {
                searchModel = new SearchModel(page, resultsPerPage, sortID, categoryID, priceID, humidorSizeID, colorID);
                model = searchModel.Search();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                model = new SearchModel().Search();
            }

            return View(model);
        }
    }
}