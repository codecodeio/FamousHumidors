using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class FilterModel
    {
        public string Name { get; set; }
        public string FilterName { get; set; }
        public int Count { get; set; }
        public string Url { get; set; }
        public FilterModel(string name)
        {
            Name = name;
            FilterName = "";
            Count = 0;
            Url = "/search";
        }
    }
}