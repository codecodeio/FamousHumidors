using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public interface IMinMaxFilters : IFilters
    {
        int Min { get; set; }
        int Max { get; set; }
        Dictionary<int, MinMaxFilterModel> Filters { get; set; }

        Dictionary<int, MinMaxFilterModel> DefaultFilters();
    }
}