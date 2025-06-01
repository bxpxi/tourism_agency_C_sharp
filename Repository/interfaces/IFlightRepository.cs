using System.Collections.Generic;
using Domain;

namespace Repository.interfaces
{
    public interface IFlightRepository : IRepository<int, Flight>
    {
        IEnumerable<Flight> FindByDestinationAndDepartureDate(string destination, string departureDate);
    }
}