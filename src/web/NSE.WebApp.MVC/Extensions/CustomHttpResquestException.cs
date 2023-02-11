using System.Net;

namespace NSE.WebApp.MVC.Extensions
{
    public class CustomHttpResquestException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public CustomHttpResquestException() { }

        public CustomHttpResquestException(string message, Exception innerException) : base(message, innerException) { }

        public CustomHttpResquestException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
