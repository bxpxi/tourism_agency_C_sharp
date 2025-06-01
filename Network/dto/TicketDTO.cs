using System;
using Domain;

namespace Network.dto
{
    [Serializable]
    public class TicketDTO : EntityDTO
    {
        public string Client {get; }
        public FlightDTO Flight {get; }
        public int NoOfSeats {get; }

        public TicketDTO(string client, Flight flight, int noOfSeats)
        {
            Client = client;
            Flight = FlightDTO.FromFlight(flight);
            NoOfSeats = noOfSeats;
        }
    }
}