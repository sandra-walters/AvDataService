using AvDataService.Extensions;
using AvDataService.Models;
using RestSharp;

namespace AvDataService.Services
{
    public class TechnicalIndicator : AvService
    {
        public TechnicalIndicator(string apiKey, int timeout = Constants.DefaultTimeout) : base (apiKey, timeout)
        {
        }

        public AvResponse SMA(string symbol, string interval, int timePeriod, string seriesType) => Get("SMA", symbol, interval, timePeriod, seriesType);
        public AvResponse EMA(string symbol, string interval, int timePeriod, string seriesType) => Get("EMA", symbol, interval, timePeriod, seriesType);
        public AvResponse WMA(string symbol, string interval, int timePeriod, string seriesType) => Get("WMA", symbol, interval, timePeriod, seriesType);
        public AvResponse DEMA(string symbol, string interval, int timePeriod, string seriesType) => Get("DEMA", symbol, interval, timePeriod, seriesType);
        public AvResponse TEMA(string symbol, string interval, int timePeriod, string seriesType) => Get("TEMA", symbol, interval, timePeriod, seriesType);
        public AvResponse TRIMA(string symbol, string interval, int timePeriod, string seriesType) => Get("TRIMA", symbol, interval, timePeriod, seriesType);
        public AvResponse KAMA(string symbol, string interval, int timePeriod, string seriesType) => Get("KAMA", symbol, interval, timePeriod, seriesType);
        public AvResponse T3(string symbol, string interval, int timePeriod, string seriesType) => Get("T3", symbol, interval, timePeriod, seriesType);
        public AvResponse RSI(string symbol, string interval, int timePeriod, string seriesType) => Get("RSI", symbol, interval, timePeriod, seriesType);
        public AvResponse WILLR(string symbol, string interval, int timePeriod) => Get("WILLR", symbol, interval, timePeriod);
        public AvResponse ADX(string symbol, string interval, int timePeriod) => Get("ADX", symbol, interval, timePeriod);
        public AvResponse ADXR(string symbol, string interval, int timePeriod) => Get("ADXR", symbol, interval, timePeriod);

        public AvResponse APO(string symbol, string interval, string seriesType, int fastPeriod=12, int slowPeriod=26, int maType=0) =>
            Get("APO", symbol, interval, seriesType, fastPeriod, slowPeriod, maType);
        public AvResponse PPO(string symbol, string interval, string seriesType, int fastPeriod=12, int slowPeriod=26, int maType=0) =>
            Get("PPO", symbol, interval, seriesType, fastPeriod, slowPeriod, maType);

        public AvResponse MOM(string symbol, string interval, int timePeriod, string seriesType) => Get("MOM", symbol, interval, timePeriod, seriesType);
        public AvResponse BOP(string symbol, string interval) => Get("BOP", symbol, interval);

        public AvResponse CCI(string symbol, string interval, int timePeriod) => Get("CCI", symbol, interval, timePeriod);
        public AvResponse CMO(string symbol, string interval, int timePeriod, string seriesType) => Get("CMO", symbol, interval, timePeriod, seriesType);
        public AvResponse ROC(string symbol, string interval, int timePeriod, string seriesType) => Get("ROC", symbol, interval, timePeriod, seriesType);
        public AvResponse ROCR(string symbol, string interval, int timePeriod, string seriesType) => Get("ROCR", symbol, interval, timePeriod, seriesType);
        public AvResponse AROON(string symbol, string interval, int timePeriod) => Get("AROON", symbol, interval, timePeriod);
        public AvResponse AROONOSC(string symbol, string interval, int timePeriod) => Get("AROONOSC", symbol, interval, timePeriod);
        public AvResponse MFI(string symbol, string interval, int timePeriod) => Get("MFI", symbol, interval, timePeriod);
        public AvResponse TRIX(string symbol, string interval, int timePeriod, string seriesType) => Get("TRIX", symbol, interval, timePeriod, seriesType);

