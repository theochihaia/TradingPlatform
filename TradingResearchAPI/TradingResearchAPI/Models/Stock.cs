using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingResearchAPI.Models
{
    public class Stock
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public DateTime DateInserted { get; set; }
        public bool IsActive { get; set; }
    }
}
