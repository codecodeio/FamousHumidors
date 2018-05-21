using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class PagingModel
    {
        public PagingModel(int numberOfItems, int page, int resultsPerPage, string sort)
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
            ResultsPerPage = resultsPerPage;
            Sort = sort;
            
            CalculateParameters();
        }
        //input parameters
        public int NumberOfItems { get; set; }
        public int Page { get; set; }
        public int ResultsPerPage { get; set; }
        public string Sort { get; set; }
       
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
        public string SortTitle { get; set; }
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
            var sortFilter = "sort=" + Sort;
            PagingFilters = pageFilter + "&" + resultsPerPageFilter + "&" + sortFilter;

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
            FirstPageUrl = Globals.SearchUrl + "?page=1" + "&" + resultsPerPageFilter + "&" + sortFilter;
            //next page url
            NextPage = 1;
            NextPageUrl = FirstPageUrl;
            if (NumberOfPages > Page)
            {
                NextPage = Page + 1;
                NextPageUrl = Globals.SearchUrl + "?page=" + NextPage + "&" + resultsPerPageFilter + "&" + sortFilter;
            }
            //previous page
            PrevPageUrl = "";
            PrevPage = Page - 1;
            if (PrevPage == 0)
            {
                PrevPage = 1;
            }
            PrevPageUrl = Globals.SearchUrl + "?page=" + PrevPage + "&" + resultsPerPageFilter + "&" + sortFilter;
            //last page
            LastPage = NumberOfPages;
            if (LastPage == 0)
            {
                LastPage = 1;
            }
            LastPageUrl = Globals.SearchUrl + "?page=" + LastPage + "&" + resultsPerPageFilter + "&" + sortFilter;
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

                MidPageUrl = Globals.SearchUrl + "?page=" + MidPage + "&resultsPerPage=" + ResultsPerPage;
            }

            //Urls require page = 1 but display should show page 0.
            if (NumberOfPages == 0)
            {
                Page = NumberOfPages;
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