using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class PriceFiltersModel : IMinMaxFilters
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EqualityValue { get; set; }
        public string FilterName { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public Dictionary<int, MinMaxFilterModel> Filters { get; set; }

        public PriceFiltersModel(int id = 0)
        {
            FilterName = "Price";
            Filters = DefaultFilters();
            Id = id;
            if(Id <= Filters.Count())
            {
                Name = Filters[id].Name;
                Min = Filters[id].Min;
                Max = Filters[id].Max;
            }
            else
            {
                Name = "";
                Min = 0;
                Max = 0;
            }
            
            
            
        }
        public Dictionary<int, MinMaxFilterModel> DefaultFilters()
        {
            return new Dictionary<int, MinMaxFilterModel>()
            {
                { 1, new MinMaxFilterModel("0-10",0,10) },
                { 2, new MinMaxFilterModel("11-25",11,25) },
                { 3, new MinMaxFilterModel("26-50",26,50) },
                { 4, new MinMaxFilterModel("51-75",51,75) },
                { 5, new MinMaxFilterModel("76-100",76,100) },
                { 6, new MinMaxFilterModel("101+",101,9999) }
            };
        }
    }
}