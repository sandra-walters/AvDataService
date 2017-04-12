using AvDataService.Extensions;
using AvDataService.Models;
using RestSharp;

namespace AvDataService.Services
{

    public enum IntradayInterval
    {
        Interval_1Min = 1,
        Interval_5Min = 5,
        Interval_15Min = 15,
        Interval_30Min = 30,
        Interval_60Min = 60
    }

    public class TimeSeries : AvService
    {
        public TimeSeries(string apiKey, int timeout = Constants.DefaultTimeout) : base (apiKey, timeout)
        {
        }

        public AvResponse Intraday(string symbol, IntradayInterval interval, bool compactOutput = true)
        {
            var request = new RestRequest(Constants.ApiRequestPath)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("function", "TIME_SERIES_INTRADAY");
            request.AddParameter("symbol", symbol);
            request.AddParameter("interval", $"{(int)interval}min");
            if (!compactOutput)
                request.AddParameter("outputsize", "full");
            request.AddParameter("apikey", ApiKey);

            return Client.GetAvResponse(request, Timeout);
        }

        public AvResponse Daily(string symbol, bool compactOutput = true)
        {
            var request = new RestRequest(Constants.ApiRequestPath)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("function", "TIME_SERIES_DAILY");
            request.AddParameter("symbol", symbol);
            if (!compactOutput)
                request.AddParameter("outputsize", "full");
            request.AddParameter("apikey", ApiKey);

            return Client.GetAvResponse(request, Timeout);
        }

        public AvResponse Weekly(string symbol)
        {
            var request = new RestRequest(Constants.ApiRequestPath)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("function", "TIME_SERIES_WEEKLY");
            request.AddParameter("symbol", symbol);
            request.AddParameter("apikey", ApiKey);

            return Client.GetAvResponse(request, Timeout);
        }

        public AvResponse Monthly(string symbol)
        {
            var request = new RestRequest(Constants.ApiRequestPath)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("function", "TIME_SERIES_MONTHLY");
            request.AddParameter("symbol", symbol);
            request.AddParameter("apikey", ApiKey);

            return Client.GetAvResponse(request, Timeout);
        }
    }
}
