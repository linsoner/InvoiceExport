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
         public BaseForm()
        {
            InitializeComponent();
        }

        //设置
        private void toolStripLabelSet_Click(object sender, EventArgs e)
        {
            FormSetting setForm = new FormSetting();
            setForm.Show();
        }

        //关于
        private void toolStripLabelAbout_Click(object sender, EventArgs e)
        {

        }
    }
}
