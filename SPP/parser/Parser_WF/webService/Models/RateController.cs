using ParserLib.Core;
using ParserLib.siteBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;

namespace webService.Models
{
    public class RateController : ApiController
    {
        [Route("noSerialible")]
        public async Task<ExchangeRates[]> Get()
        {
            ParserWorkerAPI<ExchangeRates[]> parser;
            parser = new ParserWorkerAPI<ExchangeRates[]>(new BankParser());
            parser.Setting = new BankSetting();
            return await parser.GetRates();
        }
        [Route("Serialible")]
        public async Task<ExchangeRateSerialible[]> GetS()
        {
            ParserWorkerAPI<ExchangeRateSerialible[]> parser;
            parser = new ParserWorkerAPI<ExchangeRateSerialible[]>(new BankParserSerialible());
            parser.Setting = new BankSetting();
            return await parser.GetRates();
        }
    }
}
