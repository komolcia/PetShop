using NUnit.Framework;
using PetShop.Controllers;
using PetShopTests;
using System.Web.Mvc;

namespace PetShopTests
{
    [TestFixture]
    public class CustomerControllerTest
    {
        [Test]
        public void TestDetailsView()
        {
            var obj = new CustomersController();

            var actResult = obj.Index() as ViewResult;

            Assert.That(actResult.ViewName, Is.EqualTo("Index"));

        }
    }
}