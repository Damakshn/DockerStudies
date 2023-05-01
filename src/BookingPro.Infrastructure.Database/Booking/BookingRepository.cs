using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using BookingPro.Domain.Booking;
using BookingPro.Domain.Booking.BookingHistory;
using BookingPro.Domain.Flights;

namespace BookingPro.Infrastructure.Database.Booking
{
    public class BookingRepository : IBookingRepository, IDisposable
    {
		private readonly NpgsqlConnection _connection;

        public BookingRepository(NpgsqlConnection connection)
        {
            _connection = connection;
			_connection.Open();
        }

        public string Add(IEnumerable<BookingInputModel> bookings)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
			_connection.Close();
        }

        public async Task<List<BookedFlight>> GetTicketsForPassengerAsync(string passengerId, CancellationToken cancellationToken = default)
        {
            string query = @"select
				b.book_ref as ""BookRef"",
				b.book_date as ""BookDate"",
				t.passenger_id as ""PassengerId"",
				t.passenger_name as ""PassengerName"",
				f.scheduled_departure as ""When"",
				f.departure_airport as ""From"",
				f.arrival_airport as ""To"",
				arc.model as ""AircraftModel"",
				case 
					when f.status = 'Scheduled' then 1
					when f.status = 'OnTime' then 2
					when f.status = 'Delayed' then 3
					when f.status = 'Departed' then 4
					when f.status = 'Arrived' then 5
					when f.status = 'Cancelle' then 6
				end as ""FlightStatus"",
				case 
					when tf.fare_conditions = 'Economy' then 1
					when tf.fare_conditions = 'Comfort' then 2
					when tf.fare_conditions = 'Business' then 3
				end as ""FareConditions"",
				bp.seat_no as ""SeatNo"",
				tf.amount as ""Amount""
			from 
				bookings.ticket_flights tf
				join bookings.tickets t on tf.ticket_no = t.ticket_no
				join bookings.bookings b on b.book_ref = t.book_ref
				join bookings.flights f on f.flight_id = tf.flight_id 
				join bookings.aircrafts arc on arc.aircraft_code = f.aircraft_code 
				left join bookings.boarding_passes bp on bp.ticket_no = tf.ticket_no and bp.flight_id = tf.flight_id
			where t.passenger_id = $1";

            using NpgsqlCommand cmd = new(query, _connection);
			cmd.Parameters.Add(new() { Value = passengerId });

			using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
			List<BookedFlight> result = new();
			while (reader.Read())
			{
				BookedFlight flight = new()
				{
					BookRef = reader.GetString(reader.GetOrdinal("BookRef")),
					BookDate = reader.GetDateTime(reader.GetOrdinal("BookDate")),
					PassengerId = reader.GetString(reader.GetOrdinal("PassengerId")),
					PassengerName = reader.GetString(reader.GetOrdinal("PassengerName")),
					When = reader.GetDateTime(reader.GetOrdinal("When")),
					From = reader.GetString(reader.GetOrdinal("From")),
					To = reader.GetString(reader.GetOrdinal("To")),
					AircraftModel = reader.GetString(reader.GetOrdinal("AircraftModel")),
					FlightStatus = (FlightStatus)reader.GetInt32(reader.GetOrdinal("FlightStatus")),
					FareConditions = (FareConditions)reader.GetInt32(reader.GetOrdinal("FareConditions")),
					SeatNo = "No", // ToDo read null value correctly reader.GetString(reader.GetOrdinal("SeatNo")) ?? "<No>",
                    Amount = reader.GetInt32(reader.GetOrdinal("Amount"))
				};
				result.Add(flight);
			}
			return result;
        }
    }
}
