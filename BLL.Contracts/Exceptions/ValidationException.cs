using System;
using System.Net;

namespace BLL.Contracts.Exceptions
{
    public class ValidationException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public ValidationException(HttpStatusCode statusCode, string msg) : base($"BAD_REQUEST {msg}")
        {
            StatusCode = statusCode;
        }
    }
}
