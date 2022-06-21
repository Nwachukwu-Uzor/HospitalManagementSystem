namespace HospitalManagementApi.Response
{
    public class GenerateApiResponse<T>
    {
        public static ApiResponse<T> GenerateFailureResponse(string error)
        {
            return new ApiResponse<T>
            {
                Data = default,
                Message = error,
                Success = false
            };
        }

        public static ApiResponse<T> GenerateSuccessResponse(T data)
        {
            return new ApiResponse<T>
            {
                Data = data,
                Message = null,
                Success = true
            };
        }

        public static ApiResponse<T> GenerateEmptySuccessMessage(string message)
        {
            return new ApiResponse<T>
            {
                Data = default,
                Message = message,
                Success = true
            };
        }
    }
}
