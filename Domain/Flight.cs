namespace Domain
{
    public class Flight : Entity<int>
    {
        public string Destination {get; set;}
        public string DepartureDate {get; set;}
        public string DepartureTime {get; set;}
        public string Airport {get; set;}
        public  int AvailableSeats {get; set;}

        public Flight(string destination, string departureDate, string departureTime, string airport, int availableSeats)
        {
            Destination = destination;
            DepartureDate = departureDate;
            DepartureTime = departureTime;
            Airport = airport;
            AvailableSeats = availableSeats;
        }

        public override string ToString()
        {
            return
                $"Flight [Destination = {Destination}, Departure Date = {DepartureDate}, Departure Time = {DepartureTime}, Airport = {Airport}, AvailableSeats = {AvailableSeats}]";
        }
    }
}