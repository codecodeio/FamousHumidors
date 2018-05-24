using System;
using FamousHumidors.Models;
using FamousHumidors.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamousHumidors.Tests
{
    [TestClass]
    public class SearchTests
    {
        [TestMethod]
        public void SearchTest_Defaults_Valid()
        {
            //Arrange
            var search = new SearchModel();
            //Act
            var result = search.Search();
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(SearchViewModel));
            Assert.IsTrue(result.Paging.NumberOfItems > 0);
            Assert.IsTrue(result.Paging.Page == 1);
            Assert.IsTrue(result.Filters.CategoryFilters.Id == 1);
            Assert.IsTrue(result.Filters.PriceFilters.Id == 0);
            Assert.IsTrue(result.Filters.HumidorSizeFilters.Id == 0);
            Assert.IsTrue(result.Sorting.Id == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SearchTest_Page_Negative()
        {
            //Arrange
            var page = -1;

            try
            {
                //Act
                var search = new SearchModel(page);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual(ex.Message, "Page must be greater than 0");
                throw;
            }
        }

        [TestMethod]
        public void SearchTest_Page_TooHigh()
        {
            //Arrange
            int page = 9999;
            int resultsPerPage = 8;
            int sortID = 1;
            int categoryID = 1;
            int priceID = 0;
            int humidorSizeID = 0;
            int colorID = 0;
            //Act
            var search = new SearchModel(page, resultsPerPage, sortID, categoryID, priceID, humidorSizeID, colorID);
            var result = search.Search();
            // Assert
            Assert.IsTrue(result.Paging.NumberOfPages < page);
            Assert.IsTrue(result.Paging.NumberOfPages > 0);
        }

        [TestMethod]
        public void SearchTest_ResultsPerPage_Negative()
        {
            //Arrange
            int page = 1;
            int resultsPerPage = -1;
            int sortID = 1;
            int categoryID = 1;
            int priceID = 0;
            int humidorSizeID = 0;
            int colorID = 0;
            //Act
            var search = new SearchModel(page,resultsPerPage,sortID,categoryID,priceID,humidorSizeID, colorID);
            var result = search.Search();
            // Assert
            Assert.AreEqual(8,result.Paging.ResultsPerPage);
        }

        [TestMethod]
        public void SearchTest_ResultsPerPage_InvalidInteger()
        {
            //Arrange
            int page = 1;
            int resultsPerPage = 100;
            int sortID = 1;
            int categoryID = 1;
            int priceID = 0;
            int humidorSizeID = 0;
            int colorID = 0; 
            //Act
            var search = new SearchModel(page, resultsPerPage, sortID, categoryID, priceID, humidorSizeID, colorID);
            var result = search.Search();
            // Assert
            Assert.AreEqual(8, result.Paging.ResultsPerPage);
        }

        [TestMethod]
        public void SearchTest_SortID_Negative()
        {
            //Arrange
            int page = 1;
            int resultsPerPage = 8;
            int sortID = -1;
            int categoryID = 1;
            int priceID = 0;
            int humidorSizeID = 0;
            int colorID = 0;
            //Act
            var search = new SearchModel(page, resultsPerPage, sortID, categoryID, priceID, humidorSizeID, colorID);
            var result = search.Search();
            // Assert
            Assert.AreEqual(1, result.Sorting.Id);
        }

        [TestMethod]
        public void SearchTest_SortID_InvalidInteger()
        {
            //Arrange
            int page = 1;
            int resultsPerPage = 8;
            int sortID = 9999;
            int categoryID = 1;
            int priceID = 0;
            int humidorSizeID = 0;
            int colorID = 0;
            //Act
            var search = new SearchModel(page, resultsPerPage, sortID, categoryID, priceID, humidorSizeID, colorID);
            var result = search.Search();
            // Assert
            Assert.AreEqual(1, result.Sorting.Id);
        }

        [TestMethod]
        public void SearchTest_CategoryID_Negative()
        {
            //Arrange
            int page = 1;
            int resultsPerPage = 8;
            int sortID = 1;
            int categoryID = -1;
            int priceID = 0;
            int humidorSizeID = 0;
            int colorID = 0;
            //Act
            var search = new SearchModel(page, resultsPerPage, sortID, categoryID, priceID, humidorSizeID, colorID);
            var result = search.Search();
            // Assert
            Assert.AreEqual(1, result.Filters.CategoryFilters.Id);
        }

        [TestMethod]
        public void SearchTest_CategoryID_InvalidInteger()
        {
            //Arrange
            int page = 1;
            int resultsPerPage = 8;
            int sortID = 1;
            int categoryID = 9999;
            int priceID = 0;
            int humidorSizeID = 0;
            int colorID = 0;
            //Act
            var search = new SearchModel(page, resultsPerPage, sortID, categoryID, priceID, humidorSizeID, colorID);
            var result = search.Search();
            // Assert
            Assert.AreEqual(1, result.Filters.CategoryFilters.Id);
        }

        [TestMethod]
        public void SearchTest_PriceID_Negative()
        {
            //Arrange
            int page = 1;
            int resultsPerPage = 8;
            int sortID = 1;
            int categoryID = 1;
            int priceID = -1;
            int humidorSizeID = 0;
            int colorID = 0;
            //Act
            var search = new SearchModel(page, resultsPerPage, sortID, categoryID, priceID, humidorSizeID, colorID);
            var result = search.Search();
            // Assert
            Assert.AreEqual(0, result.Filters.PriceFilters.Id);
            Assert.AreEqual("", result.Filters.PriceFilters.Name);
            Assert.AreEqual(0, result.Filters.PriceFilters.Min);
            Assert.AreEqual(0, result.Filters.PriceFilters.Max);
        }

        [TestMethod]
        public void SearchTest_PriceID_InvalidInteger()
        {
            //Arrange
            int page = 1;
            int resultsPerPage = 8;
            int sortID = 1;
            int categoryID = 1;
            int priceID = 9999;
            int humidorSizeID = 0;
            int colorID = 0;
            //Act
            var search = new SearchModel(page, resultsPerPage, sortID, categoryID, priceID, humidorSizeID, colorID);
            var result = search.Search();
            // Assert
            Assert.AreEqual(0, result.Filters.PriceFilters.Id);
            Assert.AreEqual("", result.Filters.PriceFilters.Name);
            Assert.AreEqual(0, result.Filters.PriceFilters.Min);
            Assert.AreEqual(0, result.Filters.PriceFilters.Max);
        }

        [TestMethod]
        public void SearchTest_HumidorSizeID_Negative()
        {
            //Arrange
            int page = 1;
            int resultsPerPage = 8;
            int sortID = 1;
            int categoryID = 1;
            int priceID = 1;
            int humidorSizeID = -1;
            int colorID = 0;
            //Act
            var search = new SearchModel(page, resultsPerPage, sortID, categoryID, priceID, humidorSizeID, colorID);
            var result = search.Search();
            // Assert
            Assert.AreEqual(0, result.Filters.HumidorSizeFilters.Id);
            Assert.AreEqual("", result.Filters.HumidorSizeFilters.Name);
            Assert.AreEqual("", result.Filters.HumidorSizeFilters.EqualityValue);
        }

        [TestMethod]
        public void SearchTest_HumidorSizeID_InvalidInteger()
        {
            //Arrange
            int page = 1;
            int resultsPerPage = 8;
            int sortID = 1;
            int categoryID = 1;
            int priceID = 1;
            int humidorSizeID = 9999;
            int colorID = 0;
            //Act
            var search = new SearchModel(page, resultsPerPage, sortID, categoryID, priceID, humidorSizeID, colorID);
            var result = search.Search();
            // Assert
            Assert.AreEqual(0, result.Filters.HumidorSizeFilters.Id);
            Assert.AreEqual("", result.Filters.HumidorSizeFilters.Name);
            Assert.AreEqual("", result.Filters.HumidorSizeFilters.EqualityValue);
        }

        [TestMethod]
        public void SearchTest_ColorID_Negative()
        {
            //Arrange
            int page = 1;
            int resultsPerPage = 8;
            int sortID = 1;
            int categoryID = 1;
            int priceID = 1;
            int humidorSizeID = 0;
            int colorID = -1;
            //Act
            var search = new SearchModel(page, resultsPerPage, sortID, categoryID, priceID, humidorSizeID, colorID);
            var result = search.Search();
            // Assert
            Assert.AreEqual(0, result.Filters.ColorFilters.Id);
            Assert.AreEqual("", result.Filters.ColorFilters.Name);
            Assert.AreEqual("", result.Filters.ColorFilters.EqualityValue);
        }

        [TestMethod]
        public void SearchTest_ColorID_InvalidInteger()
        {
            //Arrange
            int page = 1;
            int resultsPerPage = 8;
            int sortID = 1;
            int categoryID = 1;
            int priceID = 1;
            int humidorSizeID = 0;
            int colorID = 9999;
            //Act
            var search = new SearchModel(page, resultsPerPage, sortID, categoryID, priceID, humidorSizeID, colorID);
            var result = search.Search();
            // Assert
            Assert.AreEqual(0, result.Filters.ColorFilters.Id);
            Assert.AreEqual("", result.Filters.ColorFilters.Name);
            Assert.AreEqual("", result.Filters.ColorFilters.EqualityValue);
        }

    }
}
