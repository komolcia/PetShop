using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetShop.Controllers;
using System;
using System.Web.Mvc;

namespace PetShopTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IndexTests()
        {
            var controller = new CustomersController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
