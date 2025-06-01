using System;
using System.Collections.Generic;
using System.Data;
using Domain;
using log4net;
using Repository.interfaces;

namespace Repository.databases
{
    public class TicketRepository : ITicketRepository
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(TicketRepository));
    private IFlightRepository flightRepo;

    public TicketRepository(IFlightRepository flightRepo)
    {
        logger.Info("TicketRepository initialized");
        this.flightRepo = flightRepo;
    }

    public Ticket FindById(int id)
    {
        logger.Info("Finding Ticket By Id");
        IDbConnection connection = JdbcUtils.getConnection();
        using (IDbCommand command = connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM tickets1 WHERE id = @id";
            IDataParameter idParameter = command.CreateParameter();
            idParameter.ParameterName = "@id";
            idParameter.Value = id;
            command.Parameters.Add(idParameter);
            using (IDataReader result = command.ExecuteReader())
            {
                if (result.Read())
                {
                    string client = Convert.ToString(result["clientId"]);
                    int flightId = Convert.ToInt32(result["flightId"]);
                    int noOfSeats = Convert.ToInt32(result["noOfSeats"]);
                    Flight flight = flightRepo.FindById(flightId);
                    Ticket ticket = new Ticket(client, flight, noOfSeats);
                    ticket.Id = Convert.ToInt32(result["id"]);
                    return ticket;
                }
            }
        }
        return null;
    }

    public IEnumerable<Ticket> FindAll()
    {
        logger.Info("Finding All Tickets");
        IDbConnection connection = JdbcUtils.getConnection();
        List<Ticket> tickets = new List<Ticket>();
        using (IDbCommand command = connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM tickets1";
            using (IDataReader result = command.ExecuteReader())
            {
                while (result.Read())
                {
                    int id = Convert.ToInt32(result["id"]);
                    string client = Convert.ToString(result["clientId"]);
                    int flightId = Convert.ToInt32(result["flightId"]);
                    int noOfSeats = Convert.ToInt32(result["noOfSeats"]);
                    Flight flight = flightRepo.FindById(flightId);
                    Ticket ticket = new Ticket(client, flight, noOfSeats);
                    ticket.Id = Convert.ToInt32(result["id"]);
                    tickets.Add(ticket);
                }
            }
            
        }
        return tickets;
    }

    public void Save(Ticket ticket)
    {
        logger.Info("Saving Ticket");
        IDbConnection connection = JdbcUtils.getConnection();
        using (IDbCommand command = connection.CreateCommand())
        {
            command.CommandText = "INSERT INTO tickets1 (clientId, flightId, noOfSeats) VALUES (@clientId, @flightId, @noOfSeats)";
            IDataParameter clientIdParameter = command.CreateParameter();
            clientIdParameter.ParameterName = "@clientId";
            clientIdParameter.Value = ticket.Client;
            command.Parameters.Add(clientIdParameter);
            IDataParameter flightIdParameter = command.CreateParameter();
            flightIdParameter.ParameterName = "@flightId";
            flightIdParameter.Value = ticket.Flight.Id;
            command.Parameters.Add(flightIdParameter);
            IDataParameter noOfSeatsParameter = command.CreateParameter();
            noOfSeatsParameter.ParameterName = "@noOfSeats";
            noOfSeatsParameter.Value = ticket.NoOfSeats;
            command.Parameters.Add(noOfSeatsParameter);
            int result = command.ExecuteNonQuery();
            logger.Info("Saved tickets: " + result);
        }
    }

    public void Delete(int id)
    {
        logger.Info("Deleting Flight");
        IDbConnection connection = JdbcUtils.getConnection();
        using (IDbCommand command = connection.CreateCommand())
        {
            command.CommandText = "DELETE FROM tickets1 WHERE id = @id";
            IDataParameter idParameter = command.CreateParameter();
            idParameter.ParameterName = "@id";
            idParameter.Value = id;
            command.Parameters.Add(idParameter);
            int result = command.ExecuteNonQuery();
            logger.Info("Deleted flights: " + result);
        }
    }

    public void Update(Ticket ticket)
    {
        logger.Info("Updating Ticket");
        IDbConnection connection = JdbcUtils.getConnection();
        using (IDbCommand command = connection.CreateCommand())
        {
            command.CommandText = "UPDATE tickets1 SET clientId = @clientId, flightId = @flightId, noOfSeats = @noOfSeats WHERE id = @id";
            IDataParameter clientIdParameter = command.CreateParameter();
            clientIdParameter.ParameterName = "@clientId";
            clientIdParameter.Value = ticket.Client;
            command.Parameters.Add(clientIdParameter);
            IDataParameter flightIdParameter = command.CreateParameter();
            flightIdParameter.ParameterName = "@flightId";
            flightIdParameter.Value = ticket.Flight.Id;
            command.Parameters.Add(flightIdParameter);
            IDataParameter noOfSeatsParameter = command.CreateParameter();
            noOfSeatsParameter.ParameterName = "@noOfSeats";
            noOfSeatsParameter.Value = ticket.NoOfSeats;
            command.Parameters.Add(noOfSeatsParameter);
            IDataParameter idParameter = command.CreateParameter();
            idParameter.ParameterName = "@id";
            idParameter.Value = ticket.Id;
            command.Parameters.Add(idParameter);
            int result = command.ExecuteNonQuery();
            logger.Info("Updated flights: " + result);
        }
    }

    public IEnumerable<Ticket> FindByFlight(Flight flight)
    {
        logger.Info("Finding Ticket By Id");
        IDbConnection connection = JdbcUtils.getConnection();
        List<Ticket> tickets = new List<Ticket>();
        using (IDbCommand command = connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM tickets1 WHERE flightId = @flightId";
            IDataParameter idParameter = command.CreateParameter();
            idParameter.ParameterName = "@flightId";
            idParameter.Value = flight.Id;
            command.Parameters.Add(idParameter);
            using (IDataReader result = command.ExecuteReader())
            {
                while (result.Read())
                {
                    int id = Convert.ToInt32(result["id"]);
                    string client = Convert.ToString(result["clientId"]);
                    int flightId = Convert.ToInt32(result["flightId"]);
                    int noOfSeats = Convert.ToInt32(result["noOfSeats"]);
                    Flight flight1 = flightRepo.FindById(flightId);
                    Ticket ticket = new Ticket(client, flight1, noOfSeats);
                    ticket.Id = Convert.ToInt32(result["id"]);
                    tickets.Add(ticket);
                }
            }
        }
        return tickets;
    }

    }
}