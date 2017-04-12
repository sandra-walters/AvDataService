using System;
using RestSharp;

namespace AvDataService.Services
{
    public abstract class AvService
    {
        protected readonly string ApiKey;
        protected readonly RestClient Client;
        protected readonly int Timeout;


        protected AvService(string apiKey, int timeout = Constants.DefaultTimeout)
        {
            if (String.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException(nameof(apiKey));
            if (timeout < Constants.MinimumTimeout)
                throw new ArgumentOutOfRangeException(nameof(timeout), $"Value is too small, must be at least {Constants.MinimumTimeout}");
            ApiKey = apiKey;
            Timeout = timeout;

            Client = new RestClient(Constants.ClientUrl);
        }
    }
}
