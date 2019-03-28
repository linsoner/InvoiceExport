using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BWJF_SKOP_ATLLib;
using System.IO;
using cl.thirdpart.npoi;
namespace BaiwangExport
{
    public partial class Form1 : Form
    {
        BWJF_SKOP_ATLLib.SKControlLogic sam = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (((Button)(sender)).Name)
            {
                case "button1":
                    sam.SetOutputMode(1);
                    long n1 = sam.SetRegisterInfo("8b18bc28f2e038938935a28665428fed8ac6fb2df686370074c56be664062205331f776d78f03c697cde4dccfd6629f8ec1ae3e565d888345d81696b0132a8dce9fc0fb2e458a43b0e5f5a9cfd77f5c27a77de13926091d6c385e5bc00f6ba0b099e8391021c79dff85a4de6df231b458061376a8cf3f7fa76ca0199a6a40cc6e00182712d2d7279636b732ed6f14fe090b309fdc2fc0df057620519d57d743d7f6e7ee7cf53e414ee7d9fc8a17d9e0c85c0474b075cbed0c1efebc2acae9d6ebd361cbe3e2c237a2703dc4bf1d13e5b9ec7fccb47683c065058a36dccd98b29c2f2585ac52d2765ed359c0ac94b86d6701cc2cb0114b213dcc98c22c96fadd3");
                    MessageBox.Show(n1.ToString(), "系统提示3");
                    break;
                case "button2":
                    String str1 = sam.GetSKDiskStatus("88888888");
                    MessageBox.Show(str1, "系统提示3");

                    break;
                case "button3":
                    String str2 = sam.GetFPLGInfo("500102010001497", "499000116076", "88888888", "12345678", "025");
                    MessageBox.Show(str2, "系统提示3");

                    break;
            　default:
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int n1 = sam.SetSKDiskPassword( "499000116076", "88888888", "88888888");
            MessageBox.Show(n1.ToString(), "系统提示3");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            String str2 = sam.GetSKSZSMInfo("500102010001497", "499000116076", "88888888", "12345678", "025");
            MessageBox.Show(str2, "系统提示3");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            String str2 = sam.GetSKApprovedInfo("500102010001497", "499000116076", "88888888", "12345678", "025");
            MessageBox.Show(str2, "系统提示3");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            long n1 = sam.UpdateSPBMData(0, "outputXML\\商品编码.xml");
            MessageBox.Show(n1.ToString(), "系统提示3");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            String str2 = sam.GetInvoiceInfo("500102010001497", "499000116076", "88888888", "12345678", "025",1,"2016110120161130",0);
            MessageBox.Show(str2, "系统提示3");

        }

        private void button9_Click(object sender, EventArgs e)
        {
            String str2 = sam.BuyFPRemote("500102010001497", "499000116076", "88888888", "12345678", "221.226.83.20", 7001
                ,"025", "150001201509", "54787801", "54787900",100);
            MessageBox.Show(str2, "系统提示3");

        }

        private void button10_Click(object sender, EventArgs e)
        {
            String str2 = sam.GetBuyFPRemoteInfo("500102010001497", "499000116076", "88888888", "12345678", "221.226.83.20", 7001 );
            MessageBox.Show(str2, "系统提示3");

        }

        private void button11_Click(object sender, EventArgs e)
        {
            String str2 = sam.SetBuyFPRTNRemoteInfo("500102010001497", "499000116076", "88888888", "12345678", "221.226.83.20", 7001
                , "025", "150001201509", "54787801", "54787900");
            MessageBox.Show(str2, "系统提示3");

        }

        private void button12_Click(object sender, EventArgs e)
        {
            String str2 = sam.GetInvoiceSummaryInfo("500102010001497", "499000116076", "88888888", "12345678", "025");
            MessageBox.Show(str2, "系统提示3");

        }

