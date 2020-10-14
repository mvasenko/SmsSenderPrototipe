using System.Net;

namespace Contracts.Responses
{
    public class ApiResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        public T Data { get; set; }
    }
}
