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
        //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
        BWJF_SKOP_ATLLib.SKControlLogic sam = null;
        DataSet _DataSet = null;

        public FormInvoiceExport()
        {
            InitializeComponent();
            InitialToolsTrip();

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

            _DataSet = XmlConvertor.InitInvoiceDataTable();
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
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "Excel2007(*.xlsx)";
            string fileName = string.Empty;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                DataSet dataSet = NPOIHelper.ExcelToDataSet(fileName, 2);
                if (dataSet != null && dataSet.Tables.Count > 1)
                {
                    DataTable mstTable = _DataSet.Tables["Mst"];
                    if (mstTable.Rows.Count > 0) mstTable.Rows.Clear();
                    foreach (DataRow r in dataSet.Tables[0].Rows)
                    {
                        mstTable.ImportRow(r);
                    }

                    DataTable itemTable = _DataSet.Tables["Item"];
                    if (itemTable.Rows.Count > 0) itemTable.Rows.Clear();
                    foreach (DataRow r in dataSet.Tables[1].Rows)
                    {
                        itemTable.ImportRow(r);
                    }

                    dataGridView1.DataSource = mstTable;
                    dataGridView2.DataSource = itemTable;
                }
            }

        }
        private void btnToSDSale_Click(object sender, EventArgs e)
        {

        }
        private void btnToSDInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = SD3000.GetConnectionTable();
                string server = table.Rows[0]["server"].ToString();
                string dbName = table.Rows[0]["accset"].ToString();
                string dbUser = table.Rows[0]["dbUser"].ToString();
                string password = table.Rows[0]["password"].ToString();
                bool integratedSecurity = false;
                bool.TryParse(table.Rows[0]["integratedSecurity"].ToString(), out integratedSecurity);
                string connString = DBHelper.GetConnectionString(server, dbName, dbUser, password, integratedSecurity);

                FormCredence cred = new FormCredence();
                cred.InitialDataSource(connString);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            string strFPLXDM = "1";//row["FPLXDM"].ToString(); ;
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

        void InitialToolsTrip()
        {
            ToolStripButton tbtnToQuery = new ToolStripButton();
            tbtnToQuery.Text = "查询税控盘发票";
            tbtnToQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            //tbtnToSD3000Invoive.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            tbtnToQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            tbtnToQuery.Click += btnQuery_Click;
            toolStrip1.Items.Add(tbtnToQuery);

            ToolStripButton tbtnImport = new ToolStripButton();
            tbtnImport.Text = "导入Excel";
            tbtnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            //tbtnImport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            tbtnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            tbtnImport.Click += btnImport_Click;
            toolStrip1.Items.Add(tbtnImport);

            ToolStripButton tbtnExport = new ToolStripButton();
            tbtnExport.Text = "导出Excel";
            tbtnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            //tbtnToSD3000Invoive.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            tbtnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            tbtnExport.Click += btnExport_Click;
            toolStrip1.Items.Add(tbtnExport);

            ToolStripButton tbtnToSD3000Sale = new ToolStripButton();
            tbtnToSD3000Sale.Text = "转速达3000销售单";
            tbtnToSD3000Sale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            //tbtnToSD3000Sale.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            tbtnToSD3000Sale.ImageTransparentColor = System.Drawing.Color.Magenta;
            //tbtnToSD3000Sale.Size = new System.Drawing.Size(23, 22);
            tbtnToSD3000Sale.Click += btnToSDSale_Click;
            toolStrip1.Items.Add(tbtnToSD3000Sale);

            ToolStripButton tbtnToSD3000Invoive = new ToolStripButton();
            tbtnToSD3000Invoive.Text = "转速达3000凭证";
            tbtnToSD3000Invoive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            //tbtnToSD3000Invoive.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            tbtnToSD3000Invoive.ImageTransparentColor = System.Drawing.Color.Magenta;
            tbtnToSD3000Invoive.Click += btnToSDInvoice_Click;
            toolStrip1.Items.Add(tbtnToSD3000Invoive);
        }
    }
}
