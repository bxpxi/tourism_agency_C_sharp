using Domain;

namespace Repository.interfaces
{
    public interface IEmployeeRepository : IRepository<int, Employee>
    {
        Employee FindByAgencyNameAndPassword(string agencyName, string password);    
    }
}