using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradingResearchAPI.Manager;
using TradingResearchAPI.Models;

namespace TradingResearchAPI.Controllers
{
    [Route("api/stocks")]
    public class StockController : Controller
    {
        // GET api/values
        [HttpGet("details/{symbol}")]
        public Task<IReadOnlyList<YahooFinanceApi.Candle>> GetStockDetails(string symbol)
        {
            StockManger portfolioManager = new StockManger();
            var candleList = portfolioManager.GetStockDetails(symbol);

            return candleList;
        }



    }
}
