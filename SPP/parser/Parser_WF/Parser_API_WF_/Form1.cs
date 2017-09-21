using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using ParserLib.siteBank;
using System.Net;
using System.Collections.Generic;

namespace Parser_API_WF_
{
    public partial class Form_Parser_api : Form
    {
        public Form_Parser_api()
        {
            InitializeComponent();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString("http://localhost:58591/Serialible");
                var items = JsonConvert.DeserializeObject<ExchangeRateSerialible[]>(json);
                foreach(var item in items)
                {
                    ListData.Items.Add(item.ToString());
                }

            }
            // _download_serialized_json_data<ExchangeRateSerialible>("http://localhost:58591/Serialible");
        }
        //private static T _download_serialized_json_data<T>(string url) where T : new()
        //{
        //    using (var w = new WebClient())
        //    {
        //        var json_data = string.Empty;
        //        // attempt to download JSON data as a string
        //        try
        //        {
        //            json_data = w.DownloadString(url);
        //        }
        //        catch (Exception) { }
        //        // if string with JSON data is not empty, deserialize it to class and return its instance 
        //        return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
        //    }
        //}
    }
}
