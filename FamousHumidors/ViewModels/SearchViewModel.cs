using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FamousHumidors.Models;
using Products;

namespace FamousHumidors.ViewModels
{
    public class SearchViewModel
    {
        public IQueryable<ItemModel> Items { get; set; }
        public PagingModel Paging { get; set; }
        public SearchFiltersModel Filters { get; set; }
        
        public SearchViewModel(IQueryable<ItemModel> items, PagingModel paging, SearchFiltersModel filters)
        {
            Items = items;
            Paging = paging;
            Filters = filters;
        }
        
    }
}