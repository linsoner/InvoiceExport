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
    public partial class FormSDSetting : BaseForm
    {
        DataTable _AccountTable = null;
        public FormSDSetting()
        {
            InitializeComponent();
            //dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            GetData();
            SetEditeBtn(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            SetEditeBtn(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetEditeBtn(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GetData();
            SetEditeBtn(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("将删除当前行，请确认！", "", MessageBoxButtons.OKCancel
                , MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                return;

            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }

        /// <summary>
        /// 单元格显示格式事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 把第4列显示*号，*号的个数和实际数据的长度相同
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("password"))
            {
                if (e.Value != null && e.Value.ToString().Length > 0)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            }
        }

        private void toolStripLabelSet_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabelAbout_Click(object sender, EventArgs e)
        {

        }

        void GetData()
        {
            try
            {
                dataGridView1.DataSource = SD3000.GetConnectionTable();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace + "\r\nGetData");
            }
        }

        void SaveData()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                DataTable table = dataGridView1.DataSource as DataTable;
                SD3000.SaveConnection(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace + "\r\nSaveData");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        void SetEditeBtn(bool isEdit)
        {
            btnSave.Enabled = isEdit;
            btnDelete.Enabled = isEdit;
            btnCancel.Enabled = isEdit;
            btnEdit.Enabled = !isEdit;
            dataGridView1.ReadOnly = !isEdit;
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Equals("dbUser") || dataGridView1.Columns[e.ColumnIndex].Equals("password"))
            {
                String server = dataGridView1.CurrentRow.Cells["server"].ToString();
                string dbUser = dataGridView1.CurrentRow.Cells["dbUser"].ToString();
                string password = dataGridView1.CurrentRow.Cells["password"].ToString();
                bool IntegratedSecurity = false;
                    bool.TryParse(dataGridView1.CurrentRow.Cells["integratedSecurity"].ToString(), out IntegratedSecurity);
                if (!string.IsNullOrWhiteSpace(dbUser) && !string.IsNullOrWhiteSpace(dbUser))
                {
                    string connString = DBHelper.GetConnectionString(server, "master", dbUser, password, IntegratedSecurity);
                    _AccountTable = SD3000.GetSDSysDb(connString);
                }
            }
        }
    }
}
