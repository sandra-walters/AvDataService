using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using AvDataService.Models;
using AvDataService.Services;

namespace AvConsole
{
    // Used to demonstrate the service usage by exercising all REST endpoints
    class Program
    {
        private static string _apiKey;
        private static string _symbol;
        private static string _interval;
        private static string _seriesType;
        private static int _timePeriod = 60;

        static void Main()
        {
            GetSettings();

            DemoTimeSeries();
            DemoTechnicalIndicators();
            DemoSectorPerformance();
        }

        private static void GetSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            _apiKey = config["ApiKey"];
            _symbol = config["Symbol"];
            _interval = config["Interval"];
            _seriesType = config["SeriesType"];
            Int32.TryParse(config["TimePeriod"], out _timePeriod);
        }

        static void DemoTimeSeries()
        {
            TimeSeries tss = new TimeSeries(_apiKey);

            try
            {
                var response = tss.Intraday(_symbol, IntradayInterval.Interval_15Min);
                ReportResponse("TimeSeries.Intraday", response);

                response = tss.Daily(_symbol);
                ReportResponse("TimeSeries.Daily", response);

                response = tss.Weekly(_symbol);
                ReportResponse("TimeSeries.Weekly", response);

                response = tss.Monthly(_symbol);
                ReportResponse("TimeSeries.Monthly", response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void DemoTechnicalIndicators()
        { 
            TechnicalIndicator ti = new TechnicalIndicator(_apiKey);

            AvResponse response = ti.SMA(_symbol, _interval, _timePeriod, _seriesType);
            ReportResponse("TechnicalIndicators.SMA", response);

            response = ti.EMA(_symbol, _interval, _timePeriod, _seriesType);
            ReportResponse("TechnicalIndicators.EMA", response);

            response = ti.WMA(_symbol, _interval, _timePeriod, _seriesType);
            ReportResponse("TechnicalIndicators.WMA", response);

            response = ti.DEMA(_symbol, _interval, _timePeriod, _seriesType);
            ReportResponse("TechnicalIndicators.DEMA", response);

            response = ti.TEMA(_symbol, _interval, _timePeriod, _seriesType);
            ReportResponse("TechnicalIndicators.TEMA", response);

            response = ti.TRIMA(_symbol, _interval, _timePeriod, _seriesType);
            ReportResponse("TechnicalIndicators.TRIMA", response);

            response = ti.KAMA(_symbol, _interval, _timePeriod, _seriesType);
            ReportResponse("TechnicalIndicators.KAMA", response);

            response = ti.MAMA(_symbol, _interval, _timePeriod, _seriesType);
            ReportResponse("TechnicalIndicators.MAMA", response);

            response = ti.T3(_symbol, _interval, _timePeriod, _seriesType);
            ReportResponse("TechnicalIndicators.T3", response);

            response = ti.MACD(_symbol, _interval, _timePeriod, _seriesType);
            ReportResponse("TechnicalIndicators.MACD", response);

            response = ti.MACDEXT(_symbol, _interval, _timePeriod, _seriesType);
            ReportResponse("TechnicalIndicators.MACDEXT", response);

            response = ti.STOCH(_symbol, _interval);
            ReportResponse("TechnicalIndicators.STOCH", response);

            response = ti.STOCHF(_symbol, _interval);
            ReportResponse("TechnicalIndicators.STOCHF", response);

            response = ti.RSI(_symbol, _interval, _timePeriod, _seriesType);
            ReportResponse("TechnicalIndicators.RSI", response);

            response = ti.STOCHRSI(_symbol, _interval, _timePeriod, _seriesType);
            ReportResponse("TechnicalIndicators.STOCHRSI", response);

            response = ti.WILLR(_symbol, _interval, _timePeriod);
            ReportResponse("TechnicalIndicators.WILLR", response);

            response = ti.ADX(_symbol, _interval, _timePeriod);
            ReportResponse("TechnicalIndicators.ADX", response);

            response = ti.ADXR(_symbol, _interval, _timePeriod);
            ReportResponse("TechnicalIndicators.ADXR", response);

            response = ti.APO(_symbol, _interval, _seriesType);
            ReportResponse("TechnicalIndicators.APO", response);

            response = ti.PPO(_symbol, _interval, _seriesType);
            ReportResponse("TechnicalIndicators.PPO", response);

            response = ti.MOM(_symbol, _interval, _timePeriod, _seriesType);
            ReportResponse("TechnicalIndicators.MOM", response);

            response = ti.BOP(_symbol, _interval);
            ReportResponse("TechnicalIndicators.ADXR", response);

            response = ti.CCI(_symbol, _interval, _timePeriod);
            ReportResponse("TechnicalIndicators.CCI", response);

            response = ti.CMO(_symbol, _interval, _timePeriod, _seriesType);
            ReportResponse("TechnicalIndicators.CMO", response);

            response = ti.ROC(_symbol, _interval, _timePeriod, _seriesType);
            ReportResponse("TechnicalIndicators.ROC", response);

            response = ti.ROCR(_symbol, _interval, _timePeriod, _seriesType);
            ReportResponse("TechnicalIndicators.ROCR", response);

            response = ti.AROON(_symbol, _interval, _timePeriod);
            ReportResponse("TechnicalIndicators.AROON", response);

            response = ti.AROONOSC(_symbol, _interval, _timePeriod);
            ReportResponse("TechnicalIndicators.AROONOSC", response);

            response = ti.MFI(_symbol, _interval, _timePeriod);
            ReportResponse("TechnicalIndicators.MFI", response);

            response = ti.TRIX(_symbol, _interval, _timePeriod, _seriesType);
            ReportResponse("TechnicalIndicators.TRIX", response);

            response = ti.ULTOSC(_symbol, _interval);
            ReportResponse("TechnicalIndicators.ULTOSC", response);

            response = ti.DX(_symbol, _interval, _timePeriod);
            ReportResponse("TechnicalIndicators.DX", response);

            response = ti.MINUS_DI(_symbol, _interval, _timePeriod);
            ReportResponse("TechnicalIndicators.MINUS_DI", response);

            response = ti.PLUS_DI(_symbol, _interval, _timePeriod);
            ReportResponse("TechnicalIndicators.PLUS_DI", response);

            response = ti.MINUS_DM(_symbol, _interval, _timePeriod);
            ReportResponse("TechnicalIndicators.MINUS_DM", response);

            response = ti.PLUS_DM(_symbol, _interval, _timePeriod);
            ReportResponse("TechnicalIndicators.PLUS_DM", response);

            response = ti.BBANDS(_symbol, _interval, _timePeriod, _seriesType);
            ReportResponse("TechnicalIndicators.BBANDS", response);

            response = ti.MIDPOINT(_symbol, _interval, _timePeriod, _seriesType);
            ReportResponse("TechnicalIndicators.MIDPOINT", response);

            response = ti.MIDPRICE(_symbol, _interval, _timePeriod);
            ReportResponse("TechnicalIndicators.MIDPRICE", response);

            response = ti.SAR(_symbol, _interval);
            ReportResponse("TechnicalIndicators.SAR", response);

            response = ti.TRANGE(_symbol, _interval);
            ReportResponse("TechnicalIndicators.TRANGE", response);

            response = ti.ATR(_symbol, _interval, _timePeriod);
            ReportResponse("TechnicalIndicators.ATR", response);

            response = ti.NATR(_symbol, _interval, _timePeriod);
            ReportResponse("TechnicalIndicators.NATR", response);

            response = ti.AD(_symbol, _interval, _timePeriod);
            ReportResponse("TechnicalIndicators.AD", response);

            response = ti.ADOSC(_symbol, _interval);
            ReportResponse("TechnicalIndicators.ADOSC", response);

            response = ti.OBV(_symbol, _interval);
            ReportResponse("TechnicalIndicators.OBV", response);

            response = ti.HT_TRENDLINE(_symbol, _interval, _seriesType);
            ReportResponse("TechnicalIndicators.HT_TRENDLINE", response);

            response = ti.HT_SINE(_symbol, _interval, _seriesType);
            ReportResponse("TechnicalIndicators.HT_SINE", response);

            response = ti.HT_TRENDMODE(_symbol, _interval, _seriesType);
            ReportResponse("TechnicalIndicators.HT_TRENDMODE", response);

            response = ti.HT_DCPERIOD(_symbol, _interval, _seriesType);
            ReportResponse("TechnicalIndicators.HT_DCPERIOD", response);

            response = ti.HT_DCPHASE(_symbol, _interval, _seriesType);
            ReportResponse("TechnicalIndicators.HT_DCPHASE", response);

            response = ti.HT_PHASOR(_symbol, _interval, _seriesType);
            ReportResponse("TechnicalIndicators.HT_PHASOR", response);
        }

        private static void DemoSectorPerformance()
        {
            SectorPerformance sp = new SectorPerformance(_apiKey);

            AvResponse response = sp.Get();
            ReportResponse("SectorPerformance.Get", response);
        }

        private static void ReportResponse(string callName, TimeSeriesData response)
        {
            Console.WriteLine($"Method: {callName}");
            Console.WriteLine(response);
            Console.WriteLine("Press a key to continue...");
            Console.ReadKey();
        }

        private static void ReportResponse(string callName, AvResponse response)
        {
            Console.WriteLine($"Method: {callName}");
            Console.WriteLine($"Response status:  {response.StatusCode}");
            Console.WriteLine(response.JsonContent);
            Console.WriteLine("Press a key to continue...");
            Console.ReadKey();
        }
    }
}