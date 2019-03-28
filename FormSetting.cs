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
    public partial class FormSetting : BaseForm
    {
        
        public FormSetting()
        {
            InitializeComponent();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
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
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
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
            dataGridView1.DataSource = Company.GetData();
        }

        void SaveData()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                DataTable table = dataGridView1.DataSource as DataTable;
                Company.SaveData(table);
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


    }
}
