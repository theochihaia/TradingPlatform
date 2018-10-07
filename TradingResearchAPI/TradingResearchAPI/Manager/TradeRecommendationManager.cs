using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingResearchAPI.Models;
using System.ComponentModel;
using YahooFinanceApi;
using TradingResearchAPI.Common;

namespace TradingResearchAPI.Manager
{
    public class TradeRecommendationManager
    {
        BollingerBandSetting bollingerSetting; 

        public TradeRecommendationManager()
        {
            bollingerSetting = new BollingerBandSetting() {
                Period = 20,
                UpperStdDevLimit = 2,
                LowerStdDevLimit = 1.5m
            };

        }

        public TradeRecommendation GetTradeRecommendation(String sym, IReadOnlyList<YahooFinanceApi.Candle> candles)
        {
            var output = CalculateBollingerBand(candles, bollingerSetting);
            output.Symbol = sym;
            return output;
        }

        // TODO: Fix type inconsistencies with double
        private TradeRecommendation CalculateBollingerBand(IReadOnlyList<YahooFinanceApi.Candle> candles, BollingerBandSetting setting)
        {
            TradeRecommendation recommendation = new TradeRecommendation();

            var list = candles.OrderByDescending(c => c.DateTime).Take(setting.Period);

            // determine bands
            decimal stdDev = (decimal) CalculateStandardDeviation(list.Select(c => c.Close));

            // Populate Output
            recommendation.MostRecentTradingSession = list.First();
            recommendation.PurchaseRecommendation = (list.First().Low - stdDev * setting.LowerStdDevLimit);
            recommendation.SellRecommendation = (list.First().High + stdDev * setting.UpperStdDevLimit);

            if (list.First().Close < (decimal) recommendation.PurchaseRecommendation)
            {
                recommendation.TradeAction = Enums.TradeAction.Buy;
                recommendation.TradeActionDescription = recommendation.TradeAction.GetDescription();
            }
            else if(list.First().Close > (decimal)recommendation.SellRecommendation)
            {
                recommendation.TradeAction = Enums.TradeAction.Sell;
                recommendation.TradeActionDescription = recommendation.TradeAction.GetDescription();
            }
            else
            {
                recommendation.TradeAction = Enums.TradeAction.Hold;
                recommendation.TradeActionDescription = recommendation.TradeAction.GetDescription();
            }

            recommendation.percentReturnPotential = (recommendation.SellRecommendation - recommendation.PurchaseRecommendation)/recommendation.PurchaseRecommendation * 100;

            return recommendation;
        }



        #region Helper Methods
        private static decimal CalculateAverage(IEnumerable<decimal> numbers)
        {
            return numbers.Sum(c => c) / (decimal) numbers.Count();
        }

        private static double CalculateRootMeanSquared(IEnumerable<decimal> numbers)
        {
            var avg = CalculateAverage(numbers);

            var rootMeanSquared = numbers.Sum(n =>
                Math.Pow( (double) (n - avg), 2)
                / (double) numbers.Count()
             );

            return rootMeanSquared;
        }

        private static double CalculateStandardDeviation(IEnumerable<decimal> numbers)
        {
            double rootMeanSquared = CalculateRootMeanSquared(numbers);
            return Math.Sqrt(rootMeanSquared);
        }

        #endregion

    }
}
