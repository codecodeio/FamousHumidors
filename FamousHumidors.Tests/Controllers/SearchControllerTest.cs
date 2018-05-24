using System;
using System.Web.Mvc;
using FamousHumidors.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamousHumidors.Tests.Controllers
{
    [TestClass]
    public class SearchControllerTest
    {
        [TestMethod]
        public void SearchControllerIndexTest()
        {
            //Arrange
            SearchController controller = new SearchController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
    }
}
