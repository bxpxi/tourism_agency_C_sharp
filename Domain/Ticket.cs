namespace Domain
{
    public class Ticket : Entity<int>
    {
        public string Client {get; set;}
        public Flight Flight {get; set;}
        public int NoOfSeats {get; set;}

        public Ticket(string client, Flight flight, int noOfSeats)
        {
            Client = client;
            Flight = flight;
            NoOfSeats = noOfSeats;
        }

        public override string ToString()
        {
            return $"Ticket [Client: {Client}, Flight: {Flight}, NoOfTickets: {NoOfSeats}]";
        }
    }
}