using System.Net;

namespace AvDataService.Models
{
    public class AvResponse
    {
        public HttpStatusCode StatusCode;
        public object JsonContent;
        public string ErrorMessage;
    }
}
