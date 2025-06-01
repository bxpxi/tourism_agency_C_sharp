using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Service;
using Service.observer;

namespace Server
{
    public class ServiceImpl : IAppService
    {
        private readonly IAppService InnerService;
        private readonly Dictionary<string, IObserver> LoggedClients = new Dictionary<string, IObserver>();

        public ServiceImpl(IAppService innerService)
        {
            InnerService = innerService;
        }
        
        public void Register(string username, string password) => throw new NotImplementedException();

        public Employee Login(string agencyName, string password, IObserver client)
        {
            var employee = InnerService.Login(agencyName, password);
            if (employee == null)
            {
                throw new ServiceException("Invalid username or password");
            }

            if (LoggedClients.ContainsKey(employee.AgencyName))
            {
                throw new ServiceException("Already logged in");
            }
            
            LoggedClients[employee.AgencyName] = client;
            Console.WriteLine($"Logged in {employee.AgencyName}");
            
            return employee;
        }

        public IEnumerable<Flight> FindFlights() => InnerService.FindFlights();
        
        public IEnumerable<Flight> FindByDestinationAndDepartureDate(string destination, string departureDate) => InnerService.FindByDestinationAndDepartureDate(destination, departureDate);

        public void BuyTicket(Flight flight, string client, int noOfSeats)
        {
            InnerService.BuyTicket(flight, client, noOfSeats);
            Console.WriteLine($"Updated flight: {flight}");
            Task.Run(() =>
            {
                foreach (var obs in LoggedClients.Values)
                    obs.UpdateFlight(flight);
            });

        }

    }
}