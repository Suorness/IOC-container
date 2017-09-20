using System.Net;
using System.Net.Http;

using System.Threading.Tasks;

namespace ParserLib.Core
{
    public class HtmlLoader
    {
        HttpClient client;
        string url;

        public HtmlLoader(IParserSetting setting)
        {
            client = new HttpClient();
            url = $"{setting.BaseUrl}";
        }

        public async Task<string> GetSourceByPage()
        {
            var response = await client.GetAsync(url);
            string source = null;
            if (response!=null && response.StatusCode==HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }
            return source;
        }

    }
}
