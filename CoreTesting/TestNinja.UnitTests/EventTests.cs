using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class EventTests
    {
        [Test]
        public void Event_Test_ValidInput_RiseEvent()
        {
            var logger = new ErrorLogger();
            var id = Guid.Empty;
            logger.ErrorLogged += (sender, args) => { id = args; };
            logger.Log("Error!");
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
