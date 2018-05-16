using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class FilterModel
    {
        public string Name { get; set; }

        public FilterModel(string name)
        {
            Name = name;
        }
    }
}