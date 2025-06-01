using Domain;
using Repository.interfaces;
using Service.interfaces;

namespace Service.services
{
    public class EmployeeService : AbstractService<int, Employee, IEmployeeRepository>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository repository) : base(repository)
        {
        
        }

        public void Register(Employee employee)
        {
            string agencyName = employee.AgencyName;
            string password = employee.Password;
            Save(new Employee(agencyName, password));
        }

        public Employee Login(string agencyName, string password)
        {
            return Repository.FindByAgencyNameAndPassword(agencyName, password);
        }
    }
}