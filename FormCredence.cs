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

        public int Credtype { get; set; }
        public int Sub_C { get; set; }
        public int Sub_Tax { get; set; }
        public DateTime CredDate { get; set; }
        public string BillMaker { get; set; }

        public FormCredence()
        {
            InitializeComponent();
            InitialToolsTrip();
            cboAccount.SelectedIndexChanged += CboAccount_SelectedIndexChanged;
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
            toolStrip1.Items.Add(tbtnGetSub);
        }

            public void InitialDataSource(string connString,DataTable credenceTable)
        {
            ConnString = connString;
            try
            {
                GetAccounts();
                if(credenceTable != null)
                    dataGridView1.DataSource = credenceTable;
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
            DataRowView view = cboAccount.SelectedValue as DataRowView;
            if (view != null)
            {
                dbSuffix = view["accsetname"].ToString();
            }
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

                cboTaxSSubject.DataSource = table;
                cboTaxSSubject.DisplayMember = "displayname";
                cboTaxSSubject.ValueMember = "subid";
                DataRow[] rows = table.Select("subcode='2221001005'");
                if (rows.Length > 0)
                    cboTaxSSubject.SelectedIndex = table.Rows.IndexOf(rows[0]);

                cboIncomeSubject.DataSource = subjects;
                cboIncomeSubject.DisplayMember = "displayname";
                cboIncomeSubject.ValueMember = "subid";
                DataRow[] rows2 = subjects.Select("subcode='6001'");
                if (rows2.Length > 0)
                    cboIncomeSubject.SelectedIndex = subjects.Rows.IndexOf(rows2[0]);

                _SubjectTable = table.Copy();
                //subID_D_Name.DataSource = table.Copy();
                //subID_D_Name.DisplayMember = "displayname";
                //subID_D_Name.ValueMember = "subid";
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

            //table.DefaultView.Sort = new string[] {  };

            try
            {
                SD3000.CreateCredence(ConnString, table, credtype, CredDate, BillMaker, subId_Tax, subId_C, moneyId);
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
                string name = row[""].ToString();
                if (string.IsNullOrWhiteSpace(name))
                    continue;
                DataTable subTable = SD3000.GetSubjectByName(ConnString, name);
                if(subTable != null && subTable.Rows.Count>0)
                {
                    row["subid_d"] = subTable.Rows[0]["subid"];
                    row["subID_D_Name"] = subTable.Rows[0]["name"];
                }
            }
        }

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox cbo = e.Control as ComboBox;
            cbo.SelectedIndexChanged += Cbo_SelectedIndexChanged;
            if (cbo != null && _SubjectTable != null)
            {
                cbo.DataSource = _SubjectTable;
                cbo.DisplayMember = "displayname";
                cbo.ValueMember = "subid";
            }
        }

        private void Cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            if (row == null)
                return;

            ComboBox cbo = sender as ComboBox;
            if (cbo == null)
                return;

            DataRowView view = cbo.SelectedValue as DataRowView;
            if (view == null) return;

            row.Cells[""].Value = view["subid"];
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
