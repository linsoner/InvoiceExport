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
    public partial class FormMergeType : Form
    {
        public string MergeType { get; set; }

        public FormMergeType()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MergeType = cboGroupBy.SelectedItem.ToString();
        }
    }
}
