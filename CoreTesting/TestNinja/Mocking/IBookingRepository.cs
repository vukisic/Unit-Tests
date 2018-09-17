using System.Linq;

namespace TestNinja.Mocking
{
    public interface IBookingRepository
    {
        IQueryable<Booking> GetBookings(int? id = null);
    }
}