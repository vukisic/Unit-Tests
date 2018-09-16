using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(15, "FizzBuzz")]
        [TestCase(3,"Fizz")]
        [TestCase(5,"Buzz")]
        [TestCase(17,"17")]
        public void FizzBuzz_Tests_ReturnsString(int num, string expectedResult)
        {
            var result = FizzBuzz.GetOutput(num);
            Assert.That(result, Is.EqualTo(expectedResult).IgnoreCase);
           
        }
    }
}
