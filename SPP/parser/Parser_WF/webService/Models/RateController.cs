using ParserLib.Core;
using ParserLib.siteBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace webService.Models
{
    public class RateController : ApiController
    {
        public async Task<ExchangeRates[]> Get()
        {
            ParserWorkerAPI<ExchangeRates[]> parser;
            parser = new ParserWorkerAPI<ExchangeRates[]>(new BankParser());
            parser.Setting = new BankSetting();
            return await parser.GetRates();
        }
    }
}
