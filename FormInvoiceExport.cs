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
    public partial class FormInvoiceExport : BaseForm
    {
        BWJF_SKOP_ATLLib.SKControlLogic sam = null;
        DataSet _DataSet = null;

        public FormInvoiceExport()
        {
            InitializeComponent();

            try
            {
                sam = new BWJF_SKOP_ATLLib.SKControlLogic();
            }
            catch(Exception ex)
            {
                MessageBox.Show("加载税控盘接口失败：\r\n" + ex.Message );
            }

            comboBox1.DataSource = Company.GetData();
            comboBox1.DisplayMember = "company";
            comboBox1.ValueMember = "NSRSBH";

            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string fpdm = dataGridView1.CurrentRow.Cells["fpdm"].Value.ToString();
            DataTable itemTable = dataGridView2.DataSource as DataTable;
            if (itemTable != null)
            {
                itemTable.DefaultView.RowFilter = "fpdm='" + fpdm + "'";
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string fileName = String.Empty;
            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.Filter = "Excel2007文件(*.xlsx)|*.xlsx";
            if (DialogResult.OK != saveFileDialog1.ShowDialog())
                return;
            else
                fileName = saveFileDialog1.FileName;
            try
            {
                NPOIHelper.DataSetToExcel2007(_DataSet, fileName);
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
            if (dateEnd.Value == null || dateEnd.Value.ToString() == "")
            {
                MessageBox.Show("请选择开结束日期");
                dateEnd.Focus();
                return;
            }

            DataRowView row = comboBox1.SelectedItem as DataRowView;
            if (row == null) return;
            string strNSRSBH = row["NSRSBH"].ToString();
            string strSKPBH = row["SKPBH"].ToString(); ;
            string strSKPPwd = row["SKPPwd"].ToString(); ;
            string strCertPwd = row["CertPwd"].ToString(); ;
            string strFPLXDM = row["FPLXDM"].ToString(); ;
            int nQueryType = 1;
            string strQueryCondition = dateStart.Value.ToString("yyyyMMdd") + dateEnd.Value.ToString("yyyyMMdd");
            int nInvoiceUploadType = 0;

            string invoiceXml = string.Empty;
            try
            {
                string s = Invoice.GetInvoices(strNSRSBH, strSKPBH, strSKPPwd, strCertPwd
                , strFPLXDM, nQueryType, strQueryCondition, nInvoiceUploadType, sam);
                //String str2 = sam.GetInvoiceInfo("500102010001497", "499000116076", "88888888", "12345678", "025", 1, "2016110120161130", 0);
                //MessageBox.Show(str2, "系统提示3");
            }
            catch(Exception ex)
            {
                MessageBox.Show("获取发票异常：\r\n" + ex.Message);
                return;
            }


            _DataSet = XmlConvertor.XmlToDataSet(invoiceXml);
            //_DataSet = XmlConvertor.XmlToDataSet(textBox1.Text);
            dataGridView1.DataSource = _DataSet.Tables["Mst"];
            dataGridView2.DataSource = _DataSet.Tables["Item"];
        }

        void InitialTools()
        {
            ToolStripButton tbtnImport = new ToolStripButton();
            tbtnImport.Text = "导入";
            tbtnImport.Click += (dender,e)=> {
                //todo :导入
            };
        }

        private void TbtnImport_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
