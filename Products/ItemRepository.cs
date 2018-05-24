using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public class ItemRepository
    {
        private const string Humidor_Pref = "HU";
        private const string Hygrometer_Pref = "HY";
        private const string Lighter_Pref = "LG";
        private Items db = new Items();

        public ItemRepository()
        {

        }
        public IQueryable<Item> ByCategory(string category)
        {
            return db.Products.Where(r => r.category_id == category);
        }
        public IQueryable<Item> ByCategory(IQueryable<Item> query, string category)
        {
            return query.Where(r => r.category_id == category);
        }
        public IQueryable<ItemModel> ByCategory(IQueryable<ItemModel> query, string category)
        {
            return query.Where(r => r.Category == category);
        }

        public IQueryable<Item> ByPrice(int min, int max)
        {
            return db.Products.Where(r => (r.price_sort >= min && r.price_sort <= max));
        }
        public IQueryable<Item> ByPrice(IQueryable<Item> query, int min, int max)
        {
            return query.Where(r => (r.price_sort >= min && r.price_sort <= max));
        }
        public IQueryable<ItemModel> ByPrice(IQueryable<ItemModel> query, int min, int max)
        {
            return query.Where(r => (r.Price >= min && r.Price <= max));
        }

        public IQueryable<Item> ByHumidorSize(string size)
        {
            return db.Products.Where(r => r.humidor_size == size);
        }

        public IQueryable<Item> ByColor(string color)
        {
            IQueryable<Item> query;

            switch (color)
            {
                case "Black":
                    query = db.Products.Where(r =>
                        r.acc_color == "Black"
                        || r.acc_color == "Charcoal"
                    );
                    break;
                case "Blue":
                    query = db.Products.Where(r =>
                        r.acc_color == "Blue"
                        || r.acc_color == "Teal"
                    );
                    break;
                case "Brown":
                    query = db.Products.Where(r =>
                        r.acc_color == "Brown"
                        || r.acc_color == "Cognac"
                        || r.acc_color == "Khaki"
                        || r.acc_color == "Tan"
                    );
                    break;
                case "Metal":
                    query = db.Products.Where(r =>
                        r.acc_color == "Gold"
                        || r.acc_color == "Brass"
                        || r.acc_color == "Bronze"
                        || r.acc_color == "Copper"
                        || r.acc_color == "Nickel"
                    );
                    break;
                case "Gray":
                    query = db.Products.Where(r =>
                        r.acc_color == "Gray"
                        || r.acc_color == "Carbon Fiber"
                        || r.acc_color == "Gunmetal"
                        || r.acc_color == "Smoke"
                    );
                    break;
                case "Other":
                    query = db.Products.Where(r =>
                        r.acc_color == ""
                        || r.acc_color == "Bicolor"
                        || r.acc_color == "Logo"
                        || r.acc_color == "Spectra"
                    );
                    break;
                case "Red":
                    query = db.Products.Where(r =>
                        r.acc_color == "Red"
                        || r.acc_color == "Burgundy"
                        || r.acc_color == "Rosewood"
                    );
                    break;
                
                case "Silver":
                    query = db.Products.Where(r =>
                        r.acc_color == "Silver"
                        || r.acc_color == "Chrome"
                        || r.acc_color == "Pewter"
                        || r.acc_color == "Stainless"
                        || r.acc_color == "Titanium"
                    );
                    break;
                default:
                    query = db.Products.Where(r => r.acc_color == color);
                    break;
            }

            return query;
        }

        public IQueryable<ItemModel> AsItemModel()
        {
            return db.Products.Select(r => new ItemModel
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
            });
        }

        public IQueryable<ItemModel> AsItemModelByHumidorSize(string size)
        {
            return db.Products
                .Where(r => r.humidor_size == size)
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
                    Url = "/" + r.url_detail,
                    VoteCount = (int)r.vote_count
                });
        }

        public IQueryable<ItemModel> AsItemModelByColor(string color)
        {
            return ByColor(color)
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
                    Url = "/" + r.url_detail,
                    VoteCount = (int)r.vote_count
                });
        }

        public IQueryable<ItemModel> NewArrivals()
        {
            var humidors = db.Products
                .Where(r => r.pref == Humidor_Pref)
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
                    Url = "/" + r.url_detail,
                    VoteCount = (int)r.vote_count
                })
                .OrderByDescending(r => r.VoteCount)
                .Take(5);

            var hygrometers = db.Products
                .Where(r => r.pref == Hygrometer_Pref)
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
                    Url = "/" + r.url_detail,
                    VoteCount = (int)r.vote_count
                })
                .OrderByDescending(r => r.VoteCount)
                .Take(5);

            var lighters = db.Products
                .Where(r => r.pref == Lighter_Pref)
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
                    Url = "/" + r.url_detail,
                    VoteCount = (int)r.vote_count
                })
                .OrderByDescending(r => r.VoteCount)
                .Take(5);

            var newArrivals = humidors.Union(hygrometers).Union(lighters);

            return newArrivals;
        }

        public IQueryable<ItemModel> BestSellers()
        {
            var humidors = db.Products
                .Where(r => r.pref == Humidor_Pref && r.avg_rating > 80)
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
                    Url = "/" + r.url_detail,
                    VoteCount = (int)r.vote_count
                })
                .OrderByDescending(r => r.VoteCount)
                .Take(4);

            var hygrometers = db.Products
                .Where(r => r.pref == Hygrometer_Pref && r.avg_rating > 80)
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
                    Url = "/" + r.url_detail,
                    VoteCount = (int)r.vote_count
                })
                .OrderByDescending(r => r.VoteCount)
                .Take(4);

            var lighters = db.Products
                .Where(r => r.pref == Lighter_Pref && r.avg_rating > 80)
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
                    Url = "/" + r.url_detail,
                    VoteCount = (int)r.vote_count
                })
                .OrderByDescending(r => r.VoteCount)
                .Take(4);

            var bestSellers = humidors.Union(hygrometers).Union(lighters);

            return bestSellers;
        }
    }
}
