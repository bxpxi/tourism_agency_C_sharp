using System;
using System.Collections.Generic;
using Domain;
using Service.interfaces;
using Service.observer;

namespace Service
{
    public class AppService : IAppService
    {
        private IEmployeeService EmployeeService;
        private IFlightService FlightService;
        private ITicketService TicketService;

        public AppService(IEmployeeService employeeService, IFlightService flightService, ITicketService ticketService)
        {
            EmployeeService = employeeService;
            FlightService = flightService;
            TicketService = ticketService;
        }

        public void Register(string username, string password)
        {
            EmployeeService.Register(new Employee(username, password));
        }

        public Employee Login(string agencyName, string password, IObserver client = null)
        {
            return EmployeeService.Login(agencyName, password);
        }

        public IEnumerable<Flight> FindFlights()
        {
            return FlightService.FindAll();
        }

        public IEnumerable<Flight> FindByDestinationAndDepartureDate(string destination, string departureDate)
        {
            return FlightService.FindByDestinationAndDepartureDate(destination, departureDate);
        }

        public void BuyTicket(Flight flight, string client, int noOfSeats)
        {
            Ticket ticket = new Ticket(client, flight, noOfSeats);

            if (noOfSeats > flight.AvailableSeats)
            {
                throw new ArgumentException("No seats available");
            }
        
            TicketService.Save(ticket);
        
            flight.AvailableSeats -= noOfSeats;
            FlightService.Update(flight);
        }
    }
}