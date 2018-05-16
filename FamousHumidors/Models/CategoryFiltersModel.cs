using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class CategoryFiltersModel : IEqualityFilters
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EqualityValue { get; set; }
        public string FilterName { get; set; }
        public Dictionary<int, EqualityFilterModel> Filters { get; set; }

        public CategoryFiltersModel(int id = 0)
        {
            Filters = DefaultFilters();
            Id = id;
            Name = Filters[id].Name;
            EqualityValue = Filters[id].EqualityValue;
            FilterName = "Category";
        }
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
    }
}