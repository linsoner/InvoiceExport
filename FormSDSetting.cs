using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            dataGridView1.DataError += DataGridView1_DataError;
            dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            GetData();

            SetEditeBtn(false);

        }

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox cbo = e.Control as ComboBox;
            if(cbo!=null && _AccountTable != null)
            {
                cbo.DataSource = _AccountTable;
                cbo.DisplayMember = "name";
                cbo.ValueMember = "name";
            }
        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            SetEditeBtn(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            GetData();
            SetEditeBtn(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            SetEditeBtn(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("将删除当前行，请确认！", "", MessageBoxButtons.OKCancel
                , MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                return;

            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
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
                DataTable table = SD3000.GetConnectionTable();
                if (table.Rows.Count > 0)
                {
                    accset.Items.Add(table.Rows[0]["accset"].ToString());
                    dataGridView1.AllowUserToAddRows = false;
                    
                }
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
            string fieldName = dataGridView1.Columns[e.ColumnIndex].DataPropertyName.ToLower();
            if (fieldName.Equals("integratedSecurity") || fieldName.Equals("password"))
            {
                String server = dataGridView1.CurrentRow.Cells["server"].Value.ToString();
                string dbUser = dataGridView1.CurrentRow.Cells["dbUser"].Value.ToString();
                string password = dataGridView1.CurrentRow.Cells["password"].Value.ToString();
                bool IntegratedSecurity = false;
                bool.TryParse(dataGridView1.CurrentRow.Cells["integratedSecurity"].Value.ToString()
                    , out IntegratedSecurity);
                if (!string.IsNullOrWhiteSpace(password) || IntegratedSecurity)
                {
                    string connString = DBHelper.GetConnectionString(server, "master", dbUser, password, IntegratedSecurity);
                    try
                    {
                        _AccountTable = SD3000.GetSDSysDb(connString);
                    }
                    catch(SqlException e1)
                    {
                        
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
