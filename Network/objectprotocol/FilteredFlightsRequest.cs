using System;

namespace Network.objectprotocol
{
    [Serializable]
    public class FilteredFlightsRequest : IRequest
    {
        public string Destination { get; }
        public string DepartureDate { get; }

        public FilteredFlightsRequest(string destination, string departureDate)
        {
            Destination = destination;
            DepartureDate = departureDate;
        }
    }
}