using System.Collections.Generic;
using Domain;
using Repository.interfaces;
using Service.interfaces;

namespace Service.services
{
    public class FlightService : AbstractService<int, Flight, IFlightRepository>, IFlightService
    {
        public FlightService(IFlightRepository repository) : base(repository)
        {
        
        }
    
        public IEnumerable<Flight> FindByDestinationAndDepartureDate(string destination, string departureDate)
        {
            return Repository.FindByDestinationAndDepartureDate(destination, departureDate);
        }
    }
}