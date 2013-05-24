using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerCellar.Service;
using BeerCellar.Service.Controllers;
using BeerCellar.Core;

namespace BeerCellar.Service.Tests.Controllers
{
    [TestClass]
    public class BeerCellarControllerTest
    {
        #region test methods
        [TestMethod]
        public void Get()
        {
            // Arrange
            var controller = new BeerCellarController();

            // Act
            IEnumerable<CellarEntry> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count());
            Assert.IsNotNull(result.ElementAt(0));
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Post("value");

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Delete(5);

            // Assert
        }
        #endregion
    }
}
