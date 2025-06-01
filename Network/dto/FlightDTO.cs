using System;
using Domain;

namespace Network.dto
{
    [Serializable]
    public class FlightDTO : EntityDTO
    {
        public string Destination {get; }
        public string DepartureDate {get; }
        public string DepartureTime {get; }
        public string Airport {get; }
        public  int AvailableSeats {get; }

        public FlightDTO(string destination, string departureDate, string departureTime, string airport, int availableSeats)
        {
            Destination = destination;
            DepartureDate = departureDate;
            DepartureTime = departureTime;
            Airport = airport;
            AvailableSeats = availableSeats;
        }
        
        public static FlightDTO FromFlight(Flight flight)
            => new FlightDTO(flight.Destination, flight.DepartureDate, flight.DepartureTime, flight.Airport, flight.AvailableSeats) {Id = flight.Id};
        
        public Flight ToFlight()
            => new Flight(Destination, DepartureDate, DepartureTime, Airport, AvailableSeats) {Id = Id};
    }
}