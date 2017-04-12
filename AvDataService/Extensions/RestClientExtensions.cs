using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AvDataService.Models;
using Newtonsoft.Json;
using RestSharp;

namespace AvDataService.Extensions
{
    public static class RestClientExtensions
    {
        public static AvResponse GetAvResponse(this RestClient client, RestRequest request, int timeout)
        {
            var avResponse = new AvResponse();

            RestResponse restResponse = null;
            Task.Run(async () =>
            {
                var source = new CancellationTokenSource();
                var task = GetResponseAsync(client, request);
                if (await Task.WhenAny(task, Task.Delay(timeout, source.Token)) == task)
                {
                    restResponse = (RestResponse)await task;
                }
                else
                {
                    avResponse.StatusCode = HttpStatusCode.RequestTimeout;
                }
            }).Wait();

            if (restResponse != null)
            {
                avResponse.StatusCode = restResponse.StatusCode;
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    avResponse.JsonContent = JsonConvert.DeserializeObject(restResponse.Content);
                }
                else
                {
                    avResponse.ErrorMessage = restResponse.ErrorMessage;
                }
            }

            return avResponse;
        }

        public static Task<IRestResponse> GetResponseAsync(RestClient client, RestRequest request)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync(request, response =>
            {
                tcs.TrySetResult(response);
            });

            return tcs.Task;
        }
    }
}
