using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class BookingRepository : IBookingRepository
    {
        public IQueryable<Booking> GetBookings(int? id=null)
        {
            var unitOfWork = new UnitOfWork();
            var bookings =unitOfWork.Query<Booking>().Where(b => b.Status != "Cancelled");
            if(id.HasValue)
            {
                bookings = bookings.Where(b => b.Id != id.Value);
            }
            return bookings;
        }
    }
}
