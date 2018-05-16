using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public interface IEqualityFilters : IFilters
    {
        string EqualityValue { get; set; }
        Dictionary<int, EqualityFilterModel> Filters { get; set; }

        Dictionary<int, EqualityFilterModel> DefaultFilters();
    }
}