using Domain;

namespace Service.interfaces
{
    public interface IEmployeeService : IService<int, Employee>
    {
        void Register(Employee employee);
        Employee Login(string agencyName, string password);
    }
}