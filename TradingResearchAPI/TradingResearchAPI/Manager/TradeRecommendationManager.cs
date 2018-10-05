using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingResearchAPI.Models;
using YahooFinanceApi;

namespace TradingResearchAPI.Manager
{
    public class TradeRecommendationManager
    {
        public TradeRecommendation GetTradeRecommendation(String sym, IReadOnlyList<YahooFinanceApi.Candle> candles)
        {
            var output = CalculateBollingerBand(candles);
            output.Symbol = sym;
            return output;
        }

        // TODO: Fix type inconsistencies with double
        private TradeRecommendation CalculateBollingerBand(IReadOnlyList<YahooFinanceApi.Candle> candles)
        {
            TradeRecommendation recommendation = new TradeRecommendation();
            int period = 20;
            decimal stdFactor = (decimal) 1.5;

            var list = candles.OrderByDescending(c => c.DateTime).Take(period);

            // determin bands
            decimal average = list.Sum(c => c.Close) / (decimal) period;
            double rootMeanSquared = list.Sum( c =>
                Math.Pow((double) (c.Close - average), 2)) 
                / ((double) period);
            decimal stdDev = (decimal) Math.Sqrt(rootMeanSquared);

            // Populate Output
            recommendation.MostRecentTradingSession = list.First();
            recommendation.PurchaseRecommendation = (double) (list.First().Low - stdDev * stdFactor);
            recommendation.SellRecommendation = (double)(list.First().High + stdDev * stdFactor);

            if (list.First().Close < (decimal) recommendation.PurchaseRecommendation)
            {
                recommendation.TradeAction = Enums.TradeAction.Buy;
                recommendation.TradeActionDescription = "Buy";
            }
            else if(list.First().Close > (decimal)recommendation.SellRecommendation)
            {
                recommendation.TradeAction = Enums.TradeAction.Sell;
                recommendation.TradeActionDescription = "Sell";
            }
            else
            {
                recommendation.TradeAction = Enums.TradeAction.Hold;
                recommendation.TradeActionDescription = "Hold";
            }

            recommendation.percentReturnPotential = (recommendation.SellRecommendation - recommendation.PurchaseRecommendation)/recommendation.PurchaseRecommendation * 100;

            return recommendation;
        }

    }
}
