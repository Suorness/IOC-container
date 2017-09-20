using ParserLib.Core;
using ParserLib.siteBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webService.Controllers
{
    public class ValuesController : ApiController
    {
        ParserWorker<ExchangeRates[]> parser = new ParserWorker<ExchangeRates[]>(new BankParser());






    }
}
