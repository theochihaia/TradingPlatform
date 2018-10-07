using System;
using System.Collections.Generic;
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
        String[] symbols;

        public PortfolioManager()
        {
            _portfolioDao = new PortfolioDAO();
            symbols = new String[]{
                "vod"
                ,"fslr"
                ,"ge"
                ,"cqqq"
                ,"hyem"
            };

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

        public List<TradeRecommendation> GetDefaultDashboard()
        {
            StockManger sm = new StockManger();
            TradeRecommendationManager trm = new TradeRecommendationManager();
            List<TradeRecommendation> recommendations = new List<TradeRecommendation>();

            foreach(String sym in symbols)
            {
                // Get stock data
                IReadOnlyList<Candle> tradeData = sm.GetStockDetails(sym).Result;

                // Determin Trade Recommendation
                recommendations.Add(trm.GetTradeRecommendation(sym, tradeData));

            }

            recommendations.OrderBy(o => o.TradeAction);

            return recommendations;
        }
    }
}
