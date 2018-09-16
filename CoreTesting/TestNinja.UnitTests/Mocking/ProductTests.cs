using System;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void GetPriceTest_CustomerIsGold_ReturnsPrice()
        {
            var product = new Product()
            {
                ListPrice = 100
            };

            var customer = new Customer
            {
                IsGold = true
            };

            var result = product.GetPrice(customer);
            Assert.That(result, Is.EqualTo(70));
        }

        [Test]
        public void GetPriceTest2_CustomerIsGold_ReturnsPrice()
        {
            var product = new Product()
            {
                ListPrice = 100
            };

            var customer = new Mock<ICustomer>();
            customer.Setup(p => p.IsGold).Returns(true);

            var result = product.GetPrice(customer.Object);
            Assert.That(result, Is.EqualTo(70));
        }
    }
}
