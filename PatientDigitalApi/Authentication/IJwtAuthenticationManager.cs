using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientDigitalApi.Authentication
{
    public interface IJwtAuthenticationManager
    {
       string AuthenticateUser(string username, string passKey);
    }
}
