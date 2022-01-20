using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;

namespace PetShopTest
{
    [TestClass]
    public class BuysControllerTests
    {
      [TestMethod]
        public void IndexTests()
        {
            var controller = new PetShop.Controllers.BuysController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
