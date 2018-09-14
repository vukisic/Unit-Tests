using System;
using System.Linq;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CollectionsTests
    {
        private TMath _math;

        [SetUp]
        public void SetUp()
        {
            _math = new TMath();
        }

        [Test]
        public void Collection_Test_PositiveLimit_ReturnsCoolectionOfOddNums()
        {
            var result = _math.GetOddNumbers(10);

            //General
            //Assert.That(result, Is.Not.Empty);
            //Assert.That(result.Count(), Is.EqualTo(5));

            //Specific
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5, 7, 9 }));

            //Sorted
            Assert.That(result, Is.Ordered);

            //No Duplicates
            Assert.That(result, Is.Unique);
        }

        [Test]
        public void Collection_Test_NegativeLimit_ReturnsCoolectionOfOddNums()
        {
            var result = _math.GetOddNumbers(-10);

            //General
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Collection_Test_ZeroLimit_ReturnsCoolectionOfOddNums()
        {
            var result = _math.GetOddNumbers(0);

            //General
            Assert.That(result, Is.Empty);
        }
    }
}
