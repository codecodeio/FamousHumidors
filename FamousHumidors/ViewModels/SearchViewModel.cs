using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FamousHumidors.Models;

namespace FamousHumidors.ViewModels
{
    public class SearchViewModel
    {
        public IQueryable<ItemBaseModel> Items { get; set; }
        public PagingModel Paging { get; set; }

        public SearchViewModel(IQueryable<ItemBaseModel> items, PagingModel paging)
        {
            Items = items;
            Paging = paging;
        }
        
    }
}