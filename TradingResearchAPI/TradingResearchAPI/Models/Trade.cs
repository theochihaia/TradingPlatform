using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingResearchAPI.Enums;

namespace TradingResearchAPI.Models
{
    public class Trade
    {
        public string Symbol { get; set; }
        public TradeAction TradeAction { get; set; }
        public double TradePrice { get; set; }
        public int TradeAmount { get; set; }
        public int NumberOfShares { get; set; }
        public DateTime TradingDate { get; set; } = DateTime.UtcNow;
    }
}
