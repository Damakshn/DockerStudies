#!/bin/bash
set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname demo <<-EOSQL
	CREATE OR REPLACE FUNCTION bookings.create_booking(flight_id integer[], passenger_id varchar(20)[], passenger_name text[], contact_data jsonb[], fare_conditions varchar(10)[])
	RETURNS varchar(6)
	LANGUAGE plpgsql
AS '
	declare 
		next_booking_id_hex varchar(6);
		next_ticket_id bigint;
		next_ticket_id_str char(13);
	BEGIN
		START TRANSACTION;
			select to_hex(max((''x'' || book_ref)::bit(24)::int) + 1)
			into next_booking_id_hex
			from bookings b;
		
			select max(ticket_no::bigint) + 1
			into next_ticket_id
			from tickets t;

			insert into bookings (book_ref, book_date, total_amount)
			values (next_booking_id_hex, bookings.now(), 0);
			
			for i in 0..ARRAY_LENGTH(flight_id, 1)-1 loop
				select (next_ticket_id + i)::char(13) into next_ticket_id_str;
			
				insert into tickets (ticket_no, book_ref, passenger_id, passenger_name, contact_data)
				values (next_ticket_id_str, next_booking_id_hex, passenger_id[i], passenger_name[i], contact_data[i]);
			
				insert into ticket_flights (ticket_no, flight_id, fare_conditions, amount)
				values (next_ticket_id_str, flight_id[i], fare_conditions[i], 20000);
			end loop;
		COMMIT;
		return next_booking_id_hex;
	END;'
EOSQL