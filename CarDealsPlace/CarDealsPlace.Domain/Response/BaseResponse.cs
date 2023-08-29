using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarDealsPlace.Domain.Response
{
    public class BaseResponse<T>
    {
        public BaseResponse(T data, HttpStatusCode statusCode, string description) => (Data, StatusCode, Description) = (data, statusCode, description);

        public HttpStatusCode StatusCode { get; private set; }
        public T Data { get; private set; } 
        public string Description { get; private set; }
    }
}
