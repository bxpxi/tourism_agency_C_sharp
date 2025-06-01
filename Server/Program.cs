using System;
using Repository;
using Repository.databases;
using Service;
using Service.services;

namespace Server
{
    internal class Program
    {
        public static bool TestConnection()
        {
            try
            {
                using (var connection = JdbcUtils.getConnection())
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        
        public static void Main(string[] args)
        {
            if (TestConnection())
                Console.WriteLine("Test connection successful");
            else
                Console.WriteLine("Test connection failed");
        
            EmployeeRepository EmployeeRepository = new EmployeeRepository();
            FlightRepository FlightRepository = new FlightRepository();
            TicketRepository TicketRepository = new TicketRepository(FlightRepository);
        
            EmployeeService EmployeeService = new EmployeeService(EmployeeRepository);
            FlightService FlightService = new FlightService(FlightRepository);
            TicketService TicketService = new TicketService(TicketRepository);
        
            AppService AppService = new AppService(EmployeeService, FlightService, TicketService);
        
            Serverr Server = new Serverr(Config.Host, Config.Port, new ServiceImpl(AppService));
            Server.Start();
        
            Console.WriteLine("Server started...");
            Console.ReadLine();
            Console.WriteLine("Sever stopped...");
            Environment.Exit(0);
        }
    }
}