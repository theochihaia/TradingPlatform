﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradingResearchAPI.Manager;
using TradingResearchAPI.Models;

namespace TradingResearchAPI.Controllers
{
    [Route("api/portfolio")]
    public class PortfolioController : Controller
    {
        // GET api/values
        [HttpGet("{user}")]
        public List<Trade> GetPortfolio(string user)
        {
            PortfolioManager portfolioManager = new PortfolioManager();
            var portfolio = portfolioManager.GetCurrentPortfolio(user);

            return portfolio;
        }


        // POST api/trade
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }


        // POST api/values
        [HttpPost("tradeorder")]
        public void PlaceTradeOrder([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
