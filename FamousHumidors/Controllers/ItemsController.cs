using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using FamousHumidors.Models;
using FamousHumidors.ViewModels;

namespace FamousHumidors.Controllers
{
    public class ItemsController : Controller
    {
        private const string Humidor_Pref = "HU";
        private const string Hygrometer_Pref = "HY";
        private const string Lighter_Pref = "LG";
        private Items db = new Items();

        // GET: Items
        public ActionResult Index()
        {
            //var model =
            //  db.Products
            //    .Where(r => r.pref == "HU")
            //    .Take(10);

            //db.Products.ToList()

            var model =
                (from r in db.Products
                 orderby r.margin descending
                 where r.pref == Humidor_Pref
                 select r
                )
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
                })
                .Take(10);
                
            return View(model);
        }

        // GET: Items
        public ActionResult Items()
        {
            //var model =
            //  db.Products
            //    .Where(r => r.pref == "HU")
            //    .Take(10);

            //db.Products.ToList()

            var model =
                (from r in db.Products
                 orderby r.margin descending
                 where r.pref == Humidor_Pref
                 select r
                )
                .Take(10);

            return View(model);
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            //id not provided
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //find item in DB
            Item item = db.Products.Find(id);

            //item not found
            if (item == null)
            {
                return HttpNotFound();
            }

            //base item
            var baseItem = new ItemBaseModel(item);

            //default detail item
            var detailItem = new Dictionary<string,string>();

            //detail item
            switch (baseItem.Category)
            {
                case "Humidors":
                    detailItem = new HumidorModel(item).ToDictionary();
                    break;
                case "Lighters":
                    detailItem = new LighterModel(item).ToDictionary();
                    break;
            }

            //view model
            var detailViewModel = new DetailViewModel(baseItem,detailItem);

            return View(detailViewModel);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ihdnum,name,name_cleaned,name_display,brand,brandgroup,description_item,description_brand,image_thumbnail,image_medium,image_large,image_brand_band,image_brand_label,video_brand,is_free_shipping,is_new,is_on_sale,keyword,price_retail,price_sale,price_srp,price_sort,sku,sort_default,url_detail,url_detail2,brandlink,brandgrouplink,is_discontinued,category_id,margin,is_kit,offer,is_rev,sortorder1,avail,brand_code,bgcode,is_tiered,humidor_trays,famous_exclusives,humidifier_included,wrapper_color,avg_rating,brand_rating,package_type,humidor_length,humidor_capacity,humidor_width,shape,country_of_origin,humidor_color,subihdnum,strength,length,ring_gauge,group_id,humidor_material,humidor_size,tube,vote_count,flavor,humidor_depth,cigar_type,boxpress,quantity,hygrometer_included,brandgroup_id,brand_code_id,category_id_id,cigar_type_id,country_of_origin_id,flavor_id,humidor_color_id,humidor_material_id,humidor_size_id,package_type_id,shape_id,strength_id,wrapper_color_id,brand_id,sampler_brand_ids,sampler_group_ids,sampler_ids_qtys,itemdes2,sizestr,wrapper_origin,wrapperleaf_type,wrapper_origin_id,wrapperleaf_type_id,paok,sflg,normbrand,normbrandgroup,normname,fsaled,tsaled,pref,realavail,acc_color,acc_color_id,show_wrapper,mostly_acc,percent_off,device_type,device_type_id,nic_strength,prod_life,ec_flavor,ec_flavor_id,ec_tip_color,ec_tip_color_id,ec_color,ec_color_id,ec_size,pkg_qty,sort_sale_margin,is_monster,price_monster,brand_review_link,item_review_link,package_string,offer_info,preorder_message,preorder_date,has_free_offer")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Products.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ihdnum,name,name_cleaned,name_display,brand,brandgroup,description_item,description_brand,image_thumbnail,image_medium,image_large,image_brand_band,image_brand_label,video_brand,is_free_shipping,is_new,is_on_sale,keyword,price_retail,price_sale,price_srp,price_sort,sku,sort_default,url_detail,url_detail2,brandlink,brandgrouplink,is_discontinued,category_id,margin,is_kit,offer,is_rev,sortorder1,avail,brand_code,bgcode,is_tiered,humidor_trays,famous_exclusives,humidifier_included,wrapper_color,avg_rating,brand_rating,package_type,humidor_length,humidor_capacity,humidor_width,shape,country_of_origin,humidor_color,subihdnum,strength,length,ring_gauge,group_id,humidor_material,humidor_size,tube,vote_count,flavor,humidor_depth,cigar_type,boxpress,quantity,hygrometer_included,brandgroup_id,brand_code_id,category_id_id,cigar_type_id,country_of_origin_id,flavor_id,humidor_color_id,humidor_material_id,humidor_size_id,package_type_id,shape_id,strength_id,wrapper_color_id,brand_id,sampler_brand_ids,sampler_group_ids,sampler_ids_qtys,itemdes2,sizestr,wrapper_origin,wrapperleaf_type,wrapper_origin_id,wrapperleaf_type_id,paok,sflg,normbrand,normbrandgroup,normname,fsaled,tsaled,pref,realavail,acc_color,acc_color_id,show_wrapper,mostly_acc,percent_off,device_type,device_type_id,nic_strength,prod_life,ec_flavor,ec_flavor_id,ec_tip_color,ec_tip_color_id,ec_color,ec_color_id,ec_size,pkg_qty,sort_sale_margin,is_monster,price_monster,brand_review_link,item_review_link,package_string,offer_info,preorder_message,preorder_date,has_free_offer")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Products.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Products.Find(id);
            db.Products.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
