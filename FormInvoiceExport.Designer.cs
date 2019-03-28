namespace BaiwangExport
{
    partial class FormInvoiceExport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInvoiceExport));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bteExport = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fpdm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fphm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scbz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fpzt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kprq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zhsl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hjje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hjse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jshj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xhdwsbh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xhdwmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghdwsbh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghdwmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ykfsje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.fphxz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spsm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ggxh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spsl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.je = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.se = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_fpdm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_xh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsbz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.splitContainer1);
            this.mainPanel.Size = new System.Drawing.Size(1008, 590);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.dateEnd);
            this.splitContainer1.Panel1.Controls.Add(this.dateStart);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.bteExport);
            this.splitContainer1.Panel1.Controls.Add(this.btnQuery);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 590);
            this.splitContainer1.SplitterDistance = 45;
            this.splitContainer1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(340, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(43, 21);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "到";
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(223, 13);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(111, 21);
            this.dateEnd.TabIndex = 7;
            // 
            // dateStart
            // 
            this.dateStart.Location = new System.Drawing.Point(79, 12);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(106, 21);
            this.dateStart.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(452, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(244, 20);
            this.comboBox1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "公 司：";
            // 
            // bteExport
            // 
            this.bteExport.Location = new System.Drawing.Point(796, 12);
            this.bteExport.Name = "bteExport";
            this.bteExport.Size = new System.Drawing.Size(75, 23);
            this.bteExport.TabIndex = 3;
            this.bteExport.Text = "导 出";
            this.bteExport.UseVisualStyleBackColor = true;
            this.bteExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(712, 12);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查 询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日 期：";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer2.Size = new System.Drawing.Size(1008, 541);
            this.splitContainer2.SplitterDistance = 220;
            this.splitContainer2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fpdm,
            this.fphm,
            this.xh,
            this.scbz,
            this.fpzt,
            this.kprq,
            this.zhsl,
            this.hjje,
            this.hjse,
            this.jshj,
            this.bz,
            this.xhdwsbh,
            this.xhdwmc,
            this.ghdwsbh,
            this.ghdwmc,
            this.ykfsje});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1008, 220);
            this.dataGridView1.TabIndex = 1;
            // 
            // fpdm
            // 
            this.fpdm.DataPropertyName = "fpdm";
            this.fpdm.HeaderText = "发票代码";
            this.fpdm.Name = "fpdm";
            this.fpdm.ReadOnly = true;
            this.fpdm.Width = 120;
            // 
            // fphm
            // 
            this.fphm.DataPropertyName = "fphm";
            this.fphm.HeaderText = "发票号码";
            this.fphm.Name = "fphm";
            this.fphm.ReadOnly = true;
            this.fphm.Width = 120;
            // 
            // xh
            // 
            this.xh.DataPropertyName = "xh";
            this.xh.HeaderText = "序号";
            this.xh.Name = "xh";
            this.xh.ReadOnly = true;
            this.xh.Width = 60;
            // 
            // scbz
            // 
            this.scbz.DataPropertyName = "scbz";
            this.scbz.HeaderText = "上传标志";
            this.scbz.Name = "scbz";
            this.scbz.ReadOnly = true;
            this.scbz.Width = 60;
            // 
            // fpzt
            // 
            this.fpzt.HeaderText = "发票状态";
            this.fpzt.Name = "fpzt";
            this.fpzt.ReadOnly = true;
            // 
            // kprq
            // 
            this.kprq.DataPropertyName = "kprq";
            this.kprq.HeaderText = "开票日期";
            this.kprq.Name = "kprq";
            this.kprq.ReadOnly = true;
            // 
            // zhsl
            // 
            this.zhsl.DataPropertyName = "zhsl";
            this.zhsl.HeaderText = "综合税率";
            this.zhsl.Name = "zhsl";
            this.zhsl.ReadOnly = true;
            // 
            // hjje
            // 
            this.hjje.DataPropertyName = "hjje";
            this.hjje.HeaderText = "合计金额";
            this.hjje.Name = "hjje";
            this.hjje.ReadOnly = true;
            // 
            // hjse
            // 
            this.hjse.DataPropertyName = "hjse";
            this.hjse.HeaderText = "合计税额";
            this.hjse.Name = "hjse";
            this.hjse.ReadOnly = true;
            // 
            // jshj
            // 
            this.jshj.DataPropertyName = "jshj";
            this.jshj.HeaderText = "价税合计";
            this.jshj.Name = "jshj";
            this.jshj.ReadOnly = true;
            this.jshj.Width = 120;
            // 
            // bz
            // 
            this.bz.DataPropertyName = "bz";
            this.bz.HeaderText = "备注";
            this.bz.Name = "bz";
            this.bz.ReadOnly = true;
            // 
            // xhdwsbh
            // 
            this.xhdwsbh.DataPropertyName = "xhdwsbh";
            this.xhdwsbh.HeaderText = "销货单位识别号";
            this.xhdwsbh.Name = "xhdwsbh";
            this.xhdwsbh.ReadOnly = true;
            // 
            // xhdwmc
            // 
            this.xhdwmc.DataPropertyName = "xhdwmc";
            this.xhdwmc.HeaderText = "销货单位名称";
            this.xhdwmc.Name = "xhdwmc";
            this.xhdwmc.ReadOnly = true;
            // 
            // ghdwsbh
            // 
            this.ghdwsbh.DataPropertyName = "ghdwsbh";
            this.ghdwsbh.HeaderText = "购货单位识别号";
            this.ghdwsbh.Name = "ghdwsbh";
            this.ghdwsbh.ReadOnly = true;
            // 
            // ghdwmc
            // 
            this.ghdwmc.DataPropertyName = "ghdwmc";
            this.ghdwmc.HeaderText = "购货单位名称";
            this.ghdwmc.Name = "ghdwmc";
            this.ghdwmc.ReadOnly = true;
            // 
            // ykfsje
            // 
            this.ykfsje.DataPropertyName = "ykfsje";
            this.ykfsje.HeaderText = "已开负数金额";
            this.ykfsje.Name = "ykfsje";
            this.ykfsje.ReadOnly = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fphxz,
            this.spmc,
            this.spsm,
            this.ggxh,
            this.dw,
            this.spsl,
            this.dj,
            this.je,
            this.sl,
            this.se,
            this.item_fpdm,
            this.item_xh,
            this.hsbz});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(1008, 317);
            this.dataGridView2.TabIndex = 3;
            // 
            // fphxz
            // 
            this.fphxz.DataPropertyName = "fphxz";
            this.fphxz.HeaderText = "发票行性质";
            this.fphxz.Name = "fphxz";
            this.fphxz.ReadOnly = true;
            this.fphxz.Width = 80;
            // 
            // spmc
            // 
            this.spmc.DataPropertyName = "spmc";
            this.spmc.HeaderText = "商品名称";
            this.spmc.Name = "spmc";
            this.spmc.ReadOnly = true;
            // 
            // spsm
            // 
            this.spsm.DataPropertyName = "spsm";
            this.spsm.HeaderText = "商品税目";
            this.spsm.Name = "spsm";
            this.spsm.ReadOnly = true;
            // 
            // ggxh
            // 
            this.ggxh.DataPropertyName = "ggxh";
            this.ggxh.HeaderText = "规格型号";
            this.ggxh.Name = "ggxh";
            this.ggxh.ReadOnly = true;
            // 
            // dw
            // 
            this.dw.DataPropertyName = "dw";
            this.dw.HeaderText = "单位";
            this.dw.Name = "dw";
            this.dw.ReadOnly = true;
            this.dw.Width = 60;
            // 
            // spsl
            // 
            this.spsl.DataPropertyName = "spsl";
            this.spsl.HeaderText = "商品数量";
            this.spsl.Name = "spsl";
            this.spsl.ReadOnly = true;
            this.spsl.Width = 80;
            // 
            // dj
            // 
            this.dj.DataPropertyName = "dj";
            this.dj.HeaderText = "单价";
            this.dj.Name = "dj";
            this.dj.ReadOnly = true;
            // 
            // je
            // 
            this.je.DataPropertyName = "je";
            this.je.HeaderText = "金额";
            this.je.Name = "je";
            this.je.ReadOnly = true;
            // 
            // sl
            // 
            this.sl.DataPropertyName = "sl";
            this.sl.HeaderText = "税率";
            this.sl.Name = "sl";
            this.sl.ReadOnly = true;
            // 
            // se
            // 
            this.se.DataPropertyName = "se";
            this.se.HeaderText = "含税标志";
            this.se.Name = "se";
            this.se.ReadOnly = true;
            // 
            // item_fpdm
            // 
            this.item_fpdm.DataPropertyName = "fpdm";
            this.item_fpdm.HeaderText = "发票代码";
            this.item_fpdm.Name = "item_fpdm";
            this.item_fpdm.ReadOnly = true;
            // 
            // item_xh
            // 
            this.item_xh.DataPropertyName = "xh";
            this.item_xh.HeaderText = "序号";
            this.item_xh.Name = "item_xh";
            this.item_xh.ReadOnly = true;
            // 
            // hsbz
            // 
            this.hsbz.DataPropertyName = "hsbz";
            this.hsbz.HeaderText = "含税标志";
            this.hsbz.Name = "hsbz";
            this.hsbz.ReadOnly = true;
            // 
            // FormInvoiceExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 662);
            this.Name = "FormInvoiceExport";
            this.mainPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bteExport;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fpdm;
        private System.Windows.Forms.DataGridViewTextBoxColumn fphm;
        private System.Windows.Forms.DataGridViewTextBoxColumn xh;
        private System.Windows.Forms.DataGridViewTextBoxColumn scbz;
        private System.Windows.Forms.DataGridViewTextBoxColumn fpzt;
        private System.Windows.Forms.DataGridViewTextBoxColumn kprq;
        private System.Windows.Forms.DataGridViewTextBoxColumn zhsl;
        private System.Windows.Forms.DataGridViewTextBoxColumn hjje;
        private System.Windows.Forms.DataGridViewTextBoxColumn hjse;
        private System.Windows.Forms.DataGridViewTextBoxColumn jshj;
        private System.Windows.Forms.DataGridViewTextBoxColumn bz;
        private System.Windows.Forms.DataGridViewTextBoxColumn xhdwsbh;
        private System.Windows.Forms.DataGridViewTextBoxColumn xhdwmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghdwsbh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghdwmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ykfsje;
        private System.Windows.Forms.DataGridViewTextBoxColumn fphxz;
        private System.Windows.Forms.DataGridViewTextBoxColumn spmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn spsm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ggxh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dw;
        private System.Windows.Forms.DataGridViewTextBoxColumn spsl;
        private System.Windows.Forms.DataGridViewTextBoxColumn dj;
        private System.Windows.Forms.DataGridViewTextBoxColumn je;
        private System.Windows.Forms.DataGridViewTextBoxColumn sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn se;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_fpdm;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_xh;
        private System.Windows.Forms.DataGridViewTextBoxColumn hsbz;
    }
}