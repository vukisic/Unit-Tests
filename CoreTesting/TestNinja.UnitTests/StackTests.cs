using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private TStack<string> _stack;
        
        [SetUp]
        public void SetUp()
        {
            _stack = new TStack<string>();
        }

        [Test]
        public void Count_EmptyStack_ReturnsZero()
        {
            var result = _stack.Count;
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Count_NotEmptyStack_ReturnsNumber()
        {
            _stack.Push("a");
            var result = _stack.Count;
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Push_ArgsIsNull_ThrowsExcepion()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ArgsIsNotNull_ReturnsNumber()
        {
            _stack.Push("a");
            var result = _stack.Count;
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Pop_EmptyStack_ThrowsExcepion()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_NotEmptyStack_ReturnsItem()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");
            var result = _stack.Pop();
            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Pop_NotEmptyStack_Count()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");
            var temp = _stack.Pop();
            var result = _stack.Count;
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Peek_EmptyStack_ThrowsExcepion()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_NotEmptyStack_ReturnsItem()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");
            var result = _stack.Peek();
            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Peek_NotEmptyStack_Count()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");
            var temp = _stack.Peek();
            var result = _stack.Count;
            Assert.That(result, Is.EqualTo(3));
        }






    }
}
