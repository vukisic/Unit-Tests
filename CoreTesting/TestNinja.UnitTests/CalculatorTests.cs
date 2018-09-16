using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    
    [TestFixture]
    public class CalculatorTests
    {
        private DemeritPointsCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new DemeritPointsCalculator();
        }
        [Test]
        [TestCase(-10)]
        [TestCase(1000)]
        public void CalculatorTest_InvalidArgs_TrowsExcepion(int speed)
        {
            Assert.That(() => _calculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(64,0)]
        [TestCase(65,0)]
        [TestCase(66,0)]
        [TestCase(80,3)]
        public void CalculatorTest_OkArgs_ReturnsNum(int speed,int expected)
        {
            var result = _calculator.CalculateDemeritPoints(speed);
            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