        public AvResponse DX(string symbol, string interval, int timePeriod) => Get("DX", symbol, interval, timePeriod);
        public AvResponse MINUS_DI(string symbol, string interval, int timePeriod) => Get("MINUS_DI", symbol, interval, timePeriod);
        public AvResponse PLUS_DI(string symbol, string interval, int timePeriod) => Get("PLUS_DI", symbol, interval, timePeriod);
        public AvResponse MINUS_DM(string symbol, string interval, int timePeriod) => Get("MINUS_DM", symbol, interval, timePeriod);
        public AvResponse PLUS_DM(string symbol, string interval, int timePeriod) => Get("PLUS_DM", symbol, interval, timePeriod);

        public AvResponse MIDPOINT(string symbol, string interval, int timePeriod, string seriesType) => Get("MIDPOINT", symbol, interval, timePeriod, seriesType);
        public AvResponse MIDPRICE(string symbol, string interval, int timePeriod) => Get("MIDPRICE", symbol, interval, timePeriod);

        public AvResponse TRANGE(string symbol, string interval) => Get("TRANGE", symbol, interval);
        public AvResponse ATR(string symbol, string interval, int timePeriod) => Get("ATR", symbol, interval, timePeriod);
        public AvResponse NATR(string symbol, string interval, int timePeriod) => Get("NATR", symbol, interval, timePeriod);
        public AvResponse AD(string symbol, string interval, int timePeriod) => Get("AD", symbol, interval, timePeriod);

        public AvResponse OBV(string symbol, string interval) => Get("OBV", symbol, interval);
        public AvResponse HT_TRENDLINE(string symbol, string interval, string seriesType) => Get("HT_TRENDLINE", symbol, interval, seriesType);
        public AvResponse HT_SINE(string symbol, string interval, string seriesType) => Get("HT_SINE", symbol, interval, seriesType);
        public AvResponse HT_TRENDMODE(string symbol, string interval, string seriesType) => Get("HT_TRENDMODE", symbol, interval, seriesType);
        public AvResponse HT_DCPERIOD(string symbol, string interval, string seriesType) => Get("HT_DCPERIOD", symbol, interval, seriesType);
        public AvResponse HT_DCPHASE(string symbol, string interval, string seriesType) => Get("HT_DCPHASE", symbol, interval, seriesType);
        public AvResponse HT_PHASOR(string symbol, string interval, string seriesType) => Get("HT_PHASOR", symbol, interval, seriesType);


        public AvResponse MACDEXT(string symbol, string interval, int timePeriod, string seriesType,
            int fastPeriod=12, int slowPeriod=26, int signalPeriod=9, int fastMAType=0, int slowMAType=0, int signalMAType=0)
        {
            var request = new RestRequest(Constants.ApiRequestPath)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("function", "MACDEXT");
            request.AddParameter("symbol", symbol);
            request.AddParameter("interval", interval);
            request.AddParameter("time_period", timePeriod);
            request.AddParameter("series_type", seriesType);
            request.AddParameter("fastperiod", fastPeriod);
            request.AddParameter("slowperiod", slowPeriod);
            request.AddParameter("signalperiod", signalPeriod);
            request.AddParameter("fastmatype", fastMAType);
            request.AddParameter("slowmatype", slowMAType);
            request.AddParameter("signalmatype", signalMAType);
            request.AddParameter("apikey", ApiKey);

            return Client.GetAvResponse(request, Timeout);
        }

