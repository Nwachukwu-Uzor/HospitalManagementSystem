using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Model
{
    public class AuthResult
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
