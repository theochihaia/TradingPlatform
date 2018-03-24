using System;
using System.Collections.Generic;
using TradingResearchAPI.Enums;

namespace TradingResearchAPI.Models
{
    public class TradeRecommendation
    {
        public string Symbol { get; set; }
        public TradeAction TradeAction { get; set; }
        public double PurchaseRecommendation { get; set; }
        public double SellRecommendation { get; set; }
        public double percentReturnPotential { get; set; }
        public TradingSession MostRecentTradingSession { get; set; }


        public class GetRequest{
            public Dictionary<TradeAlgorithm, TradeAlgorithmConfiguration> algorithms { get; set; }

        }


    }
}
