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
    public partial class FormCredence : Form
    {
        string ConnString { get; set; }

        public int Credtype { get; set; }
        public int Sub_C { get; set; }
        public int Sub_Tax { get; set; }
        public DateTime CredDate { get; set; }
        public string BillMaker { get; set; }
   
        public FormCredence()
        {
            InitializeComponent();
            
        }

        public void SetConnString(string connString)
        {
            ConnString = connString;
            GetSubjects();
            GetCredTypes();
            GetOperator();
        }
        public void GetSubjects()
        {
            if (string.IsNullOrWhiteSpace(ConnString))
                throw new ArgumentNullException("数据库链接字符串不能为空！");

            DataTable subjects = SD3000.GetSubjects(ConnString);
            if(subjects!=null)
            {
                DataTable table = subjects.Copy();

                cboTaxSSubject.DataSource = table;
                cboTaxSSubject.DisplayMember = "displayname";
                cboTaxSSubject.ValueMember = "subid";
                //DataRow[] rows = table.Select("")
                cboTaxSSubject.SelectedItem = table.Select("subcode='2221001'").First();

                cboIncomeSubject.DataSource = subjects;
                cboIncomeSubject.DisplayMember = "displayname";
                cboIncomeSubject.ValueMember = "subid";
                cboIncomeSubject.SelectedItem = table.Select("subcode='5001'").First();
            }
        }
        public void GetCredTypes()
        {
            DataTable table = SD3000.GetCredTypes(ConnString);
            if(table !=null)
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
            if(cboCredType.SelectedIndex == -1)
            {
                MessageBox.Show("请选择凭证字");
                cboCredType.Focus();
            }
            if (cboBiller.SelectedIndex == -1)
            {
                MessageBox.Show("请选择制单人");
                cboBiller.Focus();
            }
            if (cboIncomeSubject.SelectedIndex == -1)
            {
                MessageBox.Show("请选择主营业务收入科目");
                cboIncomeSubject.Focus();
            }
            if (cboTaxSSubject.SelectedIndex == -1)
            {
                MessageBox.Show("请选择应交税费科目");
                cboTaxSSubject.Focus();
            }

            int credtype = -1;
            if(int.TryParse(cboCredType.SelectedValue.ToString(),out credtype))
                Credtype = credtype;

            int sub_C = -1;
            if (int.TryParse(cboIncomeSubject.SelectedValue.ToString(), out sub_C))
                Sub_C = sub_C;

            int sub_Tax = -1;
            if (int.TryParse(cboTaxSSubject.SelectedValue.ToString(), out sub_Tax))
                Sub_Tax = sub_Tax;

            BillMaker= cboBiller.SelectedValue.ToString();

            CredDate = dteCredDate.Value;
    }
    }
}
