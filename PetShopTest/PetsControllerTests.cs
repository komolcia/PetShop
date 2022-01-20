using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetShop.Controllers;
using PetShop.Models;
using System;
using System.Web.Mvc;

namespace PetShopTest
{
    [TestClass]
    public class PetsControllerTests
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [TestMethod]
        public void IndexTests()
        {
            var controller = new PetShop.Controllers.PetsController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Details()
        {
            // Arrange
            PetsController controller = new PetsController();
            var species = new Species { Name = "Rabbit", Id = 1 };
            var pet = new Pet { PetId = 2, Name = "Happy",Species=species, DateOfBirth = new DateTime(2000 / 02 / 08) };

            controller.Create();

            // Act
            ViewResult result = controller.Details(2)as ViewResult;

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Create()
        {

            PetsController controller = new PetsController();


            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit()
        {
            int id = 0;
            // Arrange
            PetsController controller = new PetsController();
            

            // Act
            ViewResult result = controller.Edit(id) as ViewResult;

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Delete()
        {
            int id = 0;
            // Arrange
            PetsController controller = new PetsController();

            // Act
            ViewResult result = controller.Delete(id) as ViewResult;

            // Assert
            Assert.IsNull(result);
        }
    }
}
