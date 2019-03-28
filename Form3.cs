using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cl.thirdpart.npoi;

namespace BaiwangExport
{
    public partial class Form3 : BaseForm
    {
        BWJF_SKOP_ATLLib.SKControlLogic sam = null;

        public Form3()
        {
            InitializeComponent();

            sam = new BWJF_SKOP_ATLLib.SKControlLogic();

            comboBox1.DataSource = Company.GetData();
            comboBox1.DisplayMember = "company";
            comboBox1.ValueMember = "NSRSBH";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string fileName = String.Empty;
            saveFileDialog1.DefaultExt = "xls";
            saveFileDialog1.Filter = "Excel2003文件(*.xls)|*.xls";
            if (DialogResult.OK != saveFileDialog1.ShowDialog())
                return;
            else
                fileName = saveFileDialog1.FileName;
            try
            {
                NPOIHelper.DataGridViewToExcel(fileName, dataGridView1, "宋体", 10);
                NPOIHelper.DataGridViewToExcel(fileName.Insert(fileName.LastIndexOf("."),"Item"), dataGridView2, "宋体", 10);
                MessageBox.Show("导出成功!");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message + "\r\nA00130");
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择公司");
                comboBox1.Focus();
                return;
            }
            if (dateStart.Value == null || dateStart.Value.ToString() == "")
            {
                MessageBox.Show("请选择开始日期");
                dateStart.Focus();
                return;
            }
            if (dateEnd.Value == null || dateEnd.Value.ToString() =="")
            {
                MessageBox.Show("请选择开结束日期");
                dateEnd.Focus();
                return;
            }

            DataRow row = comboBox1.SelectedItem as DataRow;
            string strNSRSBH = row["NSRSBH"].ToString();
            string strSKPBH = row["SKPBH"].ToString(); ;
            string strSKPPwd = row["SKPPwd"].ToString(); ;
            string strCertPwd = row["CertPwd"].ToString(); ;
            string strFPLXDM = row["FPLXDM"].ToString(); ;
            //string nQueryType = row["NSRSBH"].ToString(); ;
            string strQueryCondition = dateStart.Value.ToString("yyyyMMdd")+ dateEnd.Value.ToString("yyyyMMdd");
            //string nInvoiceUploadType = row["NSRSBH"].ToString(); ;

            string s = Invoice.GetInvoices(strNSRSBH, strSKPBH, strSKPPwd, strCertPwd
            , strFPLXDM, 1, strQueryCondition, 0, sam);

            //DataSet dataSet = XmlConvertor.XmlToDataSet(textBox1.Text);
            DataSet dataSet = XmlConvertor.XmlToDataSet(s);
            dataGridView1.DataSource = dataSet.Tables["Mst"];
            dataGridView2.DataSource = dataSet.Tables["Item"];
            //String str2 = sam.GetInvoiceInfo("500102010001497", "499000116076", "88888888", "12345678", "025", 1, "2016110120161130", 0);
            //MessageBox.Show(str2, "系统提示3");
        }


    }
}
