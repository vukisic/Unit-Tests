using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StringTests
    {
        [Test]
        public void String_Test_ReturnsEnclosedString()
        {
            var formatter = new HtmlFormatter();
            var result=formatter.FormatAsBold("Hello World");

            //Specific
            Assert.That(result, Is.EqualTo("<strong>Hello World</strong>").IgnoreCase);

            //More General
            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("Hello World"));
        }
    }
}
