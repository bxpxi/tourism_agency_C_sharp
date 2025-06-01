using System.Collections.Generic;
using Domain;
using Service.observer;

namespace Service
{
    public interface IAppService
    {
        void Register(string username, string password);
        Employee Login(string agencyName, string password, IObserver client = null);

        IEnumerable<Flight> FindFlights();
        IEnumerable<Flight> FindByDestinationAndDepartureDate(string destination, string departureDate);

        void BuyTicket(Flight flight, string client, int noOfSeats);

    }
}