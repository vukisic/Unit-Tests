using System;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Exercises
{
    [TestFixture]
    public class EmplyeeTests
    {
        [Test]
        public void EmployeeTest_WhenCalled_DeletesEmployee()
        {
            var remover = new Mock<IEmployeeRemover>();
            var controller = new EmployeeController(remover.Object);

            controller.DeleteEmployee(1);

            remover.Verify(s => s.RemoveEmployee(1));
        }
    }
}