        public AvResponse STOCH(string symbol, string interval, int fastKPeriod=5, int slowKPeriod=3, int slowDPeriod=3,
            int slowKMAType=0, int slowDMAType=0)
        {
            var request = new RestRequest(Constants.ApiRequestPath)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("function", "STOCH");
            request.AddParameter("symbol", symbol);
            request.AddParameter("interval", interval);
            // Documentation says fastkperiod is also an optional param, but that appears to be incorrect
            request.AddParameter("slowkperiod", slowKPeriod);
            request.AddParameter("slowdperiod", slowDPeriod);
            request.AddParameter("slowkmatype", slowKMAType);
            request.AddParameter("slowdmatype", slowDMAType);
            request.AddParameter("apikey", ApiKey);

            return Client.GetAvResponse(request, Timeout);
        }
        public AvResponse STOCHF(string symbol, string interval, int fastKPeriod = 5, int fastDPeriod = 3, int fastDMAType = 0)
        {
            var request = new RestRequest(Constants.ApiRequestPath)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("function", "STOCHF");
            request.AddParameter("symbol", symbol);
            request.AddParameter("interval", interval);
            request.AddParameter("fastkperiod", fastKPeriod);
            request.AddParameter("fastdperiod", fastDPeriod);
            request.AddParameter("fastdmatype", fastDMAType);
            request.AddParameter("apikey", ApiKey);

            return Client.GetAvResponse(request, Timeout);
        }

        public AvResponse STOCHRSI(string symbol, string interval, int timePeriod, string seriesType, 
            int fastKPeriod = 5, int fastDPeriod = 3, int fastDMAType = 0)
        {
            var request = new RestRequest(Constants.ApiRequestPath)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("function", "STOCHRSI");
            request.AddParameter("symbol", symbol);
            request.AddParameter("interval", interval);
            request.AddParameter("time_period", timePeriod);
            request.AddParameter("series_type", seriesType);
            request.AddParameter("fastkperiod", fastKPeriod);
            request.AddParameter("fastdperiod", fastDPeriod);
            request.AddParameter("fastdmatype", fastDMAType);
            request.AddParameter("apikey", ApiKey);

            return Client.GetAvResponse(request, Timeout);
        }
        public AvResponse MAMA(string symbol, string interval, int timePeriod, string seriesType,
            float fastLimit=(float)0.01, float slowLimit=(float)0.01)
        {
            var request = new RestRequest(Constants.ApiRequestPath)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("function", "MAMA");
            request.AddParameter("symbol", symbol);
            request.AddParameter("interval", interval);
            request.AddParameter("time_period", timePeriod);
            request.AddParameter("series_type", seriesType);
            request.AddParameter("fastlimit", fastLimit);
            request.AddParameter("slowlimit", slowLimit);
            request.AddParameter("apikey", ApiKey);

            return Client.GetAvResponse(request, Timeout);
        }

        public AvResponse ULTOSC(string symbol, string interval, int timePeriod1=7, int timePeriod2=14, int timePeriod3=28)
        {
            var request = new RestRequest(Constants.ApiRequestPath)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("function", "ULTOSC");
            request.AddParameter("symbol", symbol);
            request.AddParameter("interval", interval);
            request.AddParameter("timeperiod1", timePeriod1);
            request.AddParameter("timeperiod2", timePeriod2);
            request.AddParameter("timeperiod3", timePeriod3);
            request.AddParameter("apikey", ApiKey);

            return Client.GetAvResponse(request, Timeout);
        }

        public AvResponse BBANDS(string symbol, string interval, int timePeriod, string seriesType,
            int nbDevUp = 2, int nbDevDn = 2, int maType = 0)
        {
            var request = new RestRequest(Constants.ApiRequestPath)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("function", "STOCHRSI");
            request.AddParameter("symbol", symbol);
            request.AddParameter("interval", interval);
            request.AddParameter("time_period", timePeriod);
            request.AddParameter("series_type", seriesType);
            request.AddParameter("nbdevup", nbDevUp);
            request.AddParameter("nbdevdn", nbDevDn);
            request.AddParameter("matype", maType);
            request.AddParameter("apikey", ApiKey);

            return Client.GetAvResponse(request, Timeout);
        }

