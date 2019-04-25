using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiwangExport
{
    
    public partial class FormCredence : BaseForm
    {
        DataTable _SubjectTable = null;
        string ConnString { get; set; }
        string MergeType { get; set; } //合并方式

        public int Credtype { get; set; }
        public int Sub_C { get; set; }
        public int Sub_Tax { get; set; }
        public DateTime CredDate { get; set; }
        public string BillMaker { get; set; }

        public FormCredence()
        {
            InitializeComponent();
            dataGridView1.DataError += DataGridView1_DataError;
            InitialToolsTrip();
            cboAccount.SelectedIndexChanged += CboAccount_SelectedIndexChanged;
            dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;
        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void InitialToolsTrip()
        {
            ToolStripButton tbtnGetSub = new ToolStripButton();
            tbtnGetSub.Text = "获取应收账款科目";
            tbtnGetSub.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            //tbtnToSD3000Invoive.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            tbtnGetSub.ImageTransparentColor = System.Drawing.Color.Magenta;
            tbtnGetSub.Click += btnGetSub_Click;
            toolStrip1.Items.Add(tbtnGetSub);

            ToolStripButton tbtnGenVoucher = new ToolStripButton();
            tbtnGenVoucher.Text = "生成凭证";
            tbtnGenVoucher.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            //tbtnToSD3000Invoive.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            tbtnGenVoucher.ImageTransparentColor = System.Drawing.Color.Magenta;
            tbtnGenVoucher.Click += btnOK_Click;
            toolStrip1.Items.Add(tbtnGenVoucher);
        }

        public void InitialDataSource(string connString, string mergeType, DataTable credenceTable)
        {
            ConnString = connString;
            MergeType = mergeType;
            try
            {
                GetAccounts();
                if (credenceTable != null)
                {
                    dataGridView1.DataSource = credenceTable;
                    toolStripStatusLabel1.Text = string.Format("记录数：{0}   总金额：{1}"
                        , credenceTable.Rows.Count
                        , credenceTable.Compute("sum(debit)", ""));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace + "\r\nInitialDataSource");
            }
        }

        /// <summary>
        /// 获取速达账套
        /// </summary>
        public void GetAccounts()
        {
            DataTable table = SD3000.GetAccounts(ConnString);
            if (table != null)
            {
                cboAccount.DataSource = table;
                cboAccount.DisplayMember = "corpname";
                cboAccount.ValueMember = "accsetname";
                cboAccount.SelectedIndexChanged += CboAccount_SelectedIndexChanged;
            }
        }

        private void CboAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 根据选择的账套修改数据库连接字符串
            string dbSuffix = string.Empty;
            var v = cboAccount.SelectedValue;
            if (v is DataRowView)
            {
                dbSuffix = ((DataRowView)v)["accsetname"].ToString();
            }
            else
                dbSuffix = cboAccount.SelectedValue.ToString();

            if (string.IsNullOrWhiteSpace(dbSuffix)) return;

            string[] s = ConnString.Split(';');
            if (s.Length < 4) return;
            string[] s2 = s[1].Split('=');
            if (s2.Length < 2) return;

            string dbName = s2[1].Substring(0, s2[1].LastIndexOf('_') + 1) + dbSuffix;

            ConnString = s[0] + ";" + s2[0] + "=" + dbName + ";" + s[2] + ";" + s[3];
            #endregion 根据选择的账套修改数据库连接字符串

            try
            {
                GetSubjects();
                GetCredTypes();
                GetOperator();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetSubjects()
        {
            if (string.IsNullOrWhiteSpace(ConnString))
                throw new ArgumentNullException("数据库链接字符串不能为空！");

            DataTable subjects = SD3000.GetSubjects(ConnString);
            if (subjects != null)
            {
                DataTable table = subjects.Copy();

                //税金科目
                cboTaxSSubject.DataSource = table;
                cboTaxSSubject.DisplayMember = "displayname";
                cboTaxSSubject.ValueMember = "subid";
                DataRow[] rows = table.Select("subcode='2221001005'");
                if (rows.Length > 0)
                    cboTaxSSubject.SelectedIndex = table.Rows.IndexOf(rows[0]);

                //主营业务科目
                cboIncomeSubject.DataSource = subjects;
                cboIncomeSubject.DisplayMember = "displayname";
                cboIncomeSubject.ValueMember = "subid";
                DataRow[] rows2 = subjects.Select("subcode='6001'");
                if (rows2.Length > 0)
                    cboIncomeSubject.SelectedIndex = subjects.Rows.IndexOf(rows2[0]);

                //收入科目
                DataTable cashTable = subjects.Copy();
                cboCashSubject.DataSource = cashTable;
                cboCashSubject.DisplayMember = "displayname";
                cboCashSubject.ValueMember = "subid";
                DataRow[] rows3 = cashTable.Select("subcode='1001'");
                if (rows2.Length > 0)
                    cboCashSubject.SelectedIndex = cashTable.Rows.IndexOf(rows2[0]);


                _SubjectTable = table.Copy();
                cboDetailSubject.DataSource = _SubjectTable;
                cboDetailSubject.DisplayMember = "displayname";
                cboDetailSubject.ValueMember = "subid";
                cboDetailSubject.SelectedIndexChanged += CboSubject_SelectedIndexChanged;
            }
        }
        public void GetCredTypes()
        {
            DataTable table = SD3000.GetCredTypes(ConnString);
            if (table != null)
            {
                cboCredType.DataSource = table;
                cboCredType.DisplayMember = "name";
                cboCredType.ValueMember = "id";
            }
        }

        public void GetOperator()
        {
            DataTable table = SD3000.GetOperators(ConnString);
            if (table != null)
            {
                cboBiller.DataSource = table;
                cboBiller.DisplayMember = "opname";
                cboBiller.ValueMember = "opname";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cboAccount.SelectedIndex == -1)
            {
                MessageBox.Show("请选择要导入的账套");
                cboAccount.Focus();
                return;
            }
            if (cboCredType.SelectedIndex == -1)
            {
                MessageBox.Show("请选择凭证字");
                cboCredType.Focus();
                return;
            }
            if (cboBiller.SelectedIndex == -1)
            {
                MessageBox.Show("请选择制单人");
                cboBiller.Focus();
                return;
            }
            if (cboIncomeSubject.SelectedIndex == -1)
            {
                MessageBox.Show("请选择主营业务收入科目");
                cboIncomeSubject.Focus();
                return;
            }
            if (cboTaxSSubject.SelectedIndex == -1)
            {
                MessageBox.Show("请选择应交税费科目");
                cboTaxSSubject.Focus();
                return;
            }

            int credtype = -1;
            if (int.TryParse(cboCredType.SelectedValue.ToString(), out credtype))
                Credtype = credtype;

            int subId_C = -1;
            if (int.TryParse(cboIncomeSubject.SelectedValue.ToString(), out subId_C))
                Sub_C = subId_C;

            int subId_D = -1;
            int.TryParse(cboCashSubject.SelectedValue.ToString(), out subId_D) ;

            int subId_Tax = -1;
            if (int.TryParse(cboTaxSSubject.SelectedValue.ToString(), out subId_Tax))
                Sub_Tax = subId_Tax;

            BillMaker = cboBiller.SelectedValue.ToString();

            CredDate = dteCredDate.Value;

            int moneyId = 0;

            DataTable table = dataGridView1.DataSource as DataTable;
            if (table == null || table.Rows.Count == 0)
            {
                MessageBox.Show("细表为空，无凭证可生成！");
                return;
            }

            try
            {
                SD3000.CreateCredence(ConnString, table, credtype, CredDate, BillMaker, subId_Tax, subId_C, subId_D, moneyId);
                MessageBox.Show("凭证生成成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //获取应收账款科目
        private void btnGetSub_Click(object sender, EventArgs e)
        {
            if (cboAccount.SelectedIndex == -1)
            {
                if (cboAccount.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择要导入的账套");
                    cboAccount.Focus();
                    return;
                }
            }

            DataTable table = dataGridView1.DataSource as DataTable;
            if (table == null || table.Rows.Count == 0)
            {
                MessageBox.Show("细表资料为空，无法获取科目");
                return;
            }

            foreach (DataRow row in table.Rows)
            {
                string vendor = row["vendor"].ToString();
                if (string.IsNullOrWhiteSpace(vendor))
                    continue;

                DataTable subTable = SD3000.GetSubjectByName(ConnString, vendor);
                if(subTable != null && subTable.Rows.Count>0)
                {
                    row["subid"] = subTable.Rows[0]["subid"];
                    row["subID_D_Name"] = subTable.Rows[0]["name"];
                }
            }
        }

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewColumn column = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex];
            if (column == null) return;
            if(column == dataGridView1.Columns["subID_D_Name"])
            {
                //cboDetailSubject.Location.X = dataGridView1.Location.X 
                //    + dataGridView1.GetCellDisplayRectangle(column.Index, dataGridView1.CurrentCell.RowIndex, false).X;
                cboDetailSubject.Location = new Point(
                    dataGridView1.Location.X
                    + dataGridView1.GetCellDisplayRectangle(column.Index, dataGridView1.CurrentCell.RowIndex, false).X
                    , dataGridView1.Location.Y
                    + dataGridView1.GetCellDisplayRectangle(column.Index, dataGridView1.CurrentCell.RowIndex, false).Y);
                    
            }
        }

        private void CboSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            if (row == null)
                return;

            ComboBox cbo = sender as ComboBox;
            if (cbo == null)
                return;

            DataRowView view = cbo.SelectedValue as DataRowView;
            if (view == null) return; 

            row.Cells["subID_D"].Value = view["subid"];
            row.Cells["subID_D_Name"].Value = view["displayname"];
        }
    }

}
