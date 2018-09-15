using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class VoidAndExceptionTests
    {
        private ErrorLogger _logger;

        [SetUp]
        public void SetUp()
        {
            _logger = new ErrorLogger();
        }

        [Test]
        public void Void_Test_SetLastErrorProperty()
        {
            _logger.Log("Error!");
            Assert.That(_logger.LastError, Is.EqualTo("Error!"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Exception_Test_InvalidArg_ThrowExp(string msg)
        {
            Assert.That(() => _logger.Log(msg), Throws.ArgumentNullException);
        }
    }
}
