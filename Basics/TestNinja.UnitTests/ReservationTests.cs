using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationUnitTest
    {
        [Test]
        public void CanBeCanceledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            //Assert
            Assert.IsTrue(result);
            
        }

        [Test]
        public void CanBeCanceledBy_UserIsSpecUser_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();
            User tempUser = new User();
            reservation.MadeBy = tempUser;

            //Act
            var result = reservation.CanBeCancelledBy(tempUser);

            //Assert
            Assert.IsTrue(result);

        }

        [Test]
        public void CanBeCanceledBy_UserIsNotAdminOrSpec_ReturnsFalse()
        {
            //Arrange
            var reservation = new Reservation();
            User tempUser = new User();

            //Act
            var result = reservation.CanBeCancelledBy(tempUser);

            //Assert
            Assert.IsFalse(result);

        }
    }
}
