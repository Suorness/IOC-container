using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserLib.Core
{
    public class ParserWorkerAPI <T> where T : class
    {
        IParser<T> parser;
        IParserSetting parserSetting;
        HtmlLoader loader;
        bool isActive;

        bool IsActive
        {
            get { return isActive; }
        }
        public IParser<T> Parser
        {
            get { return parser; }
            set { parser = value; }
        }
        public IParserSetting Setting
        {
            get { return parserSetting; }
            set
            {
                parserSetting = value;
                loader = new HtmlLoader(value);
            }
        }
        public ParserWorkerAPI(IParser<T> parser)
        {
            this.parser = parser;
        }
        public ParserWorkerAPI(IParser<T> parser, IParserSetting parserSetting): this(parser)
        {
            this.parserSetting = parserSetting;
        }
        public async Task<T> GetRates()
        { 
            var source = await loader.GetSourceByPage();
            var parserA = new HtmlParser();
            var document = await parserA.ParseAsync(source);

            var result = parser.Parse(document);
            return result;
        }
    }
}
