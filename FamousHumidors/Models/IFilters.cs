using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public interface IFilters
    {
        //selected id
        int Id { get; set; }
        //selected name
        string Name { get; set; }
        string FilterName { get; set; }
    }
}