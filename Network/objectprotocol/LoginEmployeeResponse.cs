using System;
using Network.dto;

namespace Network.objectprotocol
{
    [Serializable]
    public class LoginEmployeeResponse : IResponse
    {
        public EmployeeDTO Employee { get; }
        
        public LoginEmployeeResponse(EmployeeDTO employee) => Employee = employee;
    }
}