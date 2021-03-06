﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class PagingModel
    {
        public PagingModel(int numberOfItems, int page, int resultsPerPage, SearchFiltersModel searchFilters, SortingFiltersModel sortFilters)
        {
            NumberOfItems = numberOfItems;
            if (page == 0)
            {
                Page = 1;
            }
            else
            {
                Page = page;
            }
            switch (resultsPerPage)
            {
                case 8:
                    ResultsPerPage = resultsPerPage;
                    break;
                case 16:
                    ResultsPerPage = resultsPerPage;
                    break;
                case 24:
                    ResultsPerPage = resultsPerPage;
                    break;
                default:
                    ResultsPerPage = 8;
                    break;
            }
           
            SearchFilters = searchFilters;
            SortFilters = sortFilters;

            CalculateParameters();
        }
        //input parameters
        public int NumberOfItems { get; set; }
        public int Page { get; set; }
        public int ResultsPerPage { get; set; }
        public Dictionary<int,string> ResultsPerPageUrls { get; set; }
        public SearchFiltersModel SearchFilters { get; set; }
        public SortingFiltersModel SortFilters { get; set; }

        //calculated parameters
        public int NumberOfPages { get; set; }
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
        public string PagingFilters { get; set; }

        private void CalculateParameters()
        {
            NumberOfPages = (int)Math.Ceiling((double)NumberOfItems / (double)ResultsPerPage);

            if(Page > NumberOfPages && NumberOfPages > 0)
            {
                Page = NumberOfPages;
            }

            var pageFilter = "page=" + Page;
            var resultsPerPageFilter = "resultsPerPage=" + ResultsPerPage;
            PagingFilters = pageFilter + "&" + resultsPerPageFilter;

            //var filterUrlBase = "page=" + Page + "&resultsPerPage=" + ResultsPerPage;
            //var resultsPerPageFilterBase = "resultsPerPage=" + ResultsPerPage;

           
            FirstItem = (ResultsPerPage * (Page - 1)) + 1;
            //lastItem
            LastItem = FirstItem + ResultsPerPage - 1;
            if (LastItem > NumberOfItems)
            {
                LastItem = NumberOfItems;
            }
            //url
            Url = Globals.SearchUrl + "?" + PagingFilters;
            //first page
            FirstPage = 1;
            FirstPageUrl = Globals.SearchUrl + "?page=1" + "&" + resultsPerPageFilter + "&" + SearchFilters.FiltersUrl + "&sortID=" + SortFilters.Id;
            //next page url
            NextPage = 1;
            NextPageUrl = FirstPageUrl;
            if (NumberOfPages > Page)
            {
                NextPage = Page + 1;
                NextPageUrl = Globals.SearchUrl + "?page=" + NextPage + "&" + resultsPerPageFilter + "&" + SearchFilters.FiltersUrl + "&sortID=" + SortFilters.Id;
            }
            //previous page
            PrevPageUrl = "";
            PrevPage = Page - 1;
            if (PrevPage == 0)
            {
                PrevPage = 1;
            }
            PrevPageUrl = Globals.SearchUrl + "?page=" + PrevPage + "&" + resultsPerPageFilter + "&" + SearchFilters.FiltersUrl + "&sortID=" + SortFilters.Id;
            //last page
            LastPage = NumberOfPages;
            if (LastPage == 0)
            {
                LastPage = 1;
            }
            LastPageUrl = Globals.SearchUrl + "?page=" + LastPage + "&" + resultsPerPageFilter + "&" + SearchFilters.FiltersUrl + "&sortID=" + SortFilters.Id;
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
                    MidPage = (int)Math.Floor((((double)NumberOfPages - Page) / 2) + Page);
                }
                if (MidPage == 0)
                {
                    MidPage = 1;
                }

                MidPageUrl = Globals.SearchUrl + "?page=" + MidPage + "&resultsPerPage=" + ResultsPerPage + "&" + SearchFilters.FiltersUrl + "&sortID=" + SortFilters.Id;
            }

            ResultsPerPageUrls = new Dictionary<int, string>()
            {
                { 8,Globals.SearchUrl + "?page=" + Page + "&resultsPerPage=8" + "&" + SearchFilters.FiltersUrl + "&sortID=" + SortFilters.Id },
                { 16,Globals.SearchUrl + "?page=" + Page + "&resultsPerPage=16" + "&" + SearchFilters.FiltersUrl + "&sortID=" + SortFilters.Id },
                { 24,Globals.SearchUrl + "?page=" + Page + "&resultsPerPage=24" + "&" + SearchFilters.FiltersUrl + "&sortID=" + SortFilters.Id }
            };

            //Urls require page = 1 but display should show page 0.
            if (NumberOfPages == 0)
            {
                Page = NumberOfPages;
            }
        }
    }
}