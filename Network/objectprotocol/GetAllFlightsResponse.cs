using System;
using Domain;

namespace Network.objectprotocol
{
    [Serializable]
    public class GetAllFlightsResponse : FlightsResponse
    {
        public GetAllFlightsResponse(Flight[] flights) : base(flights)
        {
            
        }
    }
}