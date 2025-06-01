using System;

namespace Network.objectprotocol
{
    [Serializable]
    public class LoginEmployeeRequest : IRequest
    {
        public string AgencyName { get; }
        public string Password { get; }

        public LoginEmployeeRequest(string agencyName, string password)
        {
            AgencyName = agencyName;
            Password = password;
        }
    }
}