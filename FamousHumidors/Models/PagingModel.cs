using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class PagingModel
    {
        public PagingModel(int numberOfItems, int page, int resultsPerPage, string sort, string baseUrl)
        {
            NumberOfItems = numberOfItems;
            Page = page;
            ResultsPerPage = resultsPerPage;
            Sort = sort;
            BaseUrl = baseUrl;

            CalculateParameters();
        }
        //input parameters
        public int NumberOfItems { get; set; }
        public int Page { get; set; }
        public int ResultsPerPage { get; set; }
        public string Sort { get; set; }
        public string BaseUrl { get; set; }
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

        private void CalculateParameters()
        {
            var pageFilter = "page=" + Page;
            var resultsPerPageFilter = "resultsPerPage=" + ResultsPerPage;
            var sortFilter = "sort=" + Sort;
            var pagingFilters = pageFilter + "&" + resultsPerPageFilter + "&" + sortFilter;

            //var filterUrlBase = "page=" + Page + "&resultsPerPage=" + ResultsPerPage;
            //var resultsPerPageFilterBase = "resultsPerPage=" + ResultsPerPage;

            NumberOfPages = (int)Math.Ceiling((double)NumberOfItems / (double)ResultsPerPage);
            FirstItem = (ResultsPerPage * (Page - 1)) + 1;
            //lastItem
            LastItem = FirstItem + ResultsPerPage - 1;
            if (LastItem > NumberOfItems)
            {
                LastItem = NumberOfItems;
            }
            //url
            Url = BaseUrl + "?" + pagingFilters;
            //first page
            FirstPage = 1;
            FirstPageUrl = BaseUrl + "?page=1" + "&" + resultsPerPageFilter + "&" + sortFilter;
            //next page url
            NextPage = 1;
            NextPageUrl = FirstPageUrl;
            if (NumberOfPages > Page)
            {
                NextPage = Page + 1;
                NextPageUrl = BaseUrl + "?page=" + NextPage + "&" + resultsPerPageFilter + "&" + sortFilter;
            }
            //previous page
            PrevPageUrl = "";
            PrevPage = Page - 1;
            if (PrevPage < 1)
            {
                PrevPage = 1;
            }
            PrevPageUrl = BaseUrl + "?page=" + PrevPage + "&" + resultsPerPageFilter + "&" + sortFilter;
            //last page
            LastPage = NumberOfPages;
            LastPageUrl = BaseUrl + "?page=" + NumberOfPages + "&" + resultsPerPageFilter + "&" + sortFilter;
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

                MidPageUrl = BaseUrl + "?page=" + MidPage + "&resultsPerPage=" + ResultsPerPage;
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