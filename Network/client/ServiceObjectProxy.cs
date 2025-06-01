using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Network.dto;
using Network.objectprotocol;
using Service;
using Service.observer;

namespace Network.client
{
    public class ServiceObjectProxy : ServiceObjectProxyBase, IAppService
    {
        public ServiceObjectProxy(string host, int port) : base(host, port) { }

        public void Register(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Employee Login(string agencyName, string password, IObserver client)
        {
            InitializeConnection();
            Client = client;
            SendRequest(new LoginEmployeeRequest(agencyName, password));
            try
            {
                var resp = AwaitResponse<LoginEmployeeResponse>();
                return resp.Employee.ToEmployee();
            }
            catch (Exception e)
            {
                CloseConnection();
                throw new ProxyException(e);
            }
        }

        public IEnumerable<Flight> FindFlights()
        {
            TestConnectionOpen();
            SendRequest(new GetAllFlightsRequest());
            var resp = AwaitResponse<GetAllFlightsResponse>();
            return resp.Flights.Select(f => f.ToFlight());
        }

        public IEnumerable<Flight> FindByDestinationAndDepartureDate(string destination, string departureDate)
        {
            TestConnectionOpen();
            SendRequest(new FilteredFlightsRequest(destination, departureDate));
            var resp = AwaitResponse<FilteredFlightsResponse>();
            return resp.Flights.Select(f => f.ToFlight());
        }

        public void BuyTicket(Flight flight, string client, int noOfSeats)
        {
            TestConnectionOpen();
            SendRequest(new BuyTicketRequest(new TicketDTO(client, flight, noOfSeats)));
            AwaitResponse<BuyTicketResponse>();
        }

        protected override void HandleUpdate(UpdatedFlightResponse updatedFlight)
        {
            try
            {
                Client.UpdateFlight(updatedFlight.Flight.ToFlight());
            }
            catch (Exception e)
            {
                throw new ProxyException(e);
            }
        }
        
        private R AwaitResponse<R>() where R : class, IResponse
        {
            var resp = ReadResponse();
            if (resp is ErrorResponse)
                throw new ErrorResponseException((resp as ErrorResponse).Message);
            if (!(resp is R))
                throw new ProxyException($"Wrong response: expected {typeof(R).Name}, received {resp.GetType().Name}");
            return resp as R;
        }

    }
}