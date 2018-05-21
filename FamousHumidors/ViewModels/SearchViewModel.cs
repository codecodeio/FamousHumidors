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
        public SortingFiltersModel Sorting { get; set; }
        public SearchViewModel(IQueryable<ItemModel> items, PagingModel paging, SearchFiltersModel filters, SortingFiltersModel sorting)
        {
            Items = items;
            Paging = paging;
            Filters = filters;
            Sorting = sorting;
        }
        
    }
}