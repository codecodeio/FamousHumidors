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
    public class NewsletterController : Controller
    {
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "email")] NewsletterModel newsletter)
        {
            if (ModelState.IsValid)
            {
                return PartialView("_Newsletter", newsletter);
            }

            return PartialView("_Newsletter", newsletter);

        }
    }
}