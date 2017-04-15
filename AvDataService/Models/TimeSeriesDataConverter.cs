using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace AvDataService.Models
{
    public class TimeSeriesDataConverter : CustomCreationConverter<TimeSeriesData>
    {
        public override TimeSeriesData Create(Type objectType)
        {
            return new TimeSeriesData();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var tsData = new TimeSeriesData();
            JObject jobj = JObject.Load(reader);
            foreach (JProperty prop in jobj.Properties())
            {
                if (prop.Name == "Meta Data")
                    tsData.MetaDataDictionary = prop.Value.ToObject<Dictionary<string, string>>();
                else if (prop.Name.Contains("Time Series"))
                {
                    var dic = prop.Value.ToObject<Dictionary<string, Dictionary<string, decimal>>>();
                    foreach (var item in dic)
                    {
                        TimeSeriesValue ts = new TimeSeriesValue
                        {
                            TimeStampRaw = item.Key,
                            TimeStamp = ConvertToDateTime(item.Key)
                        };

                        foreach (var subitem in item.Value)
                        {
                            if (subitem.Key.Contains("open"))
                                ts.Open = subitem.Value;
                            else if (subitem.Key.Contains("high"))
                                ts.High = subitem.Value;
                            else if (subitem.Key.Contains("low"))
                                ts.Low = subitem.Value;
                            else if (subitem.Key.Contains("close"))
                                ts.Close = subitem.Value;
                            else if (subitem.Key.Contains("volume"))
                                ts.Volume = (UInt64) subitem.Value;
                        }
                        tsData.TimeSeries.Add(ts);
                    }
                }
            }

            return tsData;
        }

        private DateTime? ConvertToDateTime(string input)
        {
            DateTime timeStamp;
            bool valid = DateTime.TryParseExact(input, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeStamp);
            if (!valid)
                valid = DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeStamp);

            return (valid) ? (DateTime?) timeStamp : null;
        }
    }
}
