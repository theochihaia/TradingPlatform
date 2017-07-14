using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingResearchAPI.Models
{
    public class TradingSession
    {
        public string Symbol { get; set; }
        public DateTime TradingDate { get; set; }
        public decimal OpenPrice { get; set; }
        public decimal ClosePrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public int Volume { get; set; }
    }
}
