using System.ComponentModel.DataAnnotations.Schema;

namespace Flightly.Models
{
    public class Flights
    {
        [Column("id")]
        public string Id { get; set; }

        [Column("flight_number")]
        public string FlightNumber { get; set; }

        [Column("departure_airport_code")]
        public string DepartureAirportCode { get; set; }

        [Column("arrival_airport_code")]
        public string ArrivalAirportCode { get; set; }

        [Column("departure_date")]
        public DateTime DepartureDate { get; set; }

        [Column("arrival_date")]
        public DateTime ArrivalDate { get; set; }

        [Column("departure_time")]
        public TimeSpan DepartureTime { get; set; }

        [Column("arrival_time")]
        public TimeSpan ArrivalTime { get; set; }

        [Column("flight_duration")]
        public decimal FlightDuration { get; set; }

        [Column("airline_name")]
        public string AirlineName { get; set; }

        [Column("aircraft_type")]
        public string AircraftType { get; set; }
    }
}
