using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingPro.Domain.Booking.BookingHistory;
using BookingPro.Domain.Flights;

namespace BookingPro.Domain.Booking
{
    /// <summary>
    /// Сервис для работы с бронированиями.
    /// </summary>
    public interface IBookingService
    {
        /// <summary>
        /// Забронировать билеты на конкретного пассажира.
        /// </summary>
        /// <param name="bookings">Данные о местах на рейс, которые нужно забронировать</param>
        /// <param name="flightInfos">Справочные данные о рейсах</param>
        /// <returns>Код бронирования (строка из 6 символов)</returns>
        string CreateBooking(IEnumerable<BookingInputModel> bookings, IEnumerable<FlightInfo> flightInfos);

        /// <summary>
        /// Получить полную историю бронирования по конкретному пассажиру
        /// </summary>
        /// <param name="passengerId">ID пассажира</param>
        /// <returns>История бронирований</returns>
        Task<List<BookedFlight>> GetBookingHistoryAsync(string passengerId, CancellationToken cancellationToken = default);
    }
}
