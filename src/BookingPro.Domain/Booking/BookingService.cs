using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingPro.Domain.Booking.BookingHistory;
using BookingPro.Domain.Flights;

namespace BookingPro.Domain.Booking
{
    public class BookingService : IBookingService
    {
        public string CreateBooking(IEnumerable<BookingInputModel> bookings, IEnumerable<FlightInfo> flightInfos)
        {
            throw new NotImplementedException();
        }

        public List<BookingInfo> GetBookingHistory(string passengerId)
        {
            throw new NotImplementedException();
        }
    }
}
