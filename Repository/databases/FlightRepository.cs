using System;
using System.Collections.Generic;
using System.Data;
using Domain;
using log4net;
using Repository.interfaces;

namespace Repository.databases
{
    public class FlightRepository : IFlightRepository
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(FlightRepository));

    public FlightRepository()
    {
        logger.Info("FlightRepository initialized");
    }

    public Flight FindById(int id)
    {
        logger.Info("Finding Flight By Id");
        IDbConnection connection = JdbcUtils.getConnection();
        using (IDbCommand command = connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM flights WHERE id = @id";
            IDataParameter idParameter = command.CreateParameter();
            idParameter.ParameterName = "@id";
            idParameter.Value = id;
            command.Parameters.Add(idParameter);
            using (IDataReader result = command.ExecuteReader())
            {
                if (result.Read())
                {
                    string destination = result["destination"].ToString();
                    string departureDate = result["departureDate"].ToString();
                    string departureTime = result["departureTime"].ToString();
                    string airport = result["airport"].ToString();
                    int availableSeats = int.Parse(result["availableSeats"].ToString());
                    Flight flight = new Flight(destination, departureDate, departureTime, airport, availableSeats);
                    flight.Id = Convert.ToInt32(result["id"]);
                    return flight;
                }
            }
        }
        return null;
    }

    public IEnumerable<Flight> FindAll()
    {
        logger.Info("Finding All Flights");
        IDbConnection connection = JdbcUtils.getConnection();
        List<Flight> flights = new List<Flight>();
        using (IDbCommand command = connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM flights WHERE availableSeats > 0";
            using (IDataReader result = command.ExecuteReader())
            {
                while (result.Read())
                {
                    int id = Convert.ToInt32(result["id"]);
                    string destination = result["destination"].ToString();
                    string departureDate = result["departureDate"].ToString();
                    string departureTime = result["departureTime"].ToString();
                    string airport = result["airport"].ToString();
                    int availableSeats = int.Parse(result["availableSeats"].ToString());
                    Flight flight = new Flight(destination, departureDate, departureTime, airport, availableSeats);
                    flight.Id = id;
                    flights.Add(flight);
                }
            }
            
        }
        return flights;
    }

    public void Save(Flight flight)
    {
        logger.Info("Saving Flight");
        IDbConnection connection = JdbcUtils.getConnection();
        using (IDbCommand command = connection.CreateCommand())
        {
            command.CommandText = "INSERT INTO flights (destination, departureDate, departureTime, airport, availableSeats) VALUES (@destination, @departureDate, @departureTime, @airport, @availableSeats)";
            IDataParameter destinationParameter = command.CreateParameter();
            destinationParameter.ParameterName = "@destination";
            destinationParameter.Value = flight.Destination;
            IDataParameter departureDateParameter = command.CreateParameter();
            departureDateParameter.ParameterName = "@departureDate";
            departureDateParameter.Value = flight.DepartureDate;
            IDataParameter departureTimeParameter = command.CreateParameter();
            departureTimeParameter.ParameterName = "@departureTime";
            departureTimeParameter.Value = flight.DepartureTime;
            IDataParameter airportParameter = command.CreateParameter();
            airportParameter.ParameterName = "@airport";
            airportParameter.Value = flight.Airport;
            IDataParameter availableSeatsParameter = command.CreateParameter();
            availableSeatsParameter.ParameterName = "@availableSeats";
            availableSeatsParameter.Value = flight.AvailableSeats;
            command.Parameters.Add(destinationParameter);
            command.Parameters.Add(departureDateParameter);
            command.Parameters.Add(departureTimeParameter);
            command.Parameters.Add(airportParameter);
            command.Parameters.Add(availableSeatsParameter);
            int result = command.ExecuteNonQuery();
            logger.Info("Saved flights: " + result);
        }
    }

    public void Delete(int id)
    {
        logger.Info("Deleting Flight");
        IDbConnection connection = JdbcUtils.getConnection();
        using (IDbCommand command = connection.CreateCommand())
        {
            command.CommandText = "DELETE FROM flights WHERE id = @id";
            IDataParameter idParameter = command.CreateParameter();
            idParameter.ParameterName = "@id";
            idParameter.Value = id;
            command.Parameters.Add(idParameter);
            int result = command.ExecuteNonQuery();
            logger.Info("Deleted flights: " + result);
        }
    }

    public void Update(Flight flight)
    {
        logger.Info("Updating Flight");
        IDbConnection connection = JdbcUtils.getConnection();
        using (IDbCommand command = connection.CreateCommand())
        {
            command.CommandText = "UPDATE flights SET destination = @destination, departureDate = @departureDate, departureTime = @departureTime, airport = @airport, availableSeats = @availableSeats WHERE id = @id";
            IDataParameter destinationParameter = command.CreateParameter();
            destinationParameter.ParameterName = "@destination";
            destinationParameter.Value = flight.Destination;
            IDataParameter departureDateParameter = command.CreateParameter();
            departureDateParameter.ParameterName = "@departureDate";
            departureDateParameter.Value = flight.DepartureDate;
            IDataParameter departureTimeParameter = command.CreateParameter();
            departureTimeParameter.ParameterName = "@departureTime";
            departureTimeParameter.Value = flight.DepartureTime;
            IDataParameter airportParameter = command.CreateParameter();
            airportParameter.ParameterName = "@airport";
            airportParameter.Value = flight.Airport;
            IDataParameter availableSeatsParameter = command.CreateParameter();
            availableSeatsParameter.ParameterName = "@availableSeats";
            availableSeatsParameter.Value = flight.AvailableSeats;
            command.Parameters.Add(destinationParameter);
            command.Parameters.Add(departureDateParameter);
            command.Parameters.Add(departureTimeParameter);
            command.Parameters.Add(airportParameter);
            command.Parameters.Add(availableSeatsParameter);
            IDataParameter idParameter = command.CreateParameter();
            idParameter.ParameterName = "@id";
            idParameter.Value = flight.Id;
            command.Parameters.Add(idParameter);
            int result = command.ExecuteNonQuery();
            logger.Info("Updated flights: " + result);
        }
    }

    public IEnumerable<Flight> FindByDestinationAndDepartureDate(string destination, string departureDate)
    {
        logger.Info("Finding Flight By Id");
        IDbConnection connection = JdbcUtils.getConnection();
        List<Flight> flights = new List<Flight>();
        using (IDbCommand command = connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM flights WHERE destination = @destination and departureDate = @departureDate";
            IDataParameter destinationParameter = command.CreateParameter();
            destinationParameter.ParameterName = "@destination";
            destinationParameter.Value = destination;
            command.Parameters.Add(destinationParameter);
            IDataParameter departureDateParameter = command.CreateParameter();
            departureDateParameter.ParameterName = "@departureDate";
            departureDateParameter.Value = departureDate;
            command.Parameters.Add(departureDateParameter);
            using (IDataReader result = command.ExecuteReader())
            {
                if (result.Read())
                {
                    string destination1 = result["destination"].ToString();
                    string departureDate1 = result["departureDate"].ToString();
                    string departureTime = result["departureTime"].ToString();
                    string airport = result["airport"].ToString();
                    int availableSeats = Convert.ToInt32(result["availableSeats"]);
                    Flight flight = new Flight(destination1, departureDate1, departureTime, airport, availableSeats);
                    flight.Id = Convert.ToInt32(result["id"]);
                    flights.Add(flight);
                }
            }
        }
        return flights;
    }
    }
}