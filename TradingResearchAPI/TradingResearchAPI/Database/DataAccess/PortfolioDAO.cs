﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingResearchAPI.Models;

namespace TradingResearchAPI.Database.DataAccess
{
    public class PortfolioDAO
    {
        public List<Portfolio> GetPortfolio(List<Guid> portfolioGuids){
            // (?) how to handle null case
            throw new NotImplementedException();
        }

        public void UpdatePortfolio(Guid portfolioGuid, Portfolio.UpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
