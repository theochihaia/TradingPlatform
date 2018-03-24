using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TradingResearchAPI.Enums
{
    public enum TradeAlgorithm
    {
        [Description("Bollinger Band")]
        BollingerBand,

        [Description("Bollinger Band")]
        Williams_R,
        Stocastic_RSI
    }
}
