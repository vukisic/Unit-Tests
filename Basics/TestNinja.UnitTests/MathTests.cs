using System;
using NUnit.Framework;
using TestNinja;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private TMath _math;

        [SetUp]
        public void SetUp()
        {
            _math = new TMath();
        }

        [Test]
        //[Ignore("Working on it!")]
        public void Add_ReturnsSum()
        {
            //Arrange -> Initialization
            
            //Act
            var result = _math.Add(1, 2);

            //Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(2,1,2)]
        [TestCase(1,2,2)]
        [TestCase(1,1,1)]
        public void Max_WhenCalled_ReturnsGraterArg(int a, int b,int ex_result)
        {
            var result = _math.Max(a, b);
            Assert.That(result, Is.EqualTo(ex_result));
        }

    }
}