        private void button13_Click(object sender, EventArgs e)
        {
            String filePath = "testXML\\IssueInvoice025.xml";
            String sqltxt = File.ReadAllText(filePath);
            String str2 = sam.IssueInvoice(sqltxt);
            MessageBox.Show(str2, "系统提示3");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            String str2 = sam.InvalidInvoice("500102010001497", "499000116076", "88888888", "12345678",
                "025", 1, "3330000444", "11000460", "566.04", "作废人");
            MessageBox.Show(str2, "系统提示3");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            String str2 = sam.GetNotUploadInvoiceInfo("500102010001497", "499000116076", "88888888", "12345678", "025");
            MessageBox.Show(str2, "系统提示3");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            String str2 = sam.UploadInvoice("500102010001497", "499000116076", "88888888", "12345678", "221.226.83.20", 7001
                , "025", 2,1);
            MessageBox.Show(str2, "系统提示3");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            String str2 = sam.UnlockSKDisk("500102010001497", "499000116076", "88888888", "12345678", "025", "221.226.83.20", 7001);
            MessageBox.Show(str2, "系统提示3");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            String str2 = sam.GetUploadInvoiceResult("500102010001497", "499000116076", "88888888", "12345678", "221.226.83.20", 7001,"025");
            MessageBox.Show(str2, "系统提示3");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            String str2 = sam.GetNotSignInvoiceInfo("500102010001497", "499000116076", "88888888", "12345678",  "025",1);
            MessageBox.Show(str2, "系统提示3");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            String str2 = sam.AgainSignedInvoice("500102010001497", "499000116076", "88888888", "12345678",
           "007",  "3330000444", "11000459");
            MessageBox.Show(str2, "系统提示3");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            String str2 = sam.InvoiceDataCBS("500102010001497", "499000116076", "88888888", "12345678", "221.226.83.20", 7001, "025");
            MessageBox.Show(str2, "系统提示3");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            String str2 = sam.SetPrintMargin( "025",10,10);
            MessageBox.Show(str2, "系统提示3");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            String str2 = sam.PrintInvoice("500102010001497", "499000116076", "88888888", "12345678",
            "025", "150001201509", "54787548", 0,1);
            MessageBox.Show(str2, "系统提示3");

        }

        private void button24_Click(object sender, EventArgs e)
        {
            String str2 = sam.DownloadInvoiceChangeInfo("500102010001497", "499000116076", "88888888", "12345678", "025", "221.226.83.20", 7001);
            MessageBox.Show(str2, "系统提示3");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            int n1 = sam.SetCertPassword("500102010001497", "499000116076", "88888888", "12345678", "12345678");
            MessageBox.Show(n1.ToString(), "系统提示3");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            String str2 = sam.GetBSDiskStatus("88888888");
            MessageBox.Show(str2, "系统提示3");
        }

        private void button27_Click(object sender, EventArgs e)
        {
            String str2 = sam.GetBSDiskInvoiceInfo("500102010001497",  "88888888",  "025");
            MessageBox.Show(str2, "系统提示3");
        }

        private void button28_Click(object sender, EventArgs e)
        {
            String str2 = sam.DistributeBSDiskInvoice("500102010001497", "499000116076", "88888888", "499000116076", "88888888","12345678","025", "150001201509", "54787545", 100);
            MessageBox.Show(str2, "系统提示3");
        }

        private void button29_Click(object sender, EventArgs e)
        {
            String str2 = sam.RepossessBSDiskInvoice("500102010001497", "499000116076", "88888888", "499000116076", "88888888", "12345678", "025", "150001201509", "54787545");
            MessageBox.Show(str2, "系统提示3");
        }

        private void button30_Click(object sender, EventArgs e)
        {
            String str2 = sam.CheckHZInvoice("500102010001497", "499000116076", "88888888",  "12345678", "221.226.83.20", 7001, "007", "3330000444", "11000455", "c");
            MessageBox.Show(str2, "系统提示3");
        }

        private void button31_Click(object sender, EventArgs e)
        {
            String str2 = sam.UploadHZNotice("红字通知单明细XML数据，请参考2.31节");
            MessageBox.Show(str2, "系统提示3");
        }

        private void button32_Click(object sender, EventArgs e)
        {
            String str2 = sam.DownloadHZNotice("500102010001497", "499000116076", "88888888", "12345678", "221.226.83.20", 7001, "007", "999999999999", "20160801", "20160831");
            MessageBox.Show(str2, "系统提示3");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button33_Click(object sender, EventArgs e)
        {
            long n1 = sam.SetOutputMode(1);
            MessageBox.Show(n1.ToString(), "系统提示3");

        }

        private void button34_Click(object sender, EventArgs e)
        {
            NPOIHelper.ExcelToTableForXLSX(@"C:\Users\soonfor\Desktop\AAA.XLS");
        }
    }
}
