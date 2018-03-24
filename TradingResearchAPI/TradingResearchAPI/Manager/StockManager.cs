using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingResearchAPI.Enums;
using TradingResearchAPI.Models;
using YahooFinanceApi;

namespace TradingResearchAPI.Manager
{
    public class StockManger
    {

        public async Task<IReadOnlyList<YahooFinanceApi.Candle>> GetStockDetails(string symbol)
        {

            IReadOnlyList<YahooFinanceApi.Candle> candles = await YahooFinanceApi.Yahoo.GetHistoricalAsync(symbol, DateTime.UtcNow.Date.AddDays(-100), DateTime.UtcNow);

            return candles;
        }

    }
}
