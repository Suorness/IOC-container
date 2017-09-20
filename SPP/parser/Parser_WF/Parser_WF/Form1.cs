using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParserLib;
using ParserLib.siteBank;
using System.Web;
using System.Threading;
using ParserLib.Core;

namespace Parser_WF
{
    public partial class Form1 : Form
    {
        ParserWorker<ExchangeRates[]> parser;
        public Form1()
        {
            InitializeComponent();
            //parser = new ParserWorker<string[]>(new BankParser());
            parser = new ParserWorker<ExchangeRates[]>( new BankParser());
            parser.OnComplite += Parser_OnComplite;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, ExchangeRates[] arg2)
        {
            ListData.Items.Clear();
            ListData.Items.AddRange(arg2);
            LabelLastUpdata.Text=string.Format("Last updata: {0}", DateTime.Now);

        }

        private void Parser_OnComplite(object obj)
        {
            //MessageBox.Show("Done");
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            parser.Setting = new BankSetting();
            TimerUpdata.Enabled = true;
            parser.Start();

        }

        private void ButtonAbort_Click(object sender, EventArgs e)
        {
            parser.Abort();
            TimerUpdata.Enabled = false;
        }

        private void TimerUpdata_Tick(object sender, EventArgs e)
        {
            parser.Start();
        }
    }
}
