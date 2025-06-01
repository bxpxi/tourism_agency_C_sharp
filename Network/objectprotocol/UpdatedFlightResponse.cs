using System;
using Network.dto;

namespace Network.objectprotocol
{
    [Serializable]
    public class UpdatedFlightResponse : IResponse
    {
        public FlightDTO Flight { get; }
        
        public UpdatedFlightResponse(FlightDTO flight) => Flight = flight;
    }
}