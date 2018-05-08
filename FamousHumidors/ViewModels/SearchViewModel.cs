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
        public int NumberOfItems { get; set; }
        public int Page { get; set; }
        public int NumberOfPages { get; set; }
        public int ResultsPerPage { get; set; }
        public int FirstItem { get; set; }
        public int LastItem { get; set; }
        public string Url { get; set; }
        public int FirstPage { get; set; }
        public string FirstPageUrl { get; set; }
        public int NextPage { get; set; }
        public string NextPageUrl { get; set; }
        public int PrevPage { get; set; }
        public string PrevPageUrl { get; set; }
        public int LastPage { get; set; }
        public string LastPageUrl { get; set; }
        public int MidPage { get; set; }
        public string MidPageUrl { get; set; }
        public string Sort { get; set; }
        public string SortTitle { get; set; }
       
        public SearchViewModel(IQueryable<ItemBaseModel> items, int numberOfItems, int page, int resultsPerPage, string sort)
        {
            Items = items;
            NumberOfItems = numberOfItems;
            Page = page;
            ResultsPerPage = resultsPerPage;
            Sort = sort;
            
            CalculateParameters();
        }

        private void CalculateParameters()
        {
            var filterUrlBase = "page=" + Page + "&resultsPerPage=" + ResultsPerPage;
            var resultsPerPageUrlBase = "resultsPerPage=" + ResultsPerPage;

            NumberOfPages = (int)Math.Ceiling((double)NumberOfItems / (double)ResultsPerPage);
            FirstItem = ( ResultsPerPage * (Page - 1) ) + 1;
            //lastItem
            LastItem = FirstItem + ResultsPerPage - 1;
            if(LastItem > NumberOfItems)
            {
                LastItem = NumberOfItems;
            }
            //url
            Url = "/search?page = " + Page + " & resultsPerPage = " + ResultsPerPage;
            //first page
            FirstPageUrl = "/search?page=1" + "&resultsPerPage=" + ResultsPerPage; ;
            FirstPage = 1;
            //next page url
            NextPageUrl = FirstPageUrl;
            NextPage = 1;
            if (NumberOfPages > Page)
            {
                NextPage = Page + 1;
                NextPageUrl = "/search" + "?page=" + NextPage + "&resultsPerPage=" + ResultsPerPage;
            }
            //previous page
            PrevPageUrl = "";
            PrevPage = Page - 1;
            if(PrevPage < 1)
            {
                PrevPage = 1;
            }
            PrevPageUrl = "/search" + "?page=" + PrevPage + "&resultsPerPage=" + ResultsPerPage;
            //last page
            LastPage = NumberOfPages;
            LastPageUrl = "/search" + "?page=" + NumberOfPages + "&resultsPerPage=" + ResultsPerPage;
            if (Page == NumberOfPages)
            {
                LastPage = PrevPage;
                LastPageUrl = PrevPageUrl;
            }
            //mid page url
            MidPage = 0;
            MidPageUrl = "";
            if (NumberOfPages >= 3)
            {
                if (Page == NumberOfPages)
                {
                    MidPage = (int)Math.Floor((double)NumberOfPages / 2);
                }
                else
                {
                     MidPage = (int)Math.Floor( ( ( (double)NumberOfPages - Page) / 2 ) + Page);
                }
               
                MidPageUrl = "/search" + "?page=" + MidPage + "&resultsPerPage=" + ResultsPerPage;
            }

            //sort title
            switch (Sort)
            {
                default:
                    SortTitle = "Best";
                    break;
                case "best":
                    SortTitle = "Best";
                    break;
                case "priceAsc":
                    SortTitle = "Price";
                    break;
                case "priceDesc":
                    SortTitle = "Price";
                    break;
            }

        }
    }
}