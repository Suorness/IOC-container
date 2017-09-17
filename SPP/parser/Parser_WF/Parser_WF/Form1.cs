using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParserLib.Core;
using ParserLib.siteBank;
using System.Web;

namespace Parser_WF
{
    public partial class Form1 : Form
    {
        ParserWorker<string[]> parser;
        
        public Form1()
        {
            InitializeComponent();
            parser = new ParserWorker<string[]>(new BankParser());
            parser.OnComplite += Parser_OnComplite;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            ListData.Items.AddRange(arg2);
        }

        private void Parser_OnComplite(object obj)
        {
            MessageBox.Show("Done");
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            parser.Setting = new BankSetting();
            parser.Start();
        }

        private void ButtonAbort_Click(object sender, EventArgs e)
        {
            parser.Abort();
        }
    }
}
