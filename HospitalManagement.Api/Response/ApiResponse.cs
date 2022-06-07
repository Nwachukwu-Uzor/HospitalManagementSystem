﻿namespace HospitalManagement.Api.Response
{
    public class ApiResponse<T> 
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
    }
}
