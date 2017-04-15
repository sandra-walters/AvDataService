using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AvDataService.Models
{
    [JsonConverter(typeof(TimeSeriesDataConverter))]
    public class TimeSeriesData
    {
        public Dictionary<string, string> MetaDataDictionary { get; set; }
        public List<TimeSeriesValue> TimeSeries;

        public TimeSeriesData()
        {
            MetaDataDictionary = new Dictionary<string, string>();
            TimeSeries = new List<TimeSeriesValue>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Metadata:");
            foreach (KeyValuePair<string, string> pair in MetaDataDictionary)
                sb.AppendLine($"{pair.Key}: {pair.Value}");

            sb.AppendLine("Time Series:");
            foreach (var tsValue in TimeSeries)
                sb.AppendLine($"{tsValue.TimeStamp} O: {tsValue.Open} C: {tsValue.Close} H: {tsValue.High} L: {tsValue.Low} V: {tsValue.Volume}");

            return sb.ToString();
        }
    }
}
