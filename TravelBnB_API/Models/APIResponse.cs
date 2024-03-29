﻿using System.Net;

namespace TravelBnB_API.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
        public APIResponse()
        {
            ErrorMessages = new List<string>();
        }
    }
}
