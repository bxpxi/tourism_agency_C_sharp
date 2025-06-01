using System;
using Domain;

namespace Network.objectprotocol
{
    [Serializable]
    public class FilteredFlightsResponse : FlightsResponse
    {
        public FilteredFlightsResponse(Flight[] flights) : base(flights)
        {
            
        }
    }
}