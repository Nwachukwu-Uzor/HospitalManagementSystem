using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Response
{
    public class GenerateApiResponse<T>
    {
        public static ApiResponse<T> GenerateFailureResponse(string error)
        {
            return new ApiResponse<T>
            {
                Data = default,
                Error = error,
                Success = false
            };
        }

        public static ApiResponse<T> GenerateSuccessResponse(T data)
        {
            return new ApiResponse<T>
            {
                Data = data,
                Error = null,
                Success = true
            };
        }
    }
}
