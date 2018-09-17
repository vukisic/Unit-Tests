using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class BookingTests
    {
        private Booking _booking;
        private Mock<IBookingRepository> _mockrepository;

        [SetUp]
        public void SetUp()
        {
            _booking = new Booking
            {
                Id = 2,
                ArrivalDate = Arrival(2018, 5, 15),
                DepartureDate = Departure(2018, 5, 20),
                Reference = "a"
            };

            _mockrepository = new Mock<IBookingRepository>();
            _mockrepository.Setup(b => b.GetBookings(1)).Returns(new List<Booking>
            {
                _booking
            }.AsQueryable());
        }


        //New booking starts After existing is Finished and ends after
        [Test]
        public void BookingTest_AfterNoOverlapping_ReturnsEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate =After(_booking.DepartureDate),
                DepartureDate =After(_booking.DepartureDate,2),

            }, _mockrepository.Object);

            Assert.That(result, Is.Empty);
            
        }


        //New Booking starts and ends before Existing booking
        [Test]
        public void BookingTest_BeforeNoOverlapping_ReturnsEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_booking.ArrivalDate,4),
                DepartureDate = Before(_booking.ArrivalDate),

            }, _mockrepository.Object);

            Assert.That(result, Is.Empty);

        }


        //New Booking starts before existing booking and ends in the middle of existing booking
        [Test]
        public void BookingTest_MiddleOverlapping_ReturnsBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_booking.ArrivalDate,2),
                DepartureDate = After(_booking.ArrivalDate),

            }, _mockrepository.Object);

            Assert.That(result, Is.EqualTo("a"));

        }


        //New booking starts before existing and ends after existing
        [Test]
        public void BookingTest_BeforeAfterOverlapping_ReturnsBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_booking.ArrivalDate),
                DepartureDate = After(_booking.DepartureDate),

            }, _mockrepository.Object);

            Assert.That(result, Is.EqualTo("a"));

        }

        //New booking starts after existing and ends before existing
        [Test]
        public void BookingTest_StartAndFinishesMiddleOverlapping_ReturnsBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_booking.ArrivalDate),
                DepartureDate = Before(_booking.DepartureDate),

            }, _mockrepository.Object);

            Assert.That(result, Is.EqualTo("a"));

        }


        //New booking starts After existing and ends after exisitng
        [Test]
        public void BookingTest_StartOverlapping_ReturnsBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_booking.ArrivalDate),
                DepartureDate = After(_booking.DepartureDate),

            }, _mockrepository.Object);

            Assert.That(result, Is.EqualTo("a"));

        }


        //New booking starts after existing and ends after existing but new is Cancelled
        [Test]
        public void BookingTest_CancelledOverlapping_ReturnsEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_booking.ArrivalDate),
                DepartureDate = After(_booking.DepartureDate),
                Status="Cancelled"
            }, _mockrepository.Object);

            Assert.That(result, Is.Empty);

        }

        private DateTime Arrival(int year,int month,int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }

        private DateTime Departure(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }
        
        private DateTime Before(DateTime date,int days=1)
        {
            return date.AddDays(-days);
        }

        private DateTime After (DateTime date,int days=1)
        {
            return date.AddDays(days);
        }


    }
}
