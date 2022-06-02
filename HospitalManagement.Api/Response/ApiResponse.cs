using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Response
{
    public class ApiResponse<T> 
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
    }
}
