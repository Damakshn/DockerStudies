using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingPro.Domain.Flights;

namespace BookingPro.Domain.Booking.BookingHistory
{
    /// <summary>
    /// Информация о бронировании
    /// </summary>
    public class BookingInfo
    {
        public string BookRef { get; set; }

        public DateTime BookDate { get; set; }

        public int TotalAmount { get; set; }
        
        public List<BookedFlight> Flights { get; set; }
    }
}
