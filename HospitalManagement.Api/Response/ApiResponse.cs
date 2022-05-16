using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Response
{
    public class ApiResponse<T> : BaseResponse
    {
        public T Data { get; set; }
    }
}
