using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TradingResearchAPI.Database.DataAccess;
using TradingResearchAPI.Enums;
using TradingResearchAPI.Models;
using YahooFinanceApi;

namespace TradingResearchAPI.Manager
{
    public class PortfolioManager
    {
        PortfolioDAO _portfolioDao;
        StockManger _stockManager = new StockManger();
        TradeRecommendationManager _tradeRecommendationManager = new TradeRecommendationManager();
        String[] symbols;

        public PortfolioManager()
        {
            _portfolioDao = new PortfolioDAO();

            TextReader tr = new StreamReader(@"Requirements/StockSymbols.txt");
            string stockSymbolsToParse = tr.ReadLine();
            symbols = stockSymbolsToParse.Split(',');

        }

        public List<Portfolio> GetPortfolios(Portfolio.GetRequest request)
        {
            List<Portfolio> portfolios = _portfolioDao.GetPortfolio(request.PortfolioGuids);
            return portfolios;
        }

        public Guid CreatePortfolio(Portfolio.CreateRequest request)
        {
            Guid portfolioGuid = _portfolioDao.CreatePortfolio(request);

            return Guid.Empty;
        }


        public void UpdatePortfolio(Guid portfolioGuid, Portfolio.UpdateRequest request)
        {
            _portfolioDao.UpdatePortfolio(portfolioGuid, request);
        }

        public List<TradeRecommendation> GetTradeRecommendation(Guid portfolioGuid, TradeRecommendation.GetRequest request)
        {
            // should call trade recommendation manager
            throw new NotImplementedException();
        }

        public async Task<List<TradeRecommendation>> GetDefaultDashboard()
        {
            List<TradeRecommendation> recommendations = new List<TradeRecommendation>();

            List<Task<TradeRecommendation>> tasks = new List<Task<TradeRecommendation>>();

            foreach (String sym in symbols)
            {
                // Get stock data
                tasks.Add(ProcessTradeRecommendation(sym));
            }

            var results = await Task.WhenAll(tasks);

            // TODO: Handle null Trade Recommendations
            results.OrderBy(o => o?.TradeAction);

            return results.ToList();
        }

        private Task<TradeRecommendation> ProcessTradeRecommendation(String sym)
        {
            try
            {
                return Task.Run(() =>
                {
                    var candles = _stockManager.GetStockDetails(sym);

                    return _tradeRecommendationManager.GetTradeRecommendation(sym, candles.Result);
                });

            }
            catch(Exception e)
            {
                // TODO: Implement Logger
                Console.WriteLine($@"Exception Getting trade recommendation for: {sym}
                    Exception Message: {e.Message}");
            }

            return null;
        }
    }
}
