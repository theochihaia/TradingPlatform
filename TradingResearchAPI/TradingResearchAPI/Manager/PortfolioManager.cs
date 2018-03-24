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

        public PortfolioManager()
        {
            _portfolioDao = new PortfolioDAO();

        }

        public List<Portfolio> GetPortfolios(Portfolio.GetRequest request)
        {
            List<Portfolio> portfolios = _portfolioDao.GetPortfolio(request.PortfolioGuids);
            return portfolios;
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
    }
}
