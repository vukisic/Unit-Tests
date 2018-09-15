using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class TypeTests
    {
        private CustomerController _controller;

        [SetUp]
        public void SetUp()
        {
            _controller = new CustomerController();
        }

        [Test]
        public void Type_Test_IdZero_ReturnsNotFound()
        {
            var result = _controller.GetCustomer(0);

            //Difference btw TypeOf and InstanceOf

            //Has to be NotFound obj
            Assert.That(result, Is.TypeOf<NotFound>());

            //Can be NotFound obj or its derivatives
            Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void Type_Test_IdNotZero_ReturnsOK()
        {
            var result = _controller.GetCustomer(1);
            Assert.That(result, Is.TypeOf<Ok>());
            Assert.That(result, Is.InstanceOf<Ok>());
        }
    }
}
