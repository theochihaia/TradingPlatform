using System;
using System.Collections.Generic;

namespace TradingResearchAPI.Models
{
    public class Portfolio
    {
        public Guid Guid { get; set; }
        public String PortfolioName { get; set; }
        public List<string> Symbols { get; set; }

        public class CreateRequest
        {
            public String PortfolioName { get; set; }
            public List<string> Symbols { get; set; }
        }

        public class GetRequest{
            public List<Guid> PortfolioGuids { get; set; }
        }

        public class UpdateRequest
        {
            public String PortfolioName { get; set; }
            public List<string> Symbols { get; set; }
        }

    }
}
