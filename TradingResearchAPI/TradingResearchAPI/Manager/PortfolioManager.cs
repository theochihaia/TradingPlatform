using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingResearchAPI.Enums;
using TradingResearchAPI.Models;

namespace TradingResearchAPI.Manager
{
    public class PortfolioManager
    {

        public List<Trade> GetCurrentPortfolio(string user)
        {

            Trade t = new Trade() {
                Symbol = user,
                TradePrice = 100,
                TradeAction = TradeAction.Buy
            };

            List<Trade> trades = new List<Trade>();
            trades.Add(t);

            return trades;
        }

    }
}
