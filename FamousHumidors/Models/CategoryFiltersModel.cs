using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class CategoryFiltersModel : IEqualityFilters
    {
        public CategoryFiltersModel(int id = 0)
        {
            FilterName = "Category";
            Filters = DefaultFilters();
            
            Name = Filters[id].Name;
            if (id > 0 && id <= Filters.Count())
            {
                Id = id;
                EqualityValue = Filters[id].EqualityValue;
            }
            else
            {
                Id = 1;
                EqualityValue = Filters[id].EqualityValue;
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FilterName { get; set; }
        public string EqualityValue { get; set; }
        public Dictionary<int, EqualityFilterModel> Filters { get; set; }

        public Dictionary<int, EqualityFilterModel> DefaultFilters()
        {
            return new Dictionary<int, EqualityFilterModel>()
            {
                { 1, new EqualityFilterModel("Humidors") },
                { 2, new EqualityFilterModel("Hygrometers") },
                { 3, new EqualityFilterModel("Liquids","Humidifying Liquids") },
                { 4, new EqualityFilterModel("Lighters") },
                { 5, new EqualityFilterModel("Cutters","Cigar Cutters") },
                { 6, new EqualityFilterModel("Ashtrays") }
            };
            
        }

        public void Counts(SearchFiltersModel searchFilters)
        {
            var itemRepository = new ItemRepository();

            for (var i = 1; i <= Filters.Count(); i++)
            {
                var query = itemRepository.ByCategory(Filters[i].EqualityValue);
                if (searchFilters.PriceFilters.Id != 0)
                {
                    query = itemRepository.ByPrice(query, searchFilters.PriceFilters.Min, searchFilters.PriceFilters.Max);
                }

                Filters[i].Count = query.Count();
            }
        }
    }
}