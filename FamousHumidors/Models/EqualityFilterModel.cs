using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class EqualityFilterModel : FilterModel
    {
        public string EqualityValue { get; set; }
        
        public EqualityFilterModel(string name, string equalityValue = null) : base(name)
        {
            if(equalityValue == null)
            {
                EqualityValue = name;
            }
            else
            {
                EqualityValue = equalityValue;
            }
        }
    }
}