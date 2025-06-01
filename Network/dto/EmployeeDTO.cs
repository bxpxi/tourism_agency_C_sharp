using System;
using Domain;

namespace Network.dto
{
    [Serializable]
    public class EmployeeDTO : EntityDTO
    {
        public string AgencyName { get; set; }
        public string Password {get; set;}

        public EmployeeDTO(string agencyName, string password)
        {
            AgencyName = agencyName;
            Password = password;
        }

        public static EmployeeDTO FromEmployee(Employee e)
            => new EmployeeDTO(e.AgencyName, e.Password) {Id = e.Id};
        
        public Employee ToEmployee()
            => new Employee(AgencyName, Password) {Id = Id};
    }
}