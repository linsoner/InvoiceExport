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
        protected static Dictionary<string,BaseForm> FormDictionary = new Dictionary<string, BaseForm>();
         public BaseForm()
        {
            InitializeComponent();
            if (!FormDictionary.Keys.Contains(this.Name))
                FormDictionary.Add(this.Name,this);
        }

        //设置
        private void toolStripLabelSet_Click(object sender, EventArgs e)
        {
            if (FormDictionary.Keys.Contains("FormSetting"))
            {
                FormDictionary["FormSetting"].Show();
            }
            else
            {
                new FormSetting().Show();
            }
        }

        //关于
        private void toolStripLabelAbout_Click(object sender, EventArgs e)
        {

        }

        //发票导出
        private void menuInvoiceExport_Click(object sender, EventArgs e)
        {
            if (FormDictionary.Keys.Contains("FormInvoiceExport"))
            {
                FormDictionary["FormInvoiceExport"].Show();
            }
            else
            {
                new FormInvoiceExport().Show();
            }
        }

        private void menuSDSetting_Click(object sender, EventArgs e)
        {
            if (FormDictionary.Keys.Contains("FormSDSetting"))
            {
                FormDictionary["FormSDSetting"].Show();
            }
            else
            {
                new FormSDSetting().Show();
            }
        }
    }
}
