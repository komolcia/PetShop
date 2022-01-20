using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetShop.Controllers;
using System;
using System.Web.Mvc;

namespace PetShopTest
{
    [TestClass]
    public class CustomersControllerTests
    {
        [TestMethod]
        public void IndexTests()
        {
            var controller = new PetShop.Controllers.CustomersController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod]
        public void Details()
        {
            // Arrange
            CustomersController controller = new CustomersController();

            int id = 0;

            // Act
            ViewResult result = controller.Details(id) as ViewResult;

            // Assert
            Assert.IsNull( result);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            CustomersController controller = new CustomersController();


            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit()
        {
            // Arrange
            CustomersController controller = new CustomersController();
            int id = 0;
            // Act
            ViewResult result = controller.Edit(id) as ViewResult;

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            CustomersController controller = new CustomersController();
            int id = 0;       // Act
            ViewResult result = controller.Delete(id) as ViewResult;

            // Assert
            Assert.IsNull(result);
        }
    }
}
