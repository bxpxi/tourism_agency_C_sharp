using System.Collections.Generic;
using Domain;

namespace Service.interfaces
{
    public interface IFlightService : IService<int, Flight>
    {
        IEnumerable<Flight> FindByDestinationAndDepartureDate(string destination, string departureDate);
    }
}