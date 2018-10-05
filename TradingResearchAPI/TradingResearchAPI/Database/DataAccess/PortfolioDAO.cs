using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TradingResearchAPI.Models;

namespace TradingResearchAPI.Database.DataAccess
{
    public class PortfolioDAO: BaseDAO
    {
        #region Database Interation Methods
        public Guid CreatePortfolio(Portfolio.CreateRequest request)
        {
            request.PortfolioGuid = new Guid();
            ExecuteProcedure("ins_CreatePortfolio", Upsert(request));

            return request.PortfolioGuid;
        }
        public List<Portfolio> GetPortfolio(List<Guid> portfolioGuids)
        {
            throw new NotImplementedException();
        }

        public void UpdatePortfolio(Guid portfolioGuid, Portfolio.UpdateRequest request)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Upserts
        private SqlParameter[] Upsert(Portfolio.CreateRequest request)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@PortfolioGUID", request.PortfolioGuid),
                new SqlParameter("@PortfolioName", request.PortfolioName),
                new SqlParameter("@Symbols", JsonConvert.SerializeObject(request.Symbols)),
                new SqlParameter("@UserGUID", request.UserGuid)
            };
        }
        #endregion

    }
}
