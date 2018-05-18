using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public class ItemRepository
    {
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
    }
}
