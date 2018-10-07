using System;
using System.Collections.Generic;
using TradingResearchAPI.Enums;
using YahooFinanceApi;

namespace TradingResearchAPI.Models
{
    public class TradeRecommendation
    {
        public string Symbol { get; set; }
        public TradeAction TradeAction { get; set; }
        public String TradeActionDescription { get; set; }
        public decimal PurchaseRecommendation { get; set; }
        public decimal SellRecommendation { get; set; }
        public decimal percentReturnPotential { get; set; }
        public Candle MostRecentTradingSession { get; set; }


        public class GetRequest{
            public Dictionary<TradeAlgorithm, TradeAlgorithmConfiguration> algorithms { get; set; }

        }


    }
}
