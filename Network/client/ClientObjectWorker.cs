using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using Domain;
using Network.dto;
using Network.objectprotocol;
using Service;
using Service.observer;

namespace Network.client
{
    public class ClientObjectWorker : ClientObjectWorkerBase, IObserver
    {
        private IAppService Server;

        public ClientObjectWorker(IAppService server, TcpClient connection) : base(connection)
        {
            Server = server;
        }

        public void UpdateFlight(Flight f)
        {
            Console.WriteLine("Worker: Updated flight " + f);
            var fDto = FlightDTO.FromFlight(f);
            try
            {
                SendResponse(new UpdatedFlightResponse(fDto));
            }
            catch (IOException e)
            {
                throw new ServerProcessingException(e);
            }
        }

        protected override IResponse HandleRequest(IRequest request)
        {
            if (request is GetAllFlightsRequest)
            {
                return ResponseOrError(() => new GetAllFlightsResponse(Server.FindFlights().ToArray()));
            }

            if (request is FilteredFlightsRequest)
            {
                return ResponseOrError(() => new FilteredFlightsResponse(Server.FindByDestinationAndDepartureDate((request as FilteredFlightsRequest).Destination, (request as FilteredFlightsRequest).DepartureDate).ToArray()));
            }

            if (request is LoginEmployeeRequest)
            {
                var agencyName = (request as LoginEmployeeRequest).AgencyName;
                var password = (request as LoginEmployeeRequest).Password;
                return ResponseOrError(() =>
                {
                    var employee = Server.Login(agencyName, password, this);
                    return new LoginEmployeeResponse(EmployeeDTO.FromEmployee(employee));
                });
            }

            if (request is BuyTicketRequest)
            {
                var ticket = (request as BuyTicketRequest).Ticket;
                var flight = ticket.Flight.ToFlight();
                var client = ticket.Client;
                var noOfSeats = ticket.NoOfSeats;
                
                Console.WriteLine($"Server is {Server.GetType().Name}");

                return ResponseOrError(() =>
                {
                    Server.BuyTicket(flight, client, noOfSeats);
                    return new BuyTicketResponse();
                });
            }
            
            return new ErrorResponse("No response");
        }
        
        private static IResponse ResponseOrError(Func<IResponse> getResponse)
        {
            try
            {
                return getResponse();
            }
            catch (Exception e)
            {
                return new ErrorResponse(e.Message);
            }
        }
    }
}