namespace Domain
{
    public class Employee : Entity<int>
    {
        public string AgencyName { get; set; }
        public string Password { get; set; }

        public Employee(string agencyName, string password)
        {
            AgencyName = agencyName;
            Password = password;
        }

        public override string ToString()
        {
            return $"Employee[AgencyName: {AgencyName}, Password: {Password}]";
        }
    }
}