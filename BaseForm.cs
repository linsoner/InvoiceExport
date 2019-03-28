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
    public partial class BaseForm : Form
    {
        protected static IList<BaseForm> FormList = new List<BaseForm>();
         public BaseForm()
        {
            InitializeComponent();
            if (!FormList.Contains(this))
                FormList.Add(this);
        }

        //设置
        private void toolStripLabelSet_Click(object sender, EventArgs e)
        {
            var f = FormList.Single<BaseForm>(a => a.GetType() == typeof(FormSetting));
            if (f != null) f.Show();
            else new FormSetting().Show();
        }

        //关于
        private void toolStripLabelAbout_Click(object sender, EventArgs e)
        {

        }

        //发票导出
        private void menuInvoiceExport_Click(object sender, EventArgs e)
        {
            var f = FormList.Single<BaseForm>(a => a.GetType() == typeof(FormInvoiceExport));
            if (f != null) f.Show();
            else new FormInvoiceExport().Show();
        }
    }
}
