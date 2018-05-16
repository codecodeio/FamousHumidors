using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class MinMaxFilterModel : FilterModel
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public MinMaxFilterModel(string name, int min = 0, int max = 0) : base(name)
        {
            Min = min;
            Max = max;
        }
    }
}