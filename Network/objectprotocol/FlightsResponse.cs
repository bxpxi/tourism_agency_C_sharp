using System;
using System.Linq;
using Domain;
using Network.dto;

namespace Network.objectprotocol
{
    [Serializable]
    public class FlightsResponse : IResponse
    {
        public FlightDTO[] Flights { get; }
        
        public FlightsResponse(Flight[] flights)
            => Flights = flights.Select(FlightDTO.FromFlight).ToArray();
    }
}