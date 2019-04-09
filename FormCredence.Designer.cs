namespace BaiwangExport
{
    partial class FormCredence
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cboAccount = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGetSub = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cboIncomeSubject = new System.Windows.Forms.ComboBox();
            this.cboTaxSSubject = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboBiller = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dteCredDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCredType = new System.Windows.Forms.ComboBox();
            this.lblCredType = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.mainPanel.Size = new System.Drawing.Size(1264, 610);
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
            this.splitContainer1.Panel1.Controls.Add(this.cboAccount);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.btnGetSub);
            this.splitContainer1.Panel1.Controls.Add(this.btnOK);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.cboIncomeSubject);
            this.splitContainer1.Panel1.Controls.Add(this.cboTaxSSubject);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.cboBiller);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.dteCredDate);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cboCredType);
            this.splitContainer1.Panel1.Controls.Add(this.lblCredType);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 610);
            this.splitContainer1.SplitterDistance = 130;
            this.splitContainer1.TabIndex = 0;
            // 
            // cboAccount
            // 
            this.cboAccount.FormattingEnabled = true;
            this.cboAccount.Location = new System.Drawing.Point(126, 19);
            this.cboAccount.Name = "cboAccount";
            this.cboAccount.Size = new System.Drawing.Size(348, 20);
            this.cboAccount.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "转入账套";
            // 
            // btnGetSub
            // 
            this.btnGetSub.Location = new System.Drawing.Point(764, 46);
            this.btnGetSub.Name = "btnGetSub";
            this.btnGetSub.Size = new System.Drawing.Size(115, 23);
            this.btnGetSub.TabIndex = 27;
            this.btnGetSub.Text = "获取应收账款科目";
            this.btnGetSub.UseVisualStyleBackColor = true;
            this.btnGetSub.Click += new System.EventHandler(this.btnGetSub_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(764, 84);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(115, 23);
            this.btnOK.TabIndex = 26;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(383, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "主营业务科目";
            // 
            // cboIncomeSubject
            // 
            this.cboIncomeSubject.FormattingEnabled = true;
            this.cboIncomeSubject.Location = new System.Drawing.Point(475, 90);
            this.cboIncomeSubject.Name = "cboIncomeSubject";
            this.cboIncomeSubject.Size = new System.Drawing.Size(234, 20);
            this.cboIncomeSubject.TabIndex = 24;
            // 
            // cboTaxSSubject
            // 
            this.cboTaxSSubject.FormattingEnabled = true;
            this.cboTaxSSubject.Location = new System.Drawing.Point(125, 90);
            this.cboTaxSSubject.Name = "cboTaxSSubject";
            this.cboTaxSSubject.Size = new System.Drawing.Size(227, 20);
            this.cboTaxSSubject.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "应交税费科目";
            // 
            // cboBiller
            // 
            this.cboBiller.FormattingEnabled = true;
            this.cboBiller.Location = new System.Drawing.Point(559, 55);
            this.cboBiller.Name = "cboBiller";
            this.cboBiller.Size = new System.Drawing.Size(150, 20);
            this.cboBiller.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(512, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "制单人";
            // 
            // dteCredDate
            // 
            this.dteCredDate.Location = new System.Drawing.Point(350, 53);
            this.dteCredDate.Name = "dteCredDate";
            this.dteCredDate.Size = new System.Drawing.Size(124, 21);
            this.dteCredDate.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "凭证日期";
            // 
            // cboCredType
            // 
            this.cboCredType.FormattingEnabled = true;
            this.cboCredType.Location = new System.Drawing.Point(125, 54);
            this.cboCredType.Name = "cboCredType";
            this.cboCredType.Size = new System.Drawing.Size(121, 20);
            this.cboCredType.TabIndex = 17;
            // 
            // lblCredType
            // 
            this.lblCredType.AutoSize = true;
            this.lblCredType.Location = new System.Drawing.Point(72, 57);
            this.lblCredType.Name = "lblCredType";
            this.lblCredType.Size = new System.Drawing.Size(41, 12);
            this.lblCredType.TabIndex = 16;
            this.lblCredType.Text = "凭证字";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1264, 476);
            this.dataGridView1.TabIndex = 0;
            // 
            // FormCredence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Name = "FormCredence";
            this.Text = "转速达凭证";
            this.mainPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cboAccount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGetSub;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboIncomeSubject;
        private System.Windows.Forms.ComboBox cboTaxSSubject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboBiller;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dteCredDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCredType;
        private System.Windows.Forms.Label lblCredType;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}