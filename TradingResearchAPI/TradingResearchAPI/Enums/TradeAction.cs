using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TradingResearchAPI.Enums
{
    public enum TradeAction
    {
        [Description("Buy")]
        Buy = 0,

        [Description("Sell")]
        Sell = 1,

        [Description("Hold")]
        Hold = 2
    }
}
