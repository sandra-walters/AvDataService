using System;
using AvDataService.Extensions;
using AvDataService.Models;
using Newtonsoft.Json;
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

        public TimeSeriesData Intraday(string symbol, IntradayInterval interval, bool compactOutput = true) => 
            GetTimeSeries(symbol, "TIME_SERIES_INTRADAY", compactOutput, interval);

        public TimeSeriesData Daily(string symbol, bool compactOutput = true) => 
            GetTimeSeries(symbol, "TIME_SERIES_DAILY", compactOutput);

        public TimeSeriesData Weekly(string symbol, bool compactOutput = true) => 
            GetTimeSeries(symbol, "TIME_SERIES_WEEKLY", compactOutput);

        public TimeSeriesData Monthly(string symbol, bool compactOutput = true) => 
            GetTimeSeries(symbol, "TIME_SERIES_MONTHLY", compactOutput);

        private TimeSeriesData GetTimeSeries(string symbol, string function, bool compactOutput = true, 
            IntradayInterval? interval = null)
        {
            var request = new RestRequest(Constants.ApiRequestPath)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("function", function);
            request.AddParameter("symbol", symbol);
            if (interval != null)
                request.AddParameter("interval", $"{(int)interval}min");
            if (!compactOutput)
                request.AddParameter("outputsize", "full");

            request.AddParameter("apikey", ApiKey);

            var response = Client.GetAvResponse(request, Timeout);
            if (response?.JsonContent != null)
                return JsonConvert.DeserializeObject<TimeSeriesData>(response.JsonContent.ToString());

            throw new Exception(response == null ? "Response is empty"
                    : !string.IsNullOrEmpty(response.ErrorMessage) ? response.ErrorMessage
                    : $"Received {response.StatusCode}");
        }

    }
}
