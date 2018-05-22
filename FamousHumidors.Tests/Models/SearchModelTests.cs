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
        public void SearchTestDefaultsValid()
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
    }
}