        public AvResponse SAR(string symbol, string interval, float acceleration=(float)0.01, float maximum=(float)0.2)
        {
            var request = new RestRequest(Constants.ApiRequestPath)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("function", "SAR");
            request.AddParameter("symbol", symbol);
            request.AddParameter("interval", interval);
            request.AddParameter("acceleration", acceleration);
            request.AddParameter("maximum", maximum);
            request.AddParameter("apikey", ApiKey);

            return Client.GetAvResponse(request, Timeout);
        }
        public AvResponse ADOSC(string symbol, string interval, int fastPeriod=3, int slowPeriod=10)
        {
            var request = new RestRequest(Constants.ApiRequestPath)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("function", "ADOSC");
            request.AddParameter("symbol", symbol);
            request.AddParameter("interval", interval);
            request.AddParameter("fastperiod", fastPeriod);
            request.AddParameter("slowperiod", slowPeriod);
            request.AddParameter("apikey", ApiKey);

            return Client.GetAvResponse(request, Timeout);
        }
        public AvResponse MACD(string symbol, string interval, int timePeriod, string seriesType,
            int fastPeriod=12, int slowPeriod=26, int signalPeriod=9)
        {
            var request = new RestRequest(Constants.ApiRequestPath)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("function", "MACD");
            request.AddParameter("symbol", symbol);
            request.AddParameter("interval", interval);
            request.AddParameter("time_period", timePeriod);
            request.AddParameter("series_type", seriesType);
            request.AddParameter("fastperiod", fastPeriod);
            request.AddParameter("slowperiod", slowPeriod);
            request.AddParameter("signalperiod", signalPeriod);
            request.AddParameter("apikey", ApiKey);

            return Client.GetAvResponse(request, Timeout);
        }

        private AvResponse Get(string function, string symbol, string interval)
        {
            var request = new RestRequest(Constants.ApiRequestPath)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("function", function);
            request.AddParameter("symbol", symbol);
            request.AddParameter("interval", interval);
            request.AddParameter("apikey", ApiKey);

            return Client.GetAvResponse(request, Timeout);
        }

        private AvResponse Get(string function, string symbol, string interval, int timePeriod)
        {
            var request = new RestRequest(Constants.ApiRequestPath)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("function", function);
            request.AddParameter("symbol", symbol);
            request.AddParameter("interval", interval);
            request.AddParameter("time_period", timePeriod);
            request.AddParameter("apikey", ApiKey);

            return Client.GetAvResponse(request, Timeout);
        }

        private AvResponse Get(string function, string symbol, string interval, int timePeriod, string seriesType)
        {
            var request = new RestRequest(Constants.ApiRequestPath)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("function", function);
            request.AddParameter("symbol", symbol);
            request.AddParameter("interval", interval);
            request.AddParameter("time_period", timePeriod);
            request.AddParameter("series_type", seriesType);
            request.AddParameter("apikey", ApiKey);

            return Client.GetAvResponse(request, Timeout);
        }

        private AvResponse Get(string function, string symbol, string interval, string seriesType)
        {
            var request = new RestRequest(Constants.ApiRequestPath)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("function", function);
            request.AddParameter("symbol", symbol);
            request.AddParameter("interval", interval);
            request.AddParameter("series_type", seriesType);
            request.AddParameter("apikey", ApiKey);

            return Client.GetAvResponse(request, Timeout);
        }

        private AvResponse Get(string function, string symbol, string interval, string seriesType, int fastPeriod, int slowPeriod, int maType)
        {
            var request = new RestRequest(Constants.ApiRequestPath)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("function", function);
            request.AddParameter("symbol", symbol);
            request.AddParameter("interval", interval);
            request.AddParameter("series_type", seriesType);
            request.AddParameter("fastperiod", fastPeriod);
            request.AddParameter("slowperiod", slowPeriod);
            request.AddParameter("matype", maType);
            request.AddParameter("apikey", ApiKey);

            return Client.GetAvResponse(request, Timeout);
        }

    }
}
