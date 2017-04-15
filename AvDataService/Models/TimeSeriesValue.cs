
using System;

namespace AvDataService.Models
{
    public class TimeSeriesValue
    {
        public string TimeStampRaw { get; set; }
        public DateTime? TimeStamp { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public UInt64 Volume { get; set; }
    }
}
