using AngleSharp.Parser.Html;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;

namespace ParserLib.Core
{
    public class ParserWorker<T> where T : class
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

        public event Action<object, T> OnNewData; //ссылка на парсер и сами данные
        public event Action<object> OnComplite;

 
        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }
        public ParserWorker(IParser<T> parser,IParserSetting parserSetting): this(parser)
        {
            this.parserSetting = parserSetting;
        }
        public void  Start()
        {
            isActive = true;
            Worker();
        }
        public void Abort()
        {
            isActive = false;
            OnComplite?.Invoke(this);
        }

        private async void Worker()
        {
            if(!isActive)
            {
                return;
            }

            var source = await loader.GetSourceByPage();
            var parserA = new HtmlParser();
            var document = await parserA.ParseAsync(source);

            var result= parser.Parse(document);

            OnNewData?.Invoke(this, result);
            OnComplite?.Invoke(this);
            isActive = false;
        }


    }
}
