namespace BaiwangExport
{
    partial class FormSetting
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NSRSBH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKPBH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKPPwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CertPwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxHardware = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.splitContainer1);
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
            this.splitContainer1.Panel1.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel1.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            this.splitContainer1.Panel1.Controls.Add(this.btnEdit);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(908, 378);
            this.splitContainer1.SplitterDistance = 54;
            this.splitContainer1.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(196, 17);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "删 除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(289, 17);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(105, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(21, 17);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "修 改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.company,
            this.NSRSBH,
            this.SKPBH,
            this.SKPPwd,
            this.CertPwd,
            this.taxHardware});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(908, 320);
            this.dataGridView1.TabIndex = 0;
            // 
            // company
            // 
            this.company.DataPropertyName = "company";
            this.company.HeaderText = "企业简称";
            this.company.Name = "company";
            // 
            // NSRSBH
            // 
            this.NSRSBH.DataPropertyName = "NSRSBH";
            this.NSRSBH.HeaderText = "纳税人识别号";
            this.NSRSBH.Name = "NSRSBH";
            this.NSRSBH.Width = 200;
            // 
            // SKPBH
            // 
            this.SKPBH.DataPropertyName = "SKPBH";
            this.SKPBH.HeaderText = "税控盘编号";
            this.SKPBH.Name = "SKPBH";
            this.SKPBH.Width = 150;
            // 
            // SKPPwd
            // 
            this.SKPPwd.DataPropertyName = "SKPPwd";
            this.SKPPwd.HeaderText = "税控盘口令";
            this.SKPPwd.Name = "SKPPwd";
            this.SKPPwd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CertPwd
            // 
            this.CertPwd.DataPropertyName = "CertPwd";
            this.CertPwd.HeaderText = "数字证书密码";
            this.CertPwd.Name = "CertPwd";
            this.CertPwd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // taxHardware
            // 
            this.taxHardware.DataPropertyName = "Hardware";
            this.taxHardware.HeaderText = "税控盘类型";
            this.taxHardware.Items.AddRange(new object[] {
            "百旺",
            "航天"});
            this.taxHardware.Name = "taxHardware";
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 450);
            this.Name = "FormSetting";
            this.Text = "税控盘设置";
            this.mainPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn company;
        private System.Windows.Forms.DataGridViewTextBoxColumn NSRSBH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKPBH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKPPwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn CertPwd;
        private System.Windows.Forms.DataGridViewComboBoxColumn taxHardware;
    }
}