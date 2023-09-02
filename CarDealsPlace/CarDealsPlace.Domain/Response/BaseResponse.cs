using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarDealsPlace.Domain.Response
{
    public class BaseResponse<T> where T : class
    {
        public BaseResponse(HttpStatusCode statusCode, T data) => (Data, StatusCode, Description) = (data, statusCode, null);

        public BaseResponse(HttpStatusCode statusCode, string description) => (Data, StatusCode, Description) = (null, statusCode, description);

        public HttpStatusCode StatusCode { get; private set; }
        public T? Data { get; private set; } 
        public string? Description { get; private set; }
    }
}
